using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<VhmDbContext>
    {
        public VhmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VhmDbContext>();
            optionsBuilder.UseSqlServer(
                "data source=.;user id=sa;password=Masterxp01;initial catalog=vhm20;integrated security=false;persist security info=False;TrustServerCertificate=True");
            optionsBuilder.EnableSensitiveDataLogging();

            return new VhmDbContext(optionsBuilder.Options, null!);
        }
    }
}
