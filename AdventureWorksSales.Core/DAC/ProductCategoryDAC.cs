using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AdventureWorksSales.Core.Entities;

namespace AdventureWorksSales.Core.DAC
{
    public class ProductCategoryDAC
    {
        public PRODUCTCATEGORY InsertProductCategory(PRODUCTCATEGORY productCategory)
        {
            using (var db = new AppDbContext())
            {
                db.Set<PRODUCTCATEGORY>().Add(productCategory);
                db.SaveChanges();

                return productCategory;
            }
        }

        public void UpdateProductCategory(PRODUCTCATEGORY productCategory)
        {
            using (var db = new AppDbContext())
            {
                var entry = db.Entry<PRODUCTCATEGORY>(productCategory);

                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public PRODUCTCATEGORY SelectCategoryById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Set<PRODUCTCATEGORY>().Find(id);
            }
        }

        public List<PRODUCTCATEGORY> SelectProductCategories()
        {
            using (var db = new AppDbContext())
            {
                var query = db.PRODUCTCATEGORY.OrderByDescending(q => q.ModifiedDate).Select(x => x);

                return query.ToList();
            }
        }


        public int CountProductCategory()
        {
            using (var db = new AppDbContext())
            {
                IQueryable<PRODUCTCATEGORY> query = db.Set<PRODUCTCATEGORY>();

                return query.Count();
            }
        }
    }
}
