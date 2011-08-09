using System;
using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.Tests.Fakes
{
    public class FakeFormAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
        }

        public void SignOut()
        {
        }
    }
}
