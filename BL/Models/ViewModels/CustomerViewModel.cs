using CCE.WebConnection.DAL.EntityClasses;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerEntity Customer { get; private set; }

        public CustomerViewModel(CustomerEntity customer)
        {
            Customer = customer;
        }
    }
}
