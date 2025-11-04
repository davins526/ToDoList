using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Filter.Task;
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

            return BadRequest(new { responce.Description });

        }

        public async Task<IActionResult> EndTask(long id)
        {
            var responce = await _taskService.EndTask(id);

            if (responce.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Ok(new { description = responce.Description });
            }
            return BadRequest(new { responce.Description });
        }





        [HttpPost]
        public async Task<IActionResult> TaskHandler(TaskFilter filter)
        {
            var response = await _taskService.GetTasks(filter);
            return Json(new { data = response.Data});
        }


    }

}
