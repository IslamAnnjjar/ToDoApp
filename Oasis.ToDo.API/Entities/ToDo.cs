using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.ToDoAPP.API.Entities
{
    [Table("ToDos")]
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }

    }
}
