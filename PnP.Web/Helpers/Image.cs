using System.Text;

namespace PnP.Web.Helpers
{
    public static class Image
    {
        public static string Generate(byte[] imageData, string imageType)
        {
            return $"data:{imageType};base64,{Encoding.UTF8.GetString(imageData, 0, imageData.Length)}";
        }
    }
}
