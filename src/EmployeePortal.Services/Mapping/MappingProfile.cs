using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeePortal.Core.Entities;
using EmployeePortal.Services.DTOs;

namespace EmployeePortal.Services.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.Email, m => m.MapFrom(s => s.Email.Value))
            .ForMember(d => d.Status, m => m.MapFrom(s => s.Status.ToString()));
        }
    }

}
