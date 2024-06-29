using EStore_Application.Repositories.CategoryRepos;
using EStore_Application.Repositories.ProductRepos;
using EStore_Application.Services;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Services
{
    public class ProductService : IProductService
    {

        private IReadProductRepository _readProductRepo;
        private IWriteProductRepository _writeProductRepo;
        private IReadCategoryRepository _readCategoryRepo;
        public ProductService(IReadProductRepository _repo, IWriteProductRepository _writeRepo, IReadCategoryRepository catReadRepo)
        {
            _readProductRepo = _repo;
            _writeProductRepo = _writeRepo;
            _readCategoryRepo = catReadRepo;
        }



        public async Task AddProductAsyncService(ProductVM productVm)
        {
            var product = new Product()
            {
                Name = productVm.Name,
                Description = productVm.Description,
                Stoke = productVm.Stoke,
                Price = productVm.Price,
                CategoryId = productVm.CategoryId,
            };
            await _writeProductRepo.AddAsync(product);
            await _writeProductRepo.SaveChangeAsync();
        }

        public async Task DeleteProductAsyncService(int id)
        {
            await _writeProductRepo.DeleteAsync(id);
            await _writeProductRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<AllProductVM>> GetAllProductAsyncService(PaginationVM paginationVM)
        {
           
            var products = await _readProductRepo.GetAllAsync();
            var paginatedProducts =  products.Paginate<Product>( paginationVM);

            

            var productVMs = paginatedProducts.ToList().Select(product =>
                new AllProductVM()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Stoke = product.Stoke,
                    CategoryName = product.Category.Name,
                });
            return productVMs;
        }

        public async Task<AllProductVM> GetByIdAsyncService(int id)
        {
            var product = await _readProductRepo.GetByIdAsync(id);

            var productVM = new AllProductVM()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stoke = product.Stoke,
                CategoryName = product?.Category.Name
            };

            return productVM;
        }

        public Task UpdateProductAsyncService(ProductVM productVM)
        {
            throw new NotImplementedException();
        }
    }
}
