using System.Text;

namespace PhoneWord
{
    public static class PhoneNumberTranslator
    {

        /// <summary>
        /// To the number.
        /// </summary>
        /// <param name="raw">The raw.</param>
        /// <returns></returns>
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return string.Empty;
            else
                raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                if (" -0123456789".Contains(c))
                    newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                }
            }


            return newNumber.ToString();
        }


        /// <summary>
        /// Translates to number.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        private static object TranslateToNumber(char c)
        {
            if ("ABC".Contains(c))
                return 2;
            else if ("DEF".Contains(c))
                return 3;
            else if ("GHI".Contains(c))
                return 4;
            else if ("JKL".Contains(c))
                return 5;
            else if ("MNO".Contains(c))
                return 6;
            else if ("PQRS".Contains(c))
                return 7;
            else if ("TUV".Contains(c))
                return 8;
            else if ("WXYZ".Contains(c))
                return 9;

            return null;

        }


        /// <summary>
        /// Determines whether [contains] [the specified c].
        /// </summary>
        /// <param name="keyString">The key string.</param>
        /// <param name="c">The c.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified c]; otherwise, <c>false</c>.
        /// </returns>
        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

    }
}