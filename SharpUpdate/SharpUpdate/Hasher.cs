using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace SharpUpdate
{
    internal enum MashType
    {
        MD5,
        SHA1,
        SHA512

    }

    internal static class Hasher
    {
        internal static string HashFile(string filePath, MashType algo)
        {
            switch(algo)
            {
                case MashType.MD5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case MashType.SHA1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case MashType.SHA512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));

                default:
                    return "";
            }

        }


        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
                s.Append(b.ToString("X2").ToLower());
            return s.ToString();

        }


    }



}
