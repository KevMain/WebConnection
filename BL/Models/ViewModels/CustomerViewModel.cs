using System.ComponentModel.DataAnnotations;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public CustomerViewModel()
        {
        }

        public CustomerViewModel(int customerID, string customerName)
        {
            CustomerID = customerID;
            CustomerName = customerName;
        }
    }
}
