using CCE.WebConnection.DAL.EntityClasses;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomerViewModel
    {
        public string CustomerName { get; set; }

        public CustomerViewModel(CustomerEntity customer)
        {
            CustomerName = customer.Name;
        }
    }
}
