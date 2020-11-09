using KataSolutions.SimpleEncryption_AlternatingSplit;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTests
{
    public class SimpleEncryption_AlternatingSplitTests
    {
        private Random rand = new Random(DateTime.Now.Second);

        [Test]
        public void EncryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", SimpleEncryption_AlternatingSplit.Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", SimpleEncryption_AlternatingSplit.Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", SimpleEncryption_AlternatingSplit.Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", SimpleEncryption_AlternatingSplit.Encrypt("This kata is very interesting!", 1));
        }

        [Test]
        public void DecryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Decrypt("This is a test!", 0));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Decrypt("hsi  etTi sats!", 1));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Decrypt("s eT ashi tist!", 2));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Decrypt(" Tah itse sits!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Decrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption_AlternatingSplit.Decrypt("This is a test!", -1));
            Assert.AreEqual("This kata is very interesting!", SimpleEncryption_AlternatingSplit.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
        }

        [Test]
        public void EncryptDecryptTests()
        {
            Assert.AreEqual("Kobayashi-Maru-Test", SimpleEncryption_AlternatingSplit.Decrypt(SimpleEncryption_AlternatingSplit.Encrypt("Kobayashi-Maru-Test", 10), 10));
        }

        [Test]
        public void EmptyTests()
        {
            Assert.AreEqual("", SimpleEncryption_AlternatingSplit.Encrypt("", 0));
            Assert.AreEqual("", SimpleEncryption_AlternatingSplit.Decrypt("", 1));
        }

        [Test]
        public void NullTests()
        {
            Assert.AreEqual(null, SimpleEncryption_AlternatingSplit.Encrypt(null, 1));
            Assert.AreEqual(null, SimpleEncryption_AlternatingSplit.Decrypt(null, 0));
        }

        [Test]
        public void RandomTests()
        {
            for (int i = 0; i < 20; i++)
            {
                int n = rand.Next(0, 10);
                int length = rand.Next(1, 70);
                var text = string.Concat(Enumerable.Range(1, length).Select(c => (char)rand.Next(65, 91)));
                Assert.AreEqual(myEncrypt(text, n), SimpleEncryption_AlternatingSplit.Encrypt(text, n));
                Assert.AreEqual(myDecrypt(text, n), SimpleEncryption_AlternatingSplit.Decrypt(text, n));
            }
        }

        private string myEncrypt(string text, int n)
        {
            if (string.IsNullOrEmpty(text) || (n <= 0))
            {
                return text;
            }

            string encryptedText = text;

            for (int x = 0; x < n; x++)
            {
                encryptedText = string.Concat(encryptedText.Where((o, i) => i % 2 != 0).Concat(encryptedText.Where((o, i) => i % 2 == 0)));
            }

            return encryptedText;
        }

        public string myDecrypt(string encryptedText, int n)
        {
            if (string.IsNullOrEmpty(encryptedText) || (n <= 0))
            {
                return encryptedText;
            }

            string decryptedText = encryptedText;

            for (int x = 0; x < n; x++)
            {
                decryptedText = string.Concat(Enumerable.Zip(decryptedText.Take(decryptedText.Length / 2), decryptedText.Skip(decryptedText.Length / 2), (a, b) => b + "" + a)) + (decryptedText.Length % 2 == 1 ? decryptedText.Substring(decryptedText.Length - 1) : "");
            }

            return decryptedText;
        }
    }
}
