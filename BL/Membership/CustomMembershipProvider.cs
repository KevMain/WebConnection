using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Security;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.Domain.Concrete;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.Common;
<<<<<<< HEAD
using CCE.WebConnection.DAL;
=======
>>>>>>> 34ef6c6b94c7b04c4eb3cd4bb3a10d0f43d3542c
using CCE.WebConnection.DAL.Abstract;

namespace CCE.WebConnection.BL.Membership
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public IUserRepository UserRepository { get; set; }
        public IMembershipSettings MembershipSettings { get; set; }
        
        public CustomMembershipProvider()
        {
            IEntitiesModel entitiesModel = IoCManager.Container().Resolve<IEntitiesModel>();
            UserRepository = IoCManager.Container().Resolve<IUserRepository>(entitiesModel);
            MembershipSettings = IoCManager.Container().Resolve<IMembershipSettings>();
        }

        public CustomMembershipProvider(IUserRepository userRepository, IMembershipSettings membershipSettings)
        {
            UserRepository = userRepository;
            MembershipSettings = membershipSettings;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return UserRepository.UpdatePassword(UserRepository.GetByUsername(username), newPassword);
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            return UserRepository.IsValidUser(username, password);
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return GetUser(UserRepository.GetByUsername(username));
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
<<<<<<< HEAD
            get
            {
                return MembershipSettings.MinRequiredPasswordLength;
            }
        }

=======
            get { return MembershipSettings.MinRequiredPasswordLength; }
        }


>>>>>>> 34ef6c6b94c7b04c4eb3cd4bb3a10d0f43d3542c
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }


        private CustomMembershipUser GetUser(IUser user)
        {
            return new CustomMembershipUser(Name, user.Username, user.PkId);
        }
    }
}
