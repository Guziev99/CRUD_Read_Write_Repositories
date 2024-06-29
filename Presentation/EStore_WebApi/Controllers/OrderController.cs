using Castle.Core.Resource;
using EStore_Application.Repositories.OrderRepos;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using EStore_Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStore_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IReadOrderRepository _readRepository;
        IWriteOrderRepository _writeRepository;
        public OrderController(IWriteOrderRepository writeRepository, IReadOrderRepository readRepository)
        {
            _writeRepository = writeRepository; 
            _readRepository = readRepository;
        }




        [HttpPost("AddOrder")]
        public async Task <IActionResult> AddAsync([FromBody] AllOrdersVM orderVM)
        {
            var neworder = new Order()
            {
                OrderNumber = orderVM.OrderNumber,
                OrderDate = orderVM.OrderDate,
                OrderNote = orderVM.OrderNote,
                TotalPrice = orderVM.TotalPrice,
                CustomerId = orderVM.CustomerId,
            };

            await _writeRepository.AddAsync(neworder);
            await _writeRepository.SaveChangeAsync();
            return StatusCode(201);
        }


        [HttpGet("GetAllOrders")]
        public async Task <IActionResult> GetAllAsync([FromQuery]PaginationVM paginationVM)
        {
            //var paginationAllOrders = await PaginationService<Order>.PaginationAsync(paginationVM);

            var products = await _readRepository.GetAllAsync();
            var productPagination =  products.Skip(paginationVM.Page * paginationVM.PageSize).Take(paginationVM.PageSize).ToList();

            var result = productPagination.Select(o => new AllOrdersVM()
            {
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                OrderNote = o.OrderNote,
                TotalPrice = o.TotalPrice,
                CustomerId = o.CustomerId,
            });
            return Ok(result);
        }

        [HttpGet("GetOrderById{id}")]
        public async Task <IActionResult> GetByIdAsync(int id) 
        {
            var order = await _readRepository.GetByIdAsync(id);
            return Ok(order);
        }


        [HttpPut("UpdateOrder/{id}")]
        public async Task <IActionResult> UpdateAsync(int id, [FromBody] AllOrdersVM orderVM)
        {

            var order = await _readRepository.GetByIdAsync(id);
            if (order == null) return NotFound($"{id} id -de Order bulunamadi !!");

            order.OrderNumber = orderVM.OrderNumber;
            order.OrderDate = orderVM.OrderDate;
            order.OrderNote = orderVM.OrderNote;
            order.TotalPrice = orderVM.TotalPrice;
            order.CustomerId = orderVM.CustomerId;

            
            await _writeRepository.UpdateAsync(order);
            await _writeRepository.SaveChangeAsync();

            return Ok(" Order Updated");
        }


        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            
            var order = _readRepository.GetByIdAsync( id);
            if(order == null) { return NotFound($" {3} id -li Order mevcut deyil !"); }

            await  _writeRepository.DeleteAsync(id);
            await _writeRepository.SaveChangeAsync();

            return StatusCode(204);
        }





























    }
}
