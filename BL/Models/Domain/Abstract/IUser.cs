
namespace CCE.WebConnection.BL.Models.Domain.Abstract
{
    public interface IUser : IDomain
    {
        int PkId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
