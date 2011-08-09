namespace CCE.WebConnection.BL.Models.Domain.Abstract
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}
