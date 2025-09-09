using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeePortal.Infrastructure.Persistence
{
    public sealed class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var opts = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=STXLAPTOP103;Database=EmployeePortal;Trusted_Connection=True;TrustServerCertificate=True;").Options;
            return new AppDbContext(opts);
        }
    }
}
