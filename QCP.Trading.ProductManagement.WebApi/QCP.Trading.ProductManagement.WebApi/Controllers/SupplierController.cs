using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QCP.Trading.ProductManagement.DataAccessComponent.UnitOfWork;

namespace QCP.Trading.ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllSuppliers")]
        public IActionResult GetAllSuppliers()
        {
            try
            {
                var data = _unitOfWork.SupplierRepository.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}