

using Microsoft.AspNetCore.Identity;

namespace Oasis.ToDoAPP.API.Entities
{
    public class AppUser : IdentityUser
    {
        public new int Id { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}
