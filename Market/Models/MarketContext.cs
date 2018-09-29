using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class MarketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MarketContext() : base("name=MarketContext")
        {
        }

        public System.Data.Entity.DbSet<Market.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Market.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<Market.Models.Employee> Employees { get; set; }
    }
}
