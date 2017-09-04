using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUtils
{
    public static class CryptoStrings
    {
        /// <summary>
        ///     Computes the sha1 hash of a given array of bytes and converts it to a 
        ///     lowercase hex string
        /// </summary>
        /// <param name="input">
        ///     Array of bytes which is to be digested
        /// </param>
        /// <remarks>
        ///     To be used with small size files
        /// </remarks>
        /// <returns>
        ///     The sha1 digest of the input array of bytes
        /// </returns>
        public static string Sha1StringOf(byte[] input)
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

        /// <summary>
        ///     Computes the sha1 hash of a file, given its stream, and converts it to a 
        ///     lowercase hex string
        /// </summary>
        /// <param name="fileStream">
        ///     Stream of the file to be digested
        /// </param>
        /// <remarks>
        ///     To be used with larger size files
        /// </remarks>
        /// <returns>
        ///     The sha1 digest of the input file stream
        /// </returns>
        public static string Sha1StringOf(Stream fileStream)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash_sha1 = sha1.ComputeHash(fileStream);
                var sb = new StringBuilder(hash_sha1.Length * 2);

                foreach (byte b in hash_sha1)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        ///     Computes the md5 hash of a given array of bytes and converts it to a 
        ///     lowercase hex string
        /// </summary>
        /// <param name="input">
        ///     Array of bytes which is to be digested
        /// </param>
        /// <remarks>
        ///     To be used with small size files
        /// </remarks>
        /// <returns>
        ///     The md5 digest of the input array of bytes
        /// </returns>
        public static string Md5StringOf(byte[] input)
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


        /// <summary>
        ///     Computes the md5 hash of a file, given its stream, and converts it to a 
        ///     lowercase hex string
        /// </summary>
        /// <param name="fileStream">
        ///     Stream of the file to be digested
        /// </param>
        /// <remarks>
        ///     To be used with larger size files
        /// </remarks>
        /// <returns>
        ///     The md5 digest of the input file stream
        /// </returns>
        public static string Md5StringOf(Stream fileStream)
        {
            using (var md5 = MD5.Create())
            {
                var hash_md5 = md5.ComputeHash(fileStream);
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
