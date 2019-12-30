using MvcGiris.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcGiris.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public AppDbContext():base("DefCon")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>("DefCon"));
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}