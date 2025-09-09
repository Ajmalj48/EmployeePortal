using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePortal.Core.Abstractions;
using EmployeePortal.Infrastructure.Persistence;

namespace EmployeePortal.Infrastructure.Persistence
{
    public sealed class UnitOfWork(AppDbContext db) : IUnitOfWork
    {
            public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
            db.SaveChangesAsync(ct);
    }
}
