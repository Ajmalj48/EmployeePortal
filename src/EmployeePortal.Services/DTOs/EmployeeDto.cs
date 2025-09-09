using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Services.DTOs
{
    public sealed record EmployeeDto(Guid Id, string FirstName, string LastName,string Email, string Status, DateOnly HireDate);
}
