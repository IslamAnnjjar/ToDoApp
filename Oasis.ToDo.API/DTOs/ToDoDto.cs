using Oasis.ToDoAPP.API.Entities;

namespace Oasis.ToDoAPP.API.DTOs
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
    }
}
