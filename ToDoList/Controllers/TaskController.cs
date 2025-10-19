using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.ViewModels.Task;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Create(CreateTaskViewModel model)
        {
            return Ok();
        }

    }
}
