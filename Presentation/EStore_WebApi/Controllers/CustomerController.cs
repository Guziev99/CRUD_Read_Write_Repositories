using EStore_Application.Repositories.CustomerRepos;
using EStore_Application.Repositories.ProductRepos;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EStore_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerReadRepository _readRepo;
        private IWriteCustomerRepository _writeRepo;
        public CustomerController(ICustomerReadRepository _repo, IWriteCustomerRepository _writeRepos)
        {
            _readRepo = _repo;
            _writeRepo = _writeRepos;
        }



        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationVM paginationVM)
        {
            var customers = await _readRepo.GetAllAsync();

            var customersOnPage = customers.Skip(paginationVM.Page * paginationVM.PageSize).Take(paginationVM.PageSize).ToList();

            var customerVMs = customersOnPage.ToList().Select(customer =>
                new AllCustomerVM()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Email = customer.Email,
                    Password = customer.Password,
                });

            return Ok(customerVMs);

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomer([FromBody] AllCustomerVM customerVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customer = new Customer()
            {
                FirstName = customerVM.FirstName,
                LastName = customerVM?.LastName,
                Address = customerVM?.Address,
                Email = customerVM?.Email,  
                Password = customerVM?.Password,
            };

            await _writeRepo.AddAsync(customer);
            await _writeRepo.SaveChangeAsync();

            return StatusCode(201);
        }


        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            if (!ModelState.IsValid) return BadRequest(id);

            var customer = await _readRepo.GetByIdAsync(id);

            var customerVM = new AllCustomerVM()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Email = customer.Email,
                Password = customer.Password,
            };

            return Ok(customerVM);
        }

        [HttpGet("GetCustomerByExpression")]  ///   Example uchun yazdim ki, sonra gerektiyinde yaratdigimi xatirlayam.
        public async Task<IActionResult> GetByExpression()
        {
            var customer = await _readRepo.GetByExpressionAsync(p => p.Id == 3);

            return Ok(customer);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] AllCustomerVM customerVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customer = await _readRepo.GetByIdAsync(id);
            if (customer == null) return NotFound($"{id}  id ile element bulunamadi");


            customer.FirstName = customerVM.FirstName;
            customer.LastName = customerVM.LastName;
            customer.Address = customerVM.Address;
            customer.Email = customerVM.Email;
            customer.Password = customerVM.Password;

            
            await _writeRepo.UpdateAsync(customer);
            await _writeRepo.SaveChangeAsync();

            return StatusCode(203);
        }

        [HttpPut("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _writeRepo.DeleteAsync(id);
            await _writeRepo.SaveChangeAsync();

            return Ok("Customer Has deleted");
        }










    }
}
