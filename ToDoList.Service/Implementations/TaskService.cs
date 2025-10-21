using Microsoft.Extensions.Logging;
using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels.Task;
using ToDoList.Service.Interfaces;

namespace ToDoList.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<TaskEntity> _taskRepository;
        private ILogger

        public TaskService(IBaseRepository<TaskEntity> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
