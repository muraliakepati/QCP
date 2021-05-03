using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using System;
using System.Linq;

namespace QCP.Trading.ProductManagement.DataAccessComponent.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProductManagementDbContext context) : base(context)
        {
        }

        private ProductManagementDbContext DbContext
        {
            get { return (Context as ProductManagementDbContext); }
        }

        public bool ValidateUser(string userName, string password)
        {
            return DbContext.Users.Any(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password));
        }
    }
}
