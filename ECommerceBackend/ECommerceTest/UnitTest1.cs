namespace ECommerceBackend.Repositories
{
    using ECommerceBackend.Data;
    using ECommerceBackend.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;


    public class Test
    {
        [Fact]
        public async Task GetOrdersByUserId_ReturnsOrders()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb1").Options;

            using var context = new AppDbContext(options);
            context.Orders.Add(new Order { UserID = 1, TotalAmount = 99.99m, Status = "Processing" });
            context.Orders.Add(new Order { UserID = 2, TotalAmount = 50, Status = "Completed" });
            await context.SaveChangesAsync();

            var repo = new OrderRepository(context);
            var result = await repo.GetOrdersByUserId(1);

            Assert.Single(result);
        }

        [Fact]
        public async Task AddOrder_AddsOrder()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb2").Options;

            using var context = new AppDbContext(options);
            var repo = new OrderRepository(context);

            var order = new Order { UserID = 1, TotalAmount = 150, Status = "Pending" };
            await repo.AddOrder(order);

            Assert.Equal(1, context.Orders.Count());
        }

    }
}