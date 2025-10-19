using ToDoList.Domain.Enum;

namespace ToDoList.Domain.ViewModels.Task
{
    public class CreateTaskViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public Priority Priority { get; set; }
    }
}
