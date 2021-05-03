using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCP.Trading.ProductManagement.DataAccessComponent.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ProductManagementDbContext context) : base(context)
        {
        }

        private ProductManagementDbContext DbContext
        {
            get { return (Context as ProductManagementDbContext); }
        }
    }
}
