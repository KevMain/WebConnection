using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public interface IUserRepository : IRepository<IUser>
    {
        bool IsValidUser(string username, string password);
        IUser GetByUsername(string username);
        bool UpdatePassword(IUser user, string newPassword);
    }
}
