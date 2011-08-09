namespace CCE.WebConnection.Common
{
    public static class Const
    {
        public static class Membership
        {
            public static int DEFAULT_PASSWORD_LENGTH = 7;
            public const string CONFIG_SECTION_STRING = "system.web/membership";
            public const string DEFAULT_PROVIDER = "CustomProvider"; 

            public enum MembershipValues
            {
                MinRequiredPasswordLength
            }
        }
    }
}
