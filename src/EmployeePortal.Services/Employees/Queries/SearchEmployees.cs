using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EmployeePortal.Services.DTOs;

namespace EmployeePortal.Services.Employees.Queries
{
    public sealed record SearchEmployees(string? Q, int Page = 1, int PageSize = 20) : IRequest<PagedResult<EmployeeDto>>;
    public sealed record PagedResult<T>(IReadOnlyList<T> Items, int Total, int Page, int PageSize);
}
