using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDapp.Models
{
    public class Restaurants
    {
        public int RestaurantsId { get; set; }
        public string Name { get; set; }
        public string DueDate { get; set; }
        public string Adress { get; set; }
    }

}