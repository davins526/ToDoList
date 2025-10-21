using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repositories;

public class TaskRepository : IBaseRepository<TaskEntity>
{
    public Task Create(TaskEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TaskEntity entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TaskEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<TaskEntity> Update(TaskEntity entity)
    {
        throw new NotImplementedException();
    }
}


