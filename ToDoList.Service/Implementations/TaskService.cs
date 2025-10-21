using ToDoList.Domain.Entity;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels.Task;
using ToDoList.Service.Interfaces;

namespace ToDoList.Service.Implementations
{
    public class TaskService : ITaskService
    {
        public Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
