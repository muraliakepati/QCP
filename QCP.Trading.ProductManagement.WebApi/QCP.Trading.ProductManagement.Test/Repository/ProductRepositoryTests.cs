using Microsoft.EntityFrameworkCore;
using Moq;
using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace QCP.Trading.ProductManagement.Test.Repository
{
    public class ProductRepositoryTests
    {
        private Mock<ProductManagementDbContext> productManagementDbContext;
        private ProductRepository target;

        public ProductRepositoryTests()
        {
            productManagementDbContext = new Mock<ProductManagementDbContext>();
            target = new ProductRepository(productManagementDbContext.Object);
        }

        [Fact]
        public void ShouldGetTopSellingProducts()
        {
            //Arrange
            Product productOne = new Product()
            {
                Id = 1,
                ProductName = "Coinbase",
                SupplierId = 1,
                Package = "test",
                UnitPrice = 10,
                IsDiscontinued = true
            };
            Product productTwo = new Product()
            {
                Id = 2,
                ProductName = "AltCoin",
                SupplierId = 1,
                Package = "test",
                UnitPrice = 10,
                IsDiscontinued = true
            };

            var products = new List<Product>() { productOne, productOne }.AsQueryable();

            var mockProducts = new Mock<DbSet<Product>>();
            mockProducts.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockProducts.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockProducts.Setup(m => m.Include(It.IsAny<string>())).Returns(mockProducts.Object);

            var orderItems= new List<OrderItem>() { }.AsQueryable();

            var mockOrderItems = new Mock<DbSet<OrderItem>>();
            mockOrderItems.As<IQueryable<OrderItem>>().Setup(m => m.Provider).Returns(orderItems.Provider);
            mockOrderItems.As<IQueryable<OrderItem>>().Setup(m => m.Expression).Returns(orderItems.Expression);
            mockOrderItems.Setup(m => m.Include(It.IsAny<string>())).Returns(mockOrderItems.Object);

            var purchaseOrders = new List<PurchaseOrder>() { }.AsQueryable();

            var mockOrders = new Mock<DbSet<PurchaseOrder>>();
            mockOrders.As<IQueryable<PurchaseOrder>>().Setup(m => m.Provider).Returns(purchaseOrders.Provider);
            mockOrders.As<IQueryable<PurchaseOrder>>().Setup(m => m.Expression).Returns(purchaseOrders.Expression);
            mockOrders.Setup(m => m.Include(It.IsAny<string>())).Returns(mockOrders.Object);

            var customers = new List<Customer>() { }.AsQueryable();

            var mockCustomers = new Mock<DbSet<Customer>>();
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockCustomers.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockCustomers.Setup(m => m.Include(It.IsAny<string>())).Returns(mockCustomers.Object);

            var suppliers = new List<Supplier>() { }.AsQueryable();

            var mockSuppliers = new Mock<DbSet<Supplier>>();
            mockSuppliers.As<IQueryable<OrderItem>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            mockSuppliers.As<IQueryable<OrderItem>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            mockSuppliers.Setup(m => m.Include(It.IsAny<string>())).Returns(mockSuppliers.Object);

            productManagementDbContext.Setup(m => m.Products).Returns(mockProducts.Object);
            productManagementDbContext.Setup(m => m.OrderItems).Returns(mockOrderItems.Object);
            productManagementDbContext.Setup(m => m.PurchaseOrders).Returns(mockOrders.Object);
            productManagementDbContext.Setup(m => m.Customers).Returns(mockCustomers.Object);
            productManagementDbContext.Setup(m => m.Suppliers).Returns(mockSuppliers.Object);

            //Act
            var result = target.GetTopSellingProducts();

            //Assert
            Assert.True(result.ToList().Count() == 0);
        }
    }
}
