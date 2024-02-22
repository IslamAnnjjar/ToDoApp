using Oasis.ToDoAPP.API.DTOs;
using Oasis.ToDoAPP.API.Entities;

namespace Oasis.ToDoAPP.API.Interfaces
{
    public interface IToDoRepository
    {
        Task<AppUser> GetAllAsync(int id);
        Task<ToDoDto> GetByIdAsync(int id);
        Task CreateAsync(ToDoDto toDo, int id);
        Task UpdateAsync(ToDoDto toDo, int id);
        Task DeleteToDoAsync(int id);
    }
}
