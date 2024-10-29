using backendPizzaria.DALs.Category;
using backendPizzaria.DALs.Product;
using backendPizzaria.Data.Persistence;
using backendPizzaria.DTOs.Category;
using backendPizzaria.DTOs.Product;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendPizzaria.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryDal _categoryDal;

        public CategoryController(CategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var categories = await _categoryDal.GetAllAsync();

            var categoriesDto = categories.Select(c => new CategoryDto
            {
                Description = c.Description,
            }).ToList();

            return Ok(categoriesDto);
        }

        [HttpGet("FindCategory/{id}")]

        public async Task<ActionResult<CategoryDto>> FindById(int id)
        {
            var category = _categoryDal.GetById(id);

            if (category== null)
            {
                return NotFound("Categoria não encontrado.");
            }

            return Ok(category);
        }

        [HttpPost]

        public async Task<ActionResult> CreateCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = new CategoryModel
                {
                    Description = categoryDto.Description,
                };

                await _categoryDal.AddAsync(category);
                return Ok("Categoria criada");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _productDAL.GetProductById(id);
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _productDAL.DeleteProduct(id);
            return NoContent();
        }






    }
}
