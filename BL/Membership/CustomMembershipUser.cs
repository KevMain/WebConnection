using System;
using System.Web.Security;

namespace CCE.WebConnection.BL.Membership
{
    public class CustomMembershipUser : MembershipUser
    {
        public CustomMembershipUser(string providername, string username, object providerUserKey) : 
                                  base(providername,username, providerUserKey, String.Empty, String.Empty, String.Empty, true, false, new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime())
        {
            

        }
    }
}
