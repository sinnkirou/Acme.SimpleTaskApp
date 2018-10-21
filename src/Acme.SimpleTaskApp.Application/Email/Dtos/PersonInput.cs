using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Acme.SimpleTaskApp.People;
using System;

namespace Acme.SimpleTaskApp.Email.Dtos
{
    [AutoMapFrom(typeof(Person))]
    public class PersonInput : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
