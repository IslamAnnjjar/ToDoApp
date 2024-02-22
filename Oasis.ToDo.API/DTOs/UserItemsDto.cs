namespace Oasis.ToDoAPP.API.DTOs
{
    public class UserItemsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<ToDoDto> ToDos { get; set; }
    }
}
