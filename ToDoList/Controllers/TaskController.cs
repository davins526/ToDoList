using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.ViewModels.Task;
using ToDoList.Service.Interfaces;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult>  Create(CreateTaskViewModel model)

        {
            var responce = await _taskService.Create(model);

            if(responce.StatusCode == Domain.Enum.StatusCode.OK)

            {

            return Ok(new {description = responce.Description});

            }

            return BadRequest(error:new { responce.Description });

        }

    }
}
