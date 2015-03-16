namespace DataAcquisition.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAcquisition.Model.DataAcquisitionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAcquisition.Model.DataAcquisitionDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            DataAcquisition.Service.DBAccess.UpdateServiceInfo("10 . 0 . 0 .198", 8087, 8089);
            for (int j = 0; j < 6; j++ )
            {
                DataAcquisition.Service.DBAccess.AddPort(Model.Entities.DriverType.VDK, 3000 + j);
            }

            for (int j = 0; j < 13; j++)
            {
                DataAcquisition.Service.DBAccess.AddPort(Model.Entities.DriverType.OPC, 4000 + j);
            }
        }
    }
}
