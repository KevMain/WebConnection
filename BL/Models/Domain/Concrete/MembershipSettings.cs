using System.Configuration;
using System.Web.Configuration;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.Common;

namespace CCE.WebConnection.BL.Models.Domain.Concrete
{
    public class MembershipSettings : IMembershipSettings
    {
        #region CONSTS

        private const int DEFAULT_PASSWORD_LENGTH = 7;

        #endregion

        #region Public Properties

        public int MinRequiredPasswordLength
        {
            get { return GetSettingValue(MembershipValue.MinRequiredPasswordLength, DEFAULT_PASSWORD_LENGTH); }
        }
       
        #endregion

        #region Private Methods

        /// <summary>
        /// Values enum
        /// </summary>
        private enum MembershipValue
        {
            MinRequiredPasswordLength
        }

        private int GetSettingValue(MembershipValue membershipValue)
        {
            return GetSettingValue(membershipValue, Null.NullInteger);
        }

        private int GetSettingValue(MembershipValue membershipValue, int defaultValue)
        {
            MembershipSection m = (MembershipSection)WebConfigurationManager.GetSection(Const.Membership.CONFIG_SECTION_STRING);

            ProviderSettings settings = m.Providers[Const.Membership.DEFAULT_PROVIDER];

            int iValue = Utils.SafeParseInt(settings.Parameters[membershipValue.ToString()]);

            if (iValue <= 0 && defaultValue != Null.NullInteger)
            {
                iValue = defaultValue;
            }

            return iValue;
        }

        #endregion
    }
}
