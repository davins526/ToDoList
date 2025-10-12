using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Entity
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
