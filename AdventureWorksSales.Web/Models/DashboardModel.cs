using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class DashboardModel
    {
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public int TotalOrders { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0}", ApplyFormatInEditMode = true)]
        public Decimal HighestLineTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0}", ApplyFormatInEditMode = true)]
        public Decimal FrontBrakesTotal { get; set; }
    }
}