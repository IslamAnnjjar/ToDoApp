using Microsoft.EntityFrameworkCore;
using Oasis.ToDoAPP.API.DTOs;
using Oasis.ToDoAPP.API.Entities;
using Oasis.ToDoAPP.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;
using AutoMapper;

namespace Oasis.ToDoAPP.API.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ToDoRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(ToDoDto toDo, int id)
        {
            var todoItem = _mapper.Map<ToDo>(toDo);
            todoItem.UserId = id;
            _dataContext.Add(todoItem);
        }

        public async Task DeleteToDoAsync(int id)
        {
            var itemToDelete = _dataContext.ToDos.Find(id);
            if (itemToDelete != null) _dataContext.ToDos.Remove(itemToDelete);
        }

        public async Task<AppUser> GetAllAsync(int id)
        {
            var userWithProducts = await _dataContext.Users
                .Include(p => p.ToDos)
                .SingleOrDefaultAsync(u => u.Id == id);
            return userWithProducts;
        }

        public async Task<ToDoDto> GetByIdAsync(int id)
        {
            var todoItem = await _dataContext.ToDos.FindAsync(id);
            var todo = _mapper.Map<ToDoDto>(todoItem);
            return todo;
        }

        public async Task UpdateAsync(ToDoDto toDo, int id)
        {
            var itemToUpdate = _dataContext.ToDos.Find(id);
            itemToUpdate.Title = toDo.Title;
            itemToUpdate.IsCompleted = toDo.IsCompleted;
            _dataContext.Update(itemToUpdate);
        }
    }

}