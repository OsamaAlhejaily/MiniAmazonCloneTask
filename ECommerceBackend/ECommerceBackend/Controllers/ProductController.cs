namespace ECommerceBackend.Controllers
{
    using global::ECommerceBackend.Data;
    using global::ECommerceBackend.Dtos;
    using global::ECommerceBackend.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    namespace ECommerceBackend.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ProductController : ControllerBase
        {
            private readonly AppDbContext _context;

            public ProductController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet("/products")]
            public async Task<IActionResult> GetProducts()
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }

            [Authorize(Roles = "Admin")]
            [HttpPost("add")]
            public async Task<IActionResult> AddProduct([FromBody] ProductAddDto dto)
            {
               
                var email = User.FindFirstValue(ClaimTypes.Email);

               
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null) return Unauthorized();

                var product = new Product
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    Stock = dto.Stock,
                    CreatedBy = user.UserID 
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok("Product added");
            }



            [Authorize(Roles = "Admin")]
            [HttpPut("update/{id}")]
            public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto dto)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.Stock = dto.Stock;

                await _context.SaveChangesAsync();
                return Ok("Product updated");
            }

        }
    }

}
