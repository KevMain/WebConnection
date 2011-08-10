using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.BL.Models.Domain.Concrete
{
    public class Customer : ICustomer
    {
        public int PkId { get; set; }

        public string Name { get; set; }
    }
}
