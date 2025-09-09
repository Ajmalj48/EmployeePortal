using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeePortal.Core.Entities;

namespace EmployeePortal.Infrastructure.Persistence
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();
        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Employee>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
                e.Property(x => x.LastName).HasMaxLength(100).IsRequired();
                e.OwnsOne(x => x.Email, nb => nb.Property(p =>
                p.Value).HasColumnName("Email").HasMaxLength(256).IsRequired());
            });
        }
    }
}
