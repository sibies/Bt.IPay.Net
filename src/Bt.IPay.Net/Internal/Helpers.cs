using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Bt.IPay.Net.Constants;

namespace Bt.IPay.Net.Internal
{
    public static class Helpers
    {
        private static readonly Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static Dictionary<string, string> ToDictionary<T>(this T obj)
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    if (!(attr is DisplayAttribute displayAttribute)) continue;
                    var name = displayAttribute.Name;
                    var value = prop.GetValue(obj);
                    _dict.Add(name, value != null ? value.ToString() : string.Empty);
                }
            }

            return _dict;
        }

        public static string GetTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        public static string GetOnlyDigits(this string input)
        {
            return input.Where(char.IsDigit).Aggregate(string.Empty, (current, c) => current + c);
        }

        public static string FormatPhone(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            if (input.StartsWith("7") && input.Length < 10)
            {
                return "40" + input;
            }

            if (IsValidPhone(input))
            {
                return input;
            }

            if (input.StartsWith("004"))
            {
                input = input.Replace("004", "04");
                return input;
            }
            if (input.StartsWith("0"))
            {
                return "4" + input;
            }

            return ApiConsts.DefaultPhone;
        }

        private static bool IsValidPhone(string input)
        {
            var phoneCodes = new[]
            {
                "93", "355", "213", "1-684", "376", "244", "1-264", "672", "1-268", "54", "374", "297", "61", "43",
                "994", "1-242", "973", "880", "1-246", "375", "32", "501", "229", "1-441", "975", "591", "387", "267",
                "55", "673", "359", "226", "257", "855", "237", "1", "238", "1-345", "236", "235", "56", "86", "53",
                "61", "57", "269", "243", "242", "682", "506", "225", "385", "53", "357", "420", "45", "253", "1-767",
                "1-809", "1-829  ", "670", "593 ", "20", "503", "240", "291", "372", "251", "500", "298", "679", "358",
                "33", "594", "689", "241", "220", "995", "49", "233", "350", "30", "299", "1-473", "590", "1-671",
                "502", "224", "245", "592", "509", "504", "852", "36", "354", "91", "62", "98", "964", "353", "972",
                "39", "1-876", "81", "962", "7", "254", "686", "850", "82", "965", "996", "856", "371", "961", "266",
                "231", "218", "423", "370", "352", "853", "389", "261", "265", "60", "960", "223", "356", "692", "596",
                "222", "230", "269", "52", "691", "373", "377", "976", "1-664", "212", "258", "95", "264", "674", "977",
                "31", "599", "687", "64", "505", "227", "234", "683", "672", "1-670", "47", "968", "92", "680", "970",
                "507", "675", "595", "51", "63", "48", "351", "1-787", "1-939", "974 ", "262", "40", "7", "250", "290",
                "1-869", "1-758", "508", "1-784", "685", "378", "239", "966", "221", "248", "232", "65", "421", "386",
                "677", "252", "27", "34", "94", "249", "597", "268", "46", "41", "963", "886", "992", "255", "66",
                "690", "676", "1-868", "216", "90", "993", "1-649", "688", "256", "380", "971", "44", "1", "598", "998",
                "678", "418", "58", "84", "1-284", "1-340", "681", "967", "260", "263"
            };
            return phoneCodes.Any(input.StartsWith);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// </summary>
        public static string Truncate(this string str, int maxLength)
        {
            if (str == null)
                return string.Empty;
            return str.Length <= maxLength ? str : str.Left(maxLength);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="str" /> is null</exception>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="len" /> is bigger that string's length</exception>
        public static string Left(this string str, int len)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (str.Length < len)
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            return str.Substring(0, len);
        }

        private const string ValidEmailAddressPattern = "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,6}$";

        public static bool IsEmailValid(this string email)
        {
            var regex = new Regex(ValidEmailAddressPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        static string RemoveDiacritics(this string text)
        {
            if (text == null)
                return string.Empty;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string RemoveNewLines(this string text)
        {
            if (text == null)
                return string.Empty;
            var replacement = Regex.Replace(text, @"\t|\n|\r", string.Empty);
            return replacement;
        }

        public static string ToUtf8(this string text)
        {
            return text == null ? string.Empty : Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        }

        public static string NormalizeBt(this string text)
        {
            return text.RemoveNewLines().RemoveDiacritics().ToUtf8();
        }
    }
}
