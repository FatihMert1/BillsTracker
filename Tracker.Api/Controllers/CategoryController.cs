using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.Api.Context;
using Tracker.Entity.Entities;

namespace Tracker.Api.Controllers
{
    [ApiController]
    [Route("category")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse<List<Category>>>> GetAll()
        {
            var result = await _applicationDbContext.Categories.ToListAsync();

            return new ApiResponse<List<Category>>
            {
                Data = result, Error = false, Message = "Ok", StatusCode = 200
            };
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ApiResponse<Category>>> Get(int id)
        {
            var result = await _applicationDbContext.Categories.FindAsync(id);
            
            return new ApiResponse<Category>
            {
                Data = result, Error = false, Message = "Ok", StatusCode = 200
            };
        }

        [HttpPost("add")]
        public async Task<ActionResult<ApiResponse<bool>>> Add([FromBody] Category category)
        {
            await _applicationDbContext.Categories.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();

            return new ApiResponse<bool>
            {
                Data = true, Error = false, Message = "Ok", StatusCode = 200
            };
        }
    }
}