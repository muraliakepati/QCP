using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;

namespace QCP.Trading.ProductManagement.DataAccessComponent.Repository
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProductManagementDbContext context) : base(context)
        {
        }

        private ProductManagementDbContext DbContext
        {
            get { return (Context as ProductManagementDbContext); }
        }
    }
}
