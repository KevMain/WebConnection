namespace CCE.WebConnection.Common
{
    public class Utils
    {
        /// <summary>
        ///	 Checks to see if a string is an integer
        /// </summary>
        /// <return>Returns a the byte array </return>
        public static int SafeParseInt(string s)
        {
            var returnInt = Null.NullInteger;

            try
            {
                returnInt = int.Parse(s);
            }
            catch
            {
                //-- Catch errors and ignore
            }

            return returnInt;
        }

        public static int SetValueToDefaultIfLessThanZero(int currentValue, int defaultValue)
        {
            if (currentValue <= 0)
            {
                currentValue = defaultValue;
            }

            return currentValue;
        }
    }
}
