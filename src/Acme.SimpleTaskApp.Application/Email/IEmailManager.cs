using Abp.Application.Services;
using Abp.Domain.Services;
using Acme.SimpleTaskApp.Email.Dtos;
using Acme.SimpleTaskApp.Tasks.Dtos;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Email
{
    public interface IEmailManager : IDomainService, IApplicationService
    {
        Task Assign(TaskListDto task, string emailAddress);
    }
}
