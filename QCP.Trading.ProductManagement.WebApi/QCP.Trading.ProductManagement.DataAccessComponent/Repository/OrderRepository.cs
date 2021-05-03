using QCP.Trading.ProductManagement.DataAccessComponent.BusinessModels;
using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace QCP.Trading.ProductManagement.DataAccessComponent.Repository
{
    public class OrderRepository: Repository<PurchaseOrder>, IOrderRepository
    {
        public OrderRepository(ProductManagementDbContext context) : base(context)
        {
        }

        private ProductManagementDbContext DbContext
        {
            get { return (Context as ProductManagementDbContext); }
        }

        public IEnumerable<SalesModel> GetSalesByMonth()
        {
            return (from purchaseOrder in DbContext.PurchaseOrders
                    join customer in DbContext.Customers on purchaseOrder.CustomerId equals customer.Id
                    select new
                    {
                        purchaseOrder.Id,
                        purchaseOrder.OrderDate,
                        Month = purchaseOrder.OrderDate.ToString("MMMM"),
                        purchaseOrder.OrderDate.Year,
                        CustomerCountry = customer.Country,
                        OrderAmount = purchaseOrder.TotalAmount
                    }).AsEnumerable()
                    .GroupBy(item => new { item.Month, item.CustomerCountry })
                    .Select(group => new SalesModel()
                    {
                        Id = group.Select(x=>x.Id).FirstOrDefault(),
                        //OrderDate = group.Select(x => x.OrderDate).FirstOrDefault(),
                        Month = group.Key.Month,
                        //Year = group.Select(x => x.Year).FirstOrDefault(),
                        CustomerCountry = group.Select(x => x.CustomerCountry).FirstOrDefault(),
                        OrderAmount = group.Sum(x => Convert.ToDouble(x.OrderAmount))
                    }).OrderByDescending(x=>x.Year).ToList();
        }
    }
}
