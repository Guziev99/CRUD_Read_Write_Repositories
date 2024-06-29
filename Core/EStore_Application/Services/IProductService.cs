using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Services
{
    public  interface IProductService
    {
        Task<IEnumerable<AllProductVM>> GetAllProductAsyncService(PaginationVM paginationVM);
        Task<AllProductVM> GetByIdAsyncService(int id);
        Task AddProductAsyncService(ProductVM product);
        Task UpdateProductAsyncService(ProductVM productVM);
        Task DeleteProductAsyncService(int id);

    }
}
