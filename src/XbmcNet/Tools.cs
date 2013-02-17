using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace XbmcNet
{
    internal static class Tools
    {
        /// <summary>
        ///     Returns a pseudo-random string of the specified length, containing alpha-numeric characters.
        /// </summary>
        /// <param name="length">Desired length of the resulting string.</param>
        public static string GenerateString(int length = 16)
        {
            var r = new Random();
            string result = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (int i = 0; i < length; i++)
            {
                result += chars[r.Next(0, chars.Length)];
            }

            return result;
        }

        /// <summary>
        ///     Returns the JSON property names of all public properties in the specified class.
        /// </summary>
        public static string[] GetAllProperties<T>()
        {
            return typeof (T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                .Select(p => Attribute.GetCustomAttribute(p, typeof (JsonPropertyAttribute)))
                .OfType<JsonPropertyAttribute>()
                .Select(a => a.PropertyName)
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray();
        }
    }
}