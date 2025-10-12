using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() // Конструктор класса AppDbContext
        {
            Database.EnsureCreated(); // С помощью этого метода будет создоваться БД при обращении.
        }

        public DbSet<TaskEntity> Tasks { get; set; }

    }   
}

