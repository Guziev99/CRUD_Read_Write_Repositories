using EStore_Application.Repositories.CategoryRepos;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using EStore_Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStore_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IWriteCategoryRepository _writeCategoryRepository;
        private IReadCategoryRepository _readCategoryRepository;
        public CategoryController( IWriteCategoryRepository repoWrite, IReadCategoryRepository readCategoryRepository)
        {
            _writeCategoryRepository = repoWrite;
            _readCategoryRepository = readCategoryRepository;

        }


        // Addcategory
        [HttpPost("[action]")]
        public async Task <IActionResult> AddCategory([FromBody]CategoryVM categoryVM) 
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var newcategory = new Category()
            {
                Name = categoryVM.Name,
                Description = categoryVM.Description,
            };

            await _writeCategoryRepository.AddAsync(newcategory);
            await _writeCategoryRepository.SaveChangeAsync();
            return StatusCode(201);
        }


        [HttpGet("GetAllCategories")]
        public async Task < IActionResult> GetAll([FromQuery] PaginationVM paginationVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);



           // var allCategories = await _readCategoryRepository.GetAllAsync();

           // var categoriesOnPage = allCategories.ToList().Skip(paginationVM.Page * paginationVM.PageSize ).Take(paginationVM.PageSize);

            var categoriesOnPage = await PaginationService<Category>.PaginationAsync(paginationVM);
            var categoryVmPages = categoriesOnPage?.Select(c =>

                new AllCategoryVM()
                {
                    Name = c.Name, 
                    Description = c.Description,
                }
                );

            return Ok(categoryVmPages );
        }


        [HttpGet("GetCategoryById/{id}")]
        public async Task <IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = await _readCategoryRepository.GetByIdAsync(id);
            return Ok(category);
        }




        [HttpPut("UpdateCategory/{id}")]
        public async Task <IActionResult> UpdateCategory(int id, [FromBody] CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var category = await _readCategoryRepository.GetByIdAsync(id);
            if(category == null) return NotFound($"{id} id 'sinde category bulunamadi !!");

            category.Name = categoryVM.Name;
            category.Description = categoryVM.Description;


            await _writeCategoryRepository.UpdateAsync(category);
            await _writeCategoryRepository.SaveChangeAsync();

            return Ok(" Category has Updated");
        }

        [HttpDelete("DeleteCategory")]
        public async Task <IActionResult> DeleteById(int id)
        {
            var category = await _readCategoryRepository.GetByIdAsync(id);
            if(category == default) return NotFound(id);

            await _writeCategoryRepository?.DeleteAsync(id);
            await _writeCategoryRepository.SaveChangeAsync();

            return Ok("Deleted Category");
        }




        [HttpGet("GetAllProdsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProdsByCat(int categoryId)
        {
            var products = await _readCategoryRepository.GetAllProductsWithCategoryId(categoryId);
            if (products == null) return NotFound("Hech bir product tapilmadi");

            var AllProdsVm = products.Select(c => new AllProductVM()
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                Stoke = c.Stoke,
                CategoryName = c.Category.Name,
                ImageUrl = c.ImageUrl,

            }).ToList();


            return Ok(AllProdsVm);
        }






    }

}
