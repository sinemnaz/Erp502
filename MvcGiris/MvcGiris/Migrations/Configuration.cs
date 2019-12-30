namespace MvcGiris.Migrations
{
    using FakeData;
    using MvcGiris.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcGiris.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcGiris.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if(!context.Employees.Any())
            {
                for(int i=0;i<10;i++)
                {
                    Employee emp = new Employee()
                    {
                        Name = NameData.GetFirstName(),
                        JobTitle = FakeData.NameData.GetCompanyName(),
                        ModifiedBy="Admin1",
                        ModifiedDate=DateTime.Now,
                        CreatedBy="Admin1",
                        CreatedDate=DateTime.Now
                    };
                    context.Employees.Add(emp);
                }
                context.SaveChanges();
            }
        }
    }
}
