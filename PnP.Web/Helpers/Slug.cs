using System.Text.RegularExpressions;

namespace PnP.Web.Helpers
{
    public class Slug
    {
        public static string Generate(string inputString)
        {
            return Regex.Replace(inputString, @"[^0-9a-zA-Z]", string.Empty);
        }
    }
}
