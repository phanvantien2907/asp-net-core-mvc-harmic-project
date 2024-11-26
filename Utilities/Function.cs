    using System.Text;
using System.Security.Cryptography;

namespace WebApplication1.Utilities
{
    public class Function
    {
        public static int _UserID = 0;

        public static string _UserName = string.Empty;

        public static string _Email = string.Empty;

        public static string _Message = string.Empty;

        public static string _MessageEmail = string.Empty;

        public static string? TittleGenerationAlias(string tittle)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(tittle);
        }


        // gen ra mật khẩu md5 

        public static string? GetMD5(string? str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(str));
            byte[] result = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public static string? MD5Password(string? text)
        {
            string str = GetMD5(text);

            for(int i = 0; i < 5; i++)
            {
                str = GetMD5(str + "-" + str);
            }

            return str;
        }
    }
}
