using System;
using System.Web.Security;
using CCE.WebConnection.BL.Models.Domain.Abstract;

namespace CCE.WebConnection.Tests.Fakes
{
    public class FakeMembershipService : IMembershipService
    {
        public int MinPasswordLength
        {
            get { return 7; }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (userName == "username" && password == "password")
            {
                return true;
            }

            return false;
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (userName != "TestUser" || oldPassword != "password")
            {
                return false;
            }

            return true;
        }
    }
}
