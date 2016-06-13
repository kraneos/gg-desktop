using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Seggu.Helpers
{
    public static class StringExtensions
    {

        public static bool isTextNumber(int caracter)
        {
            if ( (caracter > 47 && caracter < 58) || caracter == 8) return true;
            return false;
        }

        public static bool isTextLetter(int caracter)
        {
            if ((caracter > 64 && caracter < 91) || (caracter > 96 && caracter < 123) || caracter == 8 || caracter == 32) return true;
            return false;
        }

        public static bool isLetter(this char c)
        {
            if (char.IsLetter(c)) return true;
            return false;
        }

        public static bool isNumber(this char c)
        {
            if (char.IsNumber(c)) return true;
            return false;
        }

        public static bool AreAllNumbers(this string str)
        {
            foreach (char c in str)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreAllLetters(this string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public static int ToInt(this string str)
        {
            var i = 0;
            int.TryParse(str, out i);
            return i;
        }

        public static DateTime? ToNullableDateTime(this string str)
        {
            var date = DateTime.MinValue;
            DateTime.TryParse(str, out date);
            return date == DateTime.MinValue ? (DateTime?)null : date;
        }

        public static DateTime ToDateTime(this string str)
        {
            var date = DateTime.MinValue;
            DateTime.TryParse(str, out date);
            return date;
        }

        public static Guid ToGuid(this string str)
        {
            var guid = Guid.Empty;
            Guid.TryParse(str, out guid);
            return guid;
        }

        public static string RemoveAll(this string str, params string[] valuesToRemove)
        {
            foreach (var valueToRemove in valuesToRemove)
            {
                str = str.Replace(valueToRemove, string.Empty);
            }

            return str;
        }

        public static bool IsPlateNumber(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            else
            {
                var parts = str.Split('-');
                if (parts.Length != 2)
                {
                    return false;
                }
                else
                {
                    if (parts[0].Length != 3 || !parts[0].AreAllLetters())
                    {
                        return false;
                    }
                    else if (parts[1].Length != 3 || !parts[1].AreAllNumbers())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether this instance is a valid Vehicle Identification Number.
        /// </summary>
        /// <param name="str">The string to evaluate.</param>
        /// <returns></returns>
        public static bool IsVIN(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            else
            {
                var regex = new Regex(@"^(([a-h,A-H,j-n,J-N,p-z,P-Z,0-9]{9})([a-h,A-H,j-n,J-N,p,P,r-t,R-T,v-z,V-Z,0-9])([a-h,A-H,j-n,J-N,p-z,P-Z,0-9])(\d{6}))$");
                var match = regex.Match(str);
                return match.Success;
            }
        }
    }
}
