using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Utilities;
using Tracker.Api.Context;
using Tracker.Entity.Entities;

namespace Tracker.Api.Controllers
{
    [ApiController]
    [Route("bills")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BillsController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BillsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Bills>>>> GetAll()
        {
            var result = _applicationDbContext.Billses.Where(x => x.Id > 0);
            var response = new List<Bills>();
            
            foreach (var item in result)
            {
                var category = await _applicationDbContext.Categories.FindAsync(item.CategoryId);
                item.Category = category;
                response.Add(item);
            }

            return new ApiResponse<IEnumerable<Bills>>
            {
                Data = response, Error = false, Message = "OK", StatusCode = 200
            };
        }


        [HttpGet("get/{id}")]
        public async Task<ActionResult<ApiResponse<Bills>>>Get(int id)
        {
            var result = await _applicationDbContext.Billses.FindAsync(id);

            return new ApiResponse<Bills>
            {
                Data = result, Error = false, Message = "Ok", StatusCode = 200
            };
        }

        [HttpPost("add")]
        public async Task<ActionResult<ApiResponse<bool>>> Add([FromBody] Bills bills)
        {
            await _applicationDbContext.Billses.AddAsync(bills);
            await _applicationDbContext.SaveChangesAsync();
            return new ApiResponse<bool>
            {
                Data = true, Error = false, Message = "Ok", StatusCode = 200
            };
        }
    }
}