using CCE.WebConnection.BL.Models.ViewModels;

namespace CCE.WebConnection.BL.Repository.Abstract
{
    public interface ICustomersRepository
    {
        CustomersViewModel GetAll();
        CustomerViewModel GetByID(int customerID);
    }
}