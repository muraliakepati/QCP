using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.UnitOfWork;

namespace QCP.Trading.ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var data = _unitOfWork.ProductRepository.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct([FromBody]dynamic product)
        {
            try
            {
                var productInfo = product.ToString().Replace(@"\", "");
                var _product = JsonConvert.DeserializeObject<Product>(productInfo);
                if (_product.Id > 0)
                    _unitOfWork.ProductRepository.Edit(_product);
                else
                    _unitOfWork.ProductRepository.Add(_product);

                _unitOfWork.Complete();
                return Ok(_product.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("GetTopSellingProducts")]
        public IActionResult GetTopSellingProducts()
        {
            try
            {
                var data = _unitOfWork.ProductRepository.GetTopSellingProducts();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}