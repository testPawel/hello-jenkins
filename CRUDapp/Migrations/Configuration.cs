namespace CRUDapp.Migrations
{
    using CRUDapp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUDapp.Models.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CRUDapp.Models.TodoContext context)
        {
            var r = new Random();
            var items = Enumerable.Range(1, 50).Select(o => new Restaurants
            {
                DueDate = "00:00:00",
                Adress = "Restaurant Adress",
                Name = "Restaurant: " + o.ToString()
            }).ToArray();
            context.Restaurants.AddOrUpdate(item => new { item.Name }, items);
        }
    }
}
