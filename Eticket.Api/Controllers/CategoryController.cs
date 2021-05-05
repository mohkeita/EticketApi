using Eticket.Api.Models.Dto;
using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryRepository CategoryRepository { get; }

        public CategoryController(CategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            return Ok(CategoryRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            
            Category category = CategoryRepository.Get(id);
            if (category == null)  
                return NotFound();
            

            return Ok(category);
        }
        
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            if (categoryDto is null || !ModelState.IsValid)
                return BadRequest();
            
            
            int id = CategoryRepository.Insert(new Category()
            {
                Name = categoryDto.Name
            });

            return Ok(id);
        }
        
        [HttpPut]
        [Authorize("admin")]
        public IActionResult EditCategory(Category category)
        {
            Category existCategory = CategoryRepository.Get(category.Id);
            if (existCategory == null)
                return NotFound();

            bool categoryUpdate = CategoryRepository.Update(category);

            return Ok(categoryUpdate);
        }
        
        [HttpDelete("{Id}")]
        [Authorize("admin")]
        public IActionResult DeleteCategory(int id)
        {
            Category existCategory = CategoryRepository.Get(id);
            if (existCategory == null)
                return NotFound();

            bool categoryDelete = CategoryRepository.Delete(id);

            return Ok(categoryDelete);
        }
        
    }
}