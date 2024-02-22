using Oasis.ToDoAPP.API.Entities;

namespace Oasis.ToDoAPP.API.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
