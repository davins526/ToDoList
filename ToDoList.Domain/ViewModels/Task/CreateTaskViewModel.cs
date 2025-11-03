using System.Diagnostics.CodeAnalysis;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.ViewModels.Task;

public class CreateTaskViewModel
{
    public string Name { get; set; }
    public string description { get; set; }
    public Priority Priority { get; set; }

    public void Validate()
    {
        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(Name, message:"Укажите название и описание задачи ");
        }
    }
}