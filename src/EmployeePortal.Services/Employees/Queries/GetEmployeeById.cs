using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EmployeePortal.Services.DTOs;

namespace EmployeePortal.Services.Employees.Queries
{
    public sealed record GetEmployeeById(Guid Id) : IRequest<EmployeeDto?>;
}
