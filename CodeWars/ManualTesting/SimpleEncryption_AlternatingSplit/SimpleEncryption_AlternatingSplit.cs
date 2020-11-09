using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.SimpleEncryption_AlternatingSplit
{
    // TODO - try to optimize this solution (a lot of nested loops here!)
    public class SimpleEncryption_AlternatingSplit
    {
        public static string Encrypt(string text, int n)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string encryptedString = text;
            for (int i = 0; i < n; i++)
            {
                encryptedString = EncryptString(encryptedString);
            }

            return encryptedString;
        }

        private static string EncryptString(string text)
        {
            StringBuilder sbOdd = new StringBuilder();
            StringBuilder sbEven = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sbOdd.Append(text[i]);
                }
                else
                {
                    sbEven.Append(text[i]);
                }
            }

            return $"{ sbOdd }{ sbEven }";
        }

        public static string Decrypt(string encryptedText, int n)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                return encryptedText;
            }

            string decryptedText = encryptedText;
            for (int i = 0; i < n; i++)
            {
                decryptedText = DecryptString(decryptedText);
            }

            return decryptedText;
        }

        private static string DecryptString(string text)
        {
            int oddCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 0)
                {
                    oddCount++;
                }
            }

            StringBuilder sbOdd = new StringBuilder();
            StringBuilder sbEven = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i < oddCount)
                {
                    sbOdd.Append(text[i]);
                }
                else
                {
                    sbEven.Append(text[i]);
                }
            }

            oddCount = 0;
            int evenCount = 0;
            StringBuilder decryptedText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 0)
                {
                    decryptedText.Append(sbOdd[oddCount]);
                    oddCount++;
                }
                else
                {
                    decryptedText.Append(sbEven[evenCount]);
                    evenCount++;
                }
            }

            return decryptedText.ToString();
        }
    }
}
