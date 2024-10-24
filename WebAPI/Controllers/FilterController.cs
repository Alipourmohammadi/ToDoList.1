using Microsoft.AspNetCore.Mvc;
using ToDoList.Applications.Interfaces;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : ControllerBase
    {
        private readonly IFilterService _filterservice;
        public FilterController(IFilterService filterService)
        {
            _filterservice = filterService;
        }
        [HttpGet("filterBy")]
        public async Task<IActionResult> GetDone([FromQuery] bool done, [FromQuery] DateTime time)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please provide all required fields");

            try
            {
                var result = await _filterservice.FilterBy(done, time);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
