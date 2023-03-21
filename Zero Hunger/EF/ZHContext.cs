using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zero_Hunger.EF.Models;

namespace Zero_Hunger.EF
{
    public class ZHContext:DbContext
    {
        public DbSet<NGO> NGOs { get; set; }
        public DbSet<Collect> Collects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectDetail> CollectDetails { get; set; }
        public DbSet<ActiveEmployee> ActiveEmployees { get; set; }
    }
}