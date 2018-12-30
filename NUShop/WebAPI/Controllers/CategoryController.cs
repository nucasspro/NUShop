using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _logger.LogInformation("Start HttpGet GetCategories() - CategoryController");
            var categories = _categoryService.GetAll();
            if (categories == null)
            {
                _logger.LogInformation("Categories null");
                return NotFound();
            }
            _logger.LogInformation("End HttpGet GetCategories() - CategoryController");

            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var newCategory = _categoryService.Add(category);
            return Ok(newCategory);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var newCategory = _categoryService.Update(category);
            return Ok(newCategory);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}