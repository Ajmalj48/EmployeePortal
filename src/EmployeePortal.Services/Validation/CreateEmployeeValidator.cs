using EmployeePortal.Services.Employees.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Services.Validation
{
    public sealed class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
            RuleFor(x =>
            x.HireDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow.Date));
        }
    }
}
