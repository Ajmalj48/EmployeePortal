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
    public sealed class GetEmployeeByIdHandler(IEmployeeRepository repo, IMapper mapper) : IRequestHandler<GetEmployeeById, EmployeeDto?>
    {
        public async Task<EmployeeDto?> Handle(GetEmployeeById req,CancellationToken ct)
        {
            var entity = await repo.GetByIdAsync(req.Id, ct);
            return entity is null ? null : mapper.Map<EmployeeDto>(entity);
        }
    }
}
