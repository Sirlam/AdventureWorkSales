using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class ProductCategoryModel
    {
        public int ProductCategoryID { get; set; }
        [Required(ErrorMessage = "Product Category Name is required", AllowEmptyStrings = false)]
        [DisplayName("Product Category Name")]
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}