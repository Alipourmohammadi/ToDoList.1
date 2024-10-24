using Microsoft.AspNetCore.Mvc;
using ToDoList.Applications.DTOs;
using ToDoList.Applications.Interfaces;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _ToDoService;

        public ToDoController(IToDoService toDoService)
        {
            _ToDoService = toDoService;
        }

        [HttpPost("add-ToDo")]
        public async Task<IActionResult> AddToDo([FromBody] ToDoDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is Invalid!");
            try
            {
                var result = await _ToDoService.AddNewToDo(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Edit-ToDo/{id}")]
        public async Task<IActionResult> EditToDo(Guid id, [FromBody] ToDoDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is Invalid!");
            try
            {
                await _ToDoService.EditToDo(id, input);
                return Ok("done");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete-ToDo/{id}")]
        public async Task<IActionResult> DeleteToDo(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is Invalid!");
            try
            {
                await _ToDoService.RemoveToDo(id);
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-ToDo")]
        public async Task<IActionResult> GetToDo()
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is Invalid!");
            try
            {
                var result = await _ToDoService.GetToDoList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("set-State")]
        public async Task<IActionResult> setState(Guid id, [FromBody] bool isDone)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is Invalid!");
            try
            {
                await _ToDoService.setToDoStatus(id, isDone);
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
