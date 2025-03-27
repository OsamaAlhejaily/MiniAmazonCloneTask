using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ECommerceBackend.Services
{
   

    public class DapperService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<dynamic>> GetCustomerOrders(int userId)
        {
            var query = @"
            SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status,
                   p.Name AS ProductName, oi.Quantity, oi.Price
            FROM Orders o
            JOIN OrderItems oi ON o.OrderID = oi.OrderID
            JOIN Products p ON oi.ProductID = p.ProductID
            WHERE o.UserID = @UserId";

            using var connection = CreateConnection();
            return await connection.QueryAsync(query, new { UserId = userId });
        }

        public async Task<dynamic> GetProductById(int productId)
        {
            var query = "SELECT * FROM Products WHERE ProductID = @ProductId";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync(query, new { ProductId = productId });
        }
    }

}
