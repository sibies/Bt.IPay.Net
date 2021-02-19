using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
