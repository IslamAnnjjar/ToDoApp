using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oasis.ToDoAPP.API.Interfaces;

namespace Oasis.ToDoAPP.API.Controllers
{
    [Authorize]
    public class LiveToDoController : BaseApiController
    {
        private readonly IToDoApiService _toDoApiService;
        string BaseUrl = "https://jsonplaceholder.typicode.com/todos";

        public LiveToDoController(IToDoApiService toDoApiService)
        {
            _toDoApiService = toDoApiService;
        }

        [HttpGet("get-live-todo")]
        public async Task<ActionResult> GetToDoList()
        {
            
            var responseContent = await _toDoApiService.ConsumeToDoApiAsync();
            if (responseContent != null)
            {
                return Ok(responseContent);
            }
            else 
                return BadRequest();
        }
    }
}
