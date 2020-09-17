using AdventureWorksSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.DAC
{
    public class SalesOrderDAC
    {
        public SALESORDER InsertSalesOrder(SALESORDER salesOrder)
        {
            using (var db = new AppDbContext())
            {
                db.Set<SALESORDER>().Add(salesOrder);
                db.SaveChanges();

                return salesOrder;
            }
        }

        public void UpdateSalesOrder(SALESORDER salesOrder)
        {
            using (var db = new AppDbContext())
            {
                var entry = db.Entry<SALESORDER>(salesOrder);

                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public SALESORDER SelectSalesById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Set<SALESORDER>().Find(id);
            }
        }

        public List<SALESORDER> SelectSales()
        {
            using (var db = new AppDbContext())
            {
                var query = db.SALESORDER.OrderByDescending(q => q.ModifiedDate).Select(x => x);

                return query.ToList();
            }
        }


        public int CountSalesOrders()
        {
            using (var db = new AppDbContext())
            {
                IQueryable<SALESORDER> query = db.Set<SALESORDER>();

                return query.Count();
            }
        }

        public Decimal GetHighestLineTotal()
        {
            using (var db = new AppDbContext())
            {
                Decimal highestlinetotal = db.SALESORDER.Max(x => x.LineTotal);

                return highestlinetotal;
            }
        }

        public Decimal FrontBrakesSalesTotal()
        {
            using (var db = new AppDbContext())
            {
                Decimal frontbrakesTotal = db.SALESORDER.Where(v => v.ProductID == 948).Sum(x => x.LineTotal);

                return frontbrakesTotal;
            }
        }

    }
}
