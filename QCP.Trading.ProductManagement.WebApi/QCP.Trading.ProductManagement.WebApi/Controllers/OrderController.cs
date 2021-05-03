using System;
using Microsoft.AspNetCore.Mvc;
using QCP.Trading.ProductManagement.DataAccessComponent.UnitOfWork;

namespace QCP.Trading.ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetSalesByMonth")]
        public IActionResult GetSalesByMonth()
        {
            try
            {
                var data = _unitOfWork.OrderRepository.GetSalesByMonth();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}