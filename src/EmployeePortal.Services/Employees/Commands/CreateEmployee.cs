using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EmployeePortal.Services.DTOs;

namespace EmployeePortal.Services.Employees.Commands
{
    public sealed record CreateEmployee(string FirstName, string LastName, string Email, DateOnly HireDate) : IRequest<EmployeeDto>;
}
