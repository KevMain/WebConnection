using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public interface IUserRepository : IRepository<IUser>
    {
        bool IsValidUser(string username, string password);
    }
}
