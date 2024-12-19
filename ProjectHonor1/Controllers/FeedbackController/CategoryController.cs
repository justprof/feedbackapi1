using Microsoft.AspNetCore.Mvc;
using ProjectHonor1.Dtos.GetCategoryDtos;

using ProjectHonor1.Repositories.GetCategoryDtos;

namespace ProjectHonor1.Controllers.FeedbackController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //GET: api/category
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
          {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
          }

        //GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDto>> GetCategoryById(int id)
        {
            var category=await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //POST: api/category
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] GetCategoryDto getcategoryDto)
        {
            await _categoryRepository.AddAsync(getcategoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = getcategoryDto.Id }, getcategoryDto);
        }

        //DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return NoContent();
        }







            
    }
    

}
