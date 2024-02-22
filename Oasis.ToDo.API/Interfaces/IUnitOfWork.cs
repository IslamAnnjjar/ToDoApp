namespace Oasis.ToDoAPP.API.Interfaces
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDoRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
