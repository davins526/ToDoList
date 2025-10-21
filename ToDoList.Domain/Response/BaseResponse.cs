using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Response;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public StatusCode StatusCode => throw new NotImplementedException();

    public T Data => throw new NotImplementedException();
}

public interface IBaseResponse<T>
{
    string Description { get; set; }

    StatusCode StatusCode { get; }
    T Data { get; }
}