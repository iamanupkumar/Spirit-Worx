using Core.Entities;
using Core.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
    {
        private readonly MainCategoryService _service;

        public MainCategoryController(MainCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllMaincategoryAsync")]
        public async Task<IActionResult> GetAllMaincategoryAsync()
        {
            var data = await _service.GetAllMaincategoryAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetMaincategoryByIdAsync")]
        public async Task<IActionResult> GetMaincategoryByIdAsync(int id)
        {
            var data = await _service.GetMaincategoryByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateMaincategoryAsync")]
        public async Task<IActionResult> CreateMaincategoryAsync([FromBody] MainCatagory catagory)
        {
            var  data = await _service.CreateMaincategoryAsync(catagory);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateMaincategoryAsync")]
        public async Task<IActionResult> UpdateMaincategoryAsync([FromBody] MainCatagory catagory)
        {
            var data = await _service.UpdateMaincategoryAsync(catagory);
            return Ok(data);
        }

        [HttpPut]
        [Route("DeleteMaincategoryAsync")]
        public async Task<IActionResult> DeleteMaincategoryAsync([FromBody] int id)
        {
            var data = await _service.DeleteMaincategoryAsync(id);
            return Ok(data);
        }
    }
}
