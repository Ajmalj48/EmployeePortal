using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using EmployeePortal.Core.Abstractions.Repositories;
using EmployeePortal.Services.DTOs;

namespace EmployeePortal.Services.Employees.Queries
{
    public sealed class SearchEmployeesHandler(IEmployeeRepository repo, IMapper mapper) : IRequestHandler<SearchEmployees, PagedResult<EmployeeDto>>
    {
        public async Task<PagedResult<EmployeeDto>> Handle(SearchEmployees req,CancellationToken ct)
        {
            var (items, total) = await repo.SearchAsync(req.Q, req.Page,req.PageSize, ct);
            var dtos = items.Select(mapper.Map<EmployeeDto>).ToList();
            return new(dtos, total, req.Page, req.PageSize);
        }
    }

}
