using Microsoft.Extensions.Logging;
using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels.Task;
using ToDoList.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Enum;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq;
using ToDoList.Domain.Extenstions;
using System.Collections.Generic;

namespace ToDoList.Service.Implementations;

public class TaskService : ITaskService
{
    private readonly IBaseRepository<TaskEntity> _taskRepository;
    private ILogger<TaskService> _logger;

    public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
    {
        try
        {
            model.Validate();

            _logger.LogInformation(message: $"Запрос  на создании задачи - {model.Name}");

            var task = await _taskRepository.GetAll()
               .Where(x => x.Created.Date == DateTime.Today)
               .FirstOrDefaultAsync(x => x.Name == model.Name);

            if (task != null)
            {
                return new BaseResponse<TaskEntity>()
                {
                    Description = "Задача с таким названием уже есть",
                    StatusCode = StatusCode.TaskIsHasAlready

                };

            }

            task = new TaskEntity()
            {
                Name = model.Name,
                Description = model.description,
                Priority = model.Priority,
                Created = DateTime.Now
            };
            await _taskRepository.Create(task);

            return new BaseResponse<TaskEntity>()
            {
                StatusCode = StatusCode.OK,
                Description = "Задача успешно создана"
            };

        }

        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при создании задачи - {model.Name}");
            return new BaseResponse<TaskEntity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.IntrenalServerEror
            };
        }

    }

    public async Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetTasks()
    {
        try
        {
            var tasks = await _taskRepository.GetAll()
                .Select(x => new TaskViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsDone = x.IsDone ? "Готова" : "Не готова",
                    Priority = x.Priority.GetDisplayName(),
                    Created = x.Created.ToLongDateString()
                })
                .ToListAsync();

            return new BaseResponse<IEnumerable<TaskViewModel>>()
            {
                Data = tasks,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[TaskService.GetTasks]: {ex.Message}");
            return new BaseResponse<IEnumerable<TaskViewModel>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.IntrenalServerEror
            };
        }
    }
}

