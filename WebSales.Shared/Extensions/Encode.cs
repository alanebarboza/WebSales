using System.Text;

namespace WebSales.Shared.Extensions
{
    public static class Encode
    {
        public static string StringEncode(this string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
