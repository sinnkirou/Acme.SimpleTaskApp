using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.SimpleTaskApp.Tasks.Dtos;
using System.Threading.Tasks;

public interface ITaskAppService : IApplicationService
{
    Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);

    System.Threading.Tasks.Task Create(CreateTaskInput input);
}