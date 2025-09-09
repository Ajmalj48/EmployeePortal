using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeePortal.Core.Abstractions.Repositories;
using EmployeePortal.Core.Entities;
using EmployeePortal.Infrastructure.Persistence;

namespace EmployeePortal.Infrastructure.Repositories
{
    public sealed class EmployeeRepository(AppDbContext db) : IEmployeeRepository
    {
        public Task<Employee?> GetByIdAsync(Guid id, CancellationToken ct = default) => db.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        public Task<bool> EmailExistsAsync(string email, CancellationToken ct = default) => db.Employees.AsNoTracking().AnyAsync(x => x.Email.Value == email,ct);
        public Task AddAsync(Employee employee, CancellationToken ct = default) => db.Employees.AddAsync(employee, ct).AsTask();
        public Task UpdateAsync(Employee employee, CancellationToken ct = default)
        { db.Employees.Update(employee); return Task.CompletedTask; }

        public async Task<(IReadOnlyList<Employee> Items, int Total)>
        SearchAsync(string? q, int page, int pageSize, CancellationToken ct = default)
        {
            var query = db.Employees.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(x => x.FirstName.Contains(q) ||
                x.LastName.Contains(q) || x.Email.Value.Contains(q));
            var total = await query.CountAsync(ct);
            var items = await query.OrderBy(x => x.LastName).ThenBy(x =>
            x.FirstName)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);
            return (items, total);
        }
    }
}
