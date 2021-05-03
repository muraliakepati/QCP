using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using QCP.Trading.ProductManagement.DataAccessComponent.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCP.Trading.ProductManagement.DataAccessComponent.UnitOfWork
{
    /// <summary>
    /// Exposes the Unit Of Work to the outside world which will be used for transactions
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductManagementDbContext _context;

        public IUserRepository UserRepository { get; private set; }

        public ICustomerRepository CustomerRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }

        public UnitOfWork()
        {
            _context = new ProductManagementDbContext();

            UserRepository = new UserRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            ProductRepository = new ProductRepository(_context);
            OrderRepository = new OrderRepository(_context);
            SupplierRepository = new SupplierRepository(_context);
        }

        /// <summary>
        /// This can be called complete or AcceptChanges or whenever needed
        /// </summary>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Disposes the DB context
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
