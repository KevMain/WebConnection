using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.BL.Models.Domain.Concrete
{
    public class User : IUser 
    {
        public int PkId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
