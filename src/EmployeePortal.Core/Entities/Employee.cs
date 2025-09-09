using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePortal.Core.Enums;
using EmployeePortal.Core.ValueObjects;

namespace EmployeePortal.Core.Entities
{
    public sealed class Employee
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public EmploymentStatus Status { get; private set; } =
        EmploymentStatus.Active;
        public DateOnly HireDate { get; private set; }
        private Employee() { }
        public Employee(string firstName, string lastName, Email email, DateOnly
        hireDate)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new
            ArgumentException("FirstName required") : firstName.Trim();
            LastName = string.IsNullOrWhiteSpace(lastName) ? throw new
            ArgumentException("LastName required") : lastName.Trim();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            HireDate = hireDate;
        }
        public void Terminate(DateOnly on) => Status = EmploymentStatus.Terminated;
    }
}
