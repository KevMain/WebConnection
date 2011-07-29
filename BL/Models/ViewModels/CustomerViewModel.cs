using CCE.WebConnection.DAL.EntityContracts;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerID { get; private set; }
        public string CustomerName { get; set; }

        public CustomerViewModel(int customerID, string customerName)
        {
            CustomerID = customerID;
            CustomerName = customerName;
        }
    }
}
