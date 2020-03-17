namespace WebApplication3.Migrations
{
    using Dal;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication3.Dal.StoreContext";
        }

        protected override void Seed(WebApplication3.Dal.StoreContext context)
        {
            StoreInitializer.SeedStoreDate(context);
        }
    }
}
