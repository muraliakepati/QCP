using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.UnitOfWork;

namespace QCP.Trading.ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var data = _unitOfWork.CustomerRepository.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("SaveCustomer")]
        public IActionResult SaveCustomer([FromBody]dynamic customer)
        {
            try
            {
                var custommerInfo = customer.ToString().Replace(@"\", "");
                var _customer = JsonConvert.DeserializeObject<Customer>(custommerInfo);
                if (_customer.Id > 0)
                    _unitOfWork.CustomerRepository.Edit(_customer);
                else
                    _unitOfWork.CustomerRepository.Add(_customer);

                _unitOfWork.Complete();
                return Ok(_customer.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}