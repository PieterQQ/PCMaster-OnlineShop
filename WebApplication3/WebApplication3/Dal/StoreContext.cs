using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Dal
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        static StoreContext()
        {
            Database.SetInitializer(new StoreInitializer());
        }
        public StoreContext() : base("StoreContext") {  }
        public DbSet<Podzespol> Podzespol { get; set; }
        public DbSet<podzespoly> Podzespoly { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

         public static StoreContext Create()
        {
            return new StoreContext();
        }
    }
}