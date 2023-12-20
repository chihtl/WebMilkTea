using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAdmin.Models
{
    public class HomeModel
    {
        public IEnumerable<ProductCategory> categories { get; set; }
        public IEnumerable<Product> popularItems { get; set; }
        public IEnumerable<Product> newProducts { get; set; }
        public IEnumerable<Product> toppings { get; set; }

    }
}