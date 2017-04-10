using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUtils
{
    public class CryptoUtils
    {
        public static String Sha1StringOf(byte[] input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(input);
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static String Md5StringOf(byte[] input)
        {
            using (var md5 = MD5.Create())
            {
                var hash_md5 = md5.ComputeHash(input);
                var sb = new StringBuilder(hash_md5.Length * 2);

                foreach (byte b in hash_md5)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
