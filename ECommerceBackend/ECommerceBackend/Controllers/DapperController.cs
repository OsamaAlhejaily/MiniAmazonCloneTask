using ECommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DapperController : ControllerBase
    {
        private readonly DapperService _dapper;

        public DapperController(DapperService dapper)
        {
            _dapper = dapper;
        }

        [HttpGet("orders/{userId}")]
        public async Task<IActionResult> GetCustomerOrders(int userId)
        {
            var orders = await _dapper.GetCustomerOrders(userId);
            return Ok(orders);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _dapper.GetProductById(id);
            return product != null ? Ok(product) : NotFound();
        }
    }

}
