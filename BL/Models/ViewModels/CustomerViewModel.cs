using System.ComponentModel.DataAnnotations;
using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.BL.Models.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public int PkId { get; set; }

        [Required]
        public string Name { get; set; }

        public CustomerViewModel()
        {
            
        }

        public CustomerViewModel(ICustomer customer)
        {
            PkId = customer.PkId;
            Name = customer.Name;
        }
    }
}
