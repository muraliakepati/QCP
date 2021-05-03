using QCP.Trading.ProductManagement.DataAccessComponent.BusinessModels;
using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using System.Collections.Generic;

namespace QCP.Trading.ProductManagement.DataAccessComponent.IRepository
{
    public interface IOrderRepository: IRepository<PurchaseOrder>
    {
        IEnumerable<SalesModel> GetSalesByMonth();
    }
}
