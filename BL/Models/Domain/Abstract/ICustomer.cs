
namespace CCE.WebConnection.BL.Models.Domain.Abstract
{
    public interface ICustomer : IDomain
    {
        int PkId { get; set; }
        string Name { get; set; }
    }
}
