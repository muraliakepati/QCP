using QCP.Trading.ProductManagement.DataAccessComponent.DataContext;

namespace QCP.Trading.ProductManagement.DataAccessComponent.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool ValidateUser(string userName, string password);
    }
}
