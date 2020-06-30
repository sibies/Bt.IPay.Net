using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
    }
}
