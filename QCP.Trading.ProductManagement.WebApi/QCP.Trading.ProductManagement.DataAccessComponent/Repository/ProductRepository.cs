using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using QCP.Trading.ProductManagement.DataAccessComponent.BusinessModels;
using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace QCP.Trading.ProductManagement.DataAccessComponent.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementDbContext context) : base(context)
        {
        }

        private ProductManagementDbContext DbContext
        {
            get { return (Context as ProductManagementDbContext); }
        }

        public override IEnumerable<Product> GetAll()
        {
            return DbContext.Products.Include("Supplier").Select(x => x).ToList();
        }

        public IEnumerable<ProductModel> GetTopSellingProducts()
        {
            return (from product in DbContext.Products
                        join orderItem in DbContext.OrderItems on product.Id equals orderItem.ProductId
                        join order in DbContext.PurchaseOrders on orderItem.OrderId equals order.Id
                        join customer in DbContext.Customers on order.CustomerId equals customer.Id
                        join supplier in DbContext.Suppliers on product.SupplierId equals supplier.Id
                        select new ProductModel()
                        {
                            ProductId = product.Id,
                            ProductName = product.ProductName,
                            SupplierName = supplier.CompanyName,
                            UnitPrice=product.UnitPrice,
                            Package=product.Package,
                            IsDiscontinued=product.IsDiscontinued,
                            Country=customer.Country,
                            OrdersValue = (double)(orderItem.Quantity*orderItem.UnitPrice)
                            }).AsEnumerable()
                            .GroupBy(item => new { item.ProductId, item.Country })
                        //}).GroupBy(item =>  item.ProductId)
                       .Select(group => new ProductModel()
                       {
                           ProductId = group.Key.ProductId,
                           ProductName = group.Select(x=>x.ProductName).FirstOrDefault(),
                           SupplierName = group.Select(x => x.SupplierName).FirstOrDefault(),
                           UnitPrice = group.Select(x => x.UnitPrice).FirstOrDefault(),
                           Package = group.Select(x => x.Package).FirstOrDefault(),
                           IsDiscontinued = group.Select(x => x.IsDiscontinued).FirstOrDefault(),
                           Country = group.Key.Country,
                           Orders = group.Count(),
                           OrdersValue=group.Sum(x=>x.OrdersValue)
                       }).OrderByDescending(x=>x.Orders)
                       .ToList();
        }
    }
}
