using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Entities
{
    public class SALESORDER
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public Int16 OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal UnitPriceDiscount { get; set; }
        public Decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
