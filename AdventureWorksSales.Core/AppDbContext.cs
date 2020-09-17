using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Configuration;
using AdventureWorksSales.Core.Entities;

namespace AdventureWorksSales.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            Database.SetInitializer<AppDbContext>(null);

            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 600;
        }

        object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(28, 28));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PRODUCT> PRODUCT { get; set; }
        public DbSet<PRODUCTCATEGORY> PRODUCTCATEGORY { get; set; }
        public DbSet<SALESORDER> SALESORDER { get; set; }

    }
}
