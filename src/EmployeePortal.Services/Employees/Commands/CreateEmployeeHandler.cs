using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using EmployeePortal.Core.Abstractions;
using EmployeePortal.Core.Abstractions.Repositories;
using EmployeePortal.Core.Entities;
using EmployeePortal.Core.ValueObjects;
using EmployeePortal.Services.DTOs;

namespace EmployeePortal.Services.Employees.Commands
{
    public sealed class CreateEmployeeHandler(IEmployeeRepository repo, IUnitOfWork uow, IMapper mapper) : IRequestHandler<CreateEmployee, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(CreateEmployee req, CancellationToken
        ct)
        {
            if (await repo.EmailExistsAsync(req.Email, ct))
                throw new InvalidOperationException("Email already exists");
            var emp = new Employee(req.FirstName, req.LastName, new
            Email(req.Email), req.HireDate);
            await repo.AddAsync(emp, ct);
            await uow.SaveChangesAsync(ct);
            return mapper.Map<EmployeeDto>(emp);
        }
    }
}
