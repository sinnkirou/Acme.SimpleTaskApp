using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Acme.SimpleTaskApp.Email;
using Acme.SimpleTaskApp.Tasks.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Acme.SimpleTaskApp.Tasks
{
    public class TaskAppService : SimpleTaskAppAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IEmailManager _emailManager;

        public TaskAppService(IRepository<Task> taskRepository, IEmailManager emailManager)
        {
            _taskRepository = taskRepository;
            _emailManager = emailManager;
        }

        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .Include(t => t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }

        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _taskRepository.InsertAsync(task);

            if (input.AssignedPersonId.HasValue)
            {
                var targetTask = await _taskRepository
                .GetAll()
                .Include(t => t.AssignedPerson)
                .WhereIf(input.AssignedPersonId.HasValue, t => t.AssignedPersonId == input.AssignedPersonId.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

                await _emailManager.Assign(new TaskListDto()
                {
                    Title = input.Title,
                    AssignedPersonName = targetTask[0].AssignedPerson.Name
                }, "ziv.zhao@perficient.com");
            }
            
        }
    }
}