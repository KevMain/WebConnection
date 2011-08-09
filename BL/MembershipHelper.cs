using System;
using System.Configuration;
using System.Web.Configuration;
using CCE.WebConnection.Common;

namespace CCE.WebConnection.BL
{
    public class MembershipHelper
    {
        //**********************************************************************************//
        //****************************        Return Ints      **************************//
        //**********************************************************************************//
        public static int GetSettingAsInt(Const.Membership.MembershipValues membershipValue)
        {
            return GetSettingAsInt(membershipValue, Null.NullInteger);
        }

        public static int GetSettingAsInt(Const.Membership.MembershipValues membershipValue, int defaultValue)
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
        //**********************************************************************************//



        //**********************************************************************************//
        //****************************        Return strings      **************************//
        //**********************************************************************************//
        public static string GetSetting(Const.Membership.MembershipValues membershipValue)
        {
            return GetSetting(membershipValue, String.Empty);
        }

        public static string GetSetting(Const.Membership.MembershipValues membershipValue, string defaultValue)
        {
            MembershipSection m = (MembershipSection)WebConfigurationManager.GetSection(Const.Membership.CONFIG_SECTION_STRING);

            ProviderSettings settings = m.Providers[Const.Membership.DEFAULT_PROVIDER];

            string strValue = settings.Parameters[membershipValue.ToString()];

            if(String.IsNullOrEmpty(strValue) && !String.IsNullOrEmpty(defaultValue))
            {
                strValue = defaultValue;
            }

            return strValue;
        }
        //**********************************************************************************//
    }
}
