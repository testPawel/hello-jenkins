using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CRUDapp.Models;

namespace CRUDapp.Controllers
{
    public class TodoController : ApiController
    {
        private TodoContext db = new TodoContext();

        // GET api/Default1
		//[HttpGet]
        public IEnumerable<Restaurants> GetTodoItems(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<Restaurants>();

            IQueryable<Restaurants> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.Adress)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Name.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/Default1/5
        public Restaurants GetTodoItem(int id)
        {
            Restaurants todoitem = db.Restaurants.Find(id);
            if (todoitem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return todoitem;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutTodoItem(int id, Restaurants todoitem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != todoitem.RestaurantsId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(todoitem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Default1
        public HttpResponseMessage PostTodoItem(Restaurants todoitem)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(todoitem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, todoitem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = todoitem.RestaurantsId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteTodoItem(int id)
        {
            Restaurants todoitem = db.Restaurants.Find(id);
            if (todoitem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Restaurants.Remove(todoitem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, todoitem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}