using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DataAcquisition.Model.Entities;

namespace DataAcquisition.Model
{
    public class DataAcquisitionDbContext : DbContext
    {
        public DataAcquisitionDbContext()
            : base("DataAcquisitionDatabase")
        {

        }

        public DbSet<ServiceInfo> ServiceInfoes { get; set; }
        public DbSet<Port> Ports { get; set; }
    }
}
