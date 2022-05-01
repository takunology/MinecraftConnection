using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Extends
{
    public static class Cast
    {
        public static double DataToDouble(this string response)
        {
            string result = response.Substring(response.IndexOf("data"));
            result = Regex.Replace(result, @"[^0-9-,.]", "");
            return double.Parse(result);
        }

        public static int DataToInt(this string response)
        {
            string result = response.Substring(response.IndexOf("data"));
            result = Regex.Replace(result, @"[^0-9-,.]", "");
            return int.Parse(result);
        }

        public static short DataToShort(this string response)
        {
            string result = response.Substring(response.IndexOf("data"));
            result = Regex.Replace(result, @"[^0-9-,.]", "");
            return short.Parse(result);
        }

        public static bool DataToBool(this string response)
        {
            string result = response.Substring(response.IndexOf("data"));
            result = Regex.Replace(result, @"[^0-9-,.]", "");
            if (result is "1") return true;
            else return false;
        }
    }
}
