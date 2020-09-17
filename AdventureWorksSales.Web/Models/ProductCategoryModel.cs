using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class ProductCategoryModel
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}