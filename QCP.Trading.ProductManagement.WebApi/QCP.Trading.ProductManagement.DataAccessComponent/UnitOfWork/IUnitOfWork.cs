using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using System;

namespace QCP.Trading.ProductManagement.DataAccessComponent.UnitOfWork
{
    /// <summary>
    /// Will expose each of the individual repositories through this unit of work
    /// This is a separeate implementation of the Enitity Framework Core own UoW for loosly coupling
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository UserRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        int Complete();
    }
}
