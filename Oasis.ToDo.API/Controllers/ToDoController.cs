using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oasis.ToDoAPP.API.DTOs;
using Oasis.ToDoAPP.API.Entities;
using Oasis.ToDoAPP.API.Extentions;
using Oasis.ToDoAPP.API.Interfaces;

namespace Oasis.ToDoAPP.API.Controllers
{
    [Authorize]
    public class ToDoController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("get-user-todolist")]
        public async Task<ActionResult<UserItemsDto>> GetUserToDoItems()
        {
            var userId = User.GetUserId();

            var todoItems = await _unitOfWork.ToDoRepository.GetAllAsync(userId);

            var itemsToReturn = _mapper.Map<UserItemsDto>(todoItems);

            return Ok(itemsToReturn);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<ToDoDto>> GetById(int id)
        {
            var todo = await _unitOfWork.ToDoRepository.GetByIdAsync(id);

            if(todo == null) return NotFound("A ToDo task doesn't exist");

            else return Ok(todo);
        }

        [HttpPost("add-todo")]
        public async Task<ActionResult> AddToDoItem(ToDoDto toDoDto)
        {
            var userId = User.GetUserId();

            await _unitOfWork.ToDoRepository.CreateAsync(toDoDto, userId);

            if (await _unitOfWork.Complete()) return Ok("A ToDo has been added successfully!");

            return BadRequest();

        }

        [HttpPut("update-todo/{id:int}")]
        public async Task<ActionResult> UpdateProduct(ToDoDto toDoDto, int id)
        {
            await _unitOfWork.ToDoRepository.UpdateAsync(toDoDto, id);

            if (await _unitOfWork.Complete()) return Ok("ToDo has been updated successfully");

            return BadRequest();
        }

        [HttpDelete("delete-todo/{id:int}")]
        public async Task<ActionResult> DeleteToDo(int id)
        {
            await _unitOfWork.ToDoRepository.DeleteToDoAsync(id);

            if (await _unitOfWork.Complete()) return Ok("ToDo deleted successfully");

            else return NotFound($"ToDo with Id = {id} not found");
            
        }
    }
}
