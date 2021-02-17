using System;
using System.Text;
using System.Security.Cryptography;
namespace TaxComputationAPI.Manager
{

    public class PurchaseEncryptor
    {

        #region private members

        private Byte[] m_rootkey = null;

        #endregion

        #region public functions

        /// <summary>
        /// init key
        /// </summary>
        /// <param name="rootkey"></param>
        public void Init(Byte[] rootkey)
        {
            m_rootkey = rootkey;
        }

        /// <summary>
        /// Generate Purchase String 
        /// </summary>
        /// <param name="transactionID"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        public String GeneratePurchaseString(String transactionID, Double payment,string rootKey)
        {
            //transid, String to bytes  
            Byte[] transidbytes = ASCIITo16Bytes(transactionID);

            var v = HexStringToBytes(rootKey);


            PrintBytes("Transaction ID", transidbytes);    //Debug


            //--------------------------------------
            //encrypt transaction ID by rootkey 
            AESProcessor aes = new AESProcessor();
            //AESProcessor aes = new AESProcessor();
            Byte[] encryptedtransaction = aes.Encrypt(transidbytes, v);

            PrintBytes("Encrypted transaction ID", encryptedtransaction);  //Debug

            //--------------------------------------
            // payment to string 
            String paymentstr = payment.ToString("F2");
            //String to bytes  
            Byte[] paymentbytes = ASCIITo16Bytes(paymentstr);

            PrintBytes("Payment", paymentbytes);   //Debug

            //--------------------------------------
            //Encrypt payment by [Encrypted transaction ID]  
            Byte[] purchasebytes = aes.Encrypt(paymentbytes, encryptedtransaction);

            PrintBytes("Encrypted purchase parameter", purchasebytes);   //Debug

            String hexstr = BytesToHexString(purchasebytes);
            Console.WriteLine(hexstr);
            return hexstr;
        }

        #endregion

        #region private functions


        public const Int32 CONST_AESKeyBytes = 16;

        /// <summary>
        /// ascii string to bytes, 
        /// less then 16 chars, high bytes keep 0x00
        /// more than 16 chars, only use first 16 chars
        /// </summary>
        /// <param name="rawstr"></param>
        /// <returns></returns>
        private Byte[] ASCIITo16Bytes(String rawstr)
        {
            if (rawstr.Length < 1)
            {
                return null;
            }
            if (rawstr.Length > CONST_AESKeyBytes)
            {
                rawstr = rawstr.Substring(0, CONST_AESKeyBytes);
                return null;
            }

            Byte[] strbytes = Encoding.Default.GetBytes(rawstr);
            Byte[] resultbytes = new byte[CONST_AESKeyBytes];
            Array.Copy(strbytes, 0, resultbytes, 0, strbytes.Length);
            return resultbytes;
        }


        /// <summary>
        /// Bytes To ASCII 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static String BytesToASCIIString(Byte[] bytes)
        {
            return BytesToASCIIString(bytes, 0, bytes.Length);
        }


        /// <summary>
        ///  Bytes To ASCII 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static String BytesToASCIIString(Byte[] bytes, Int32 start, Int32 datalen)
        {
            if (bytes == null || bytes.Length < 1 ||
                start < 0 || start >= bytes.Length ||
                datalen < 1 || start + datalen > bytes.Length)
            {
                return String.Empty;
            }

            Int32 idx = Array.IndexOf(bytes, (Byte)0);
            if (idx == 0)
            {
                return "";
            }

            String ret = String.Empty;

            if (idx < 0)
            {
                ret = Encoding.ASCII.GetString(bytes, start, datalen);
                return ret;
            }

            Byte[] purestr = new byte[idx];
            Array.Copy(bytes, purestr, idx);
            if (start >= purestr.Length)
            {
                return String.Empty;
            }

            if (start + datalen > purestr.Length)
            {
                datalen = purestr.Length - start;
            }
            ret = Encoding.ASCII.GetString(purestr, start, datalen);
            return ret;
        }


        /// <summary>
        /// show bytes with  0x
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataDescription"></param>
        private void PrintBytes(String dataDescription, Byte[] data)
        {
            String hexString = BytesToHexStringForDisplay(data);
            Console.WriteLine(dataDescription + " = " + hexString);
        }


        /// <summary>
        ///  Bytes To Hex String
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static String BytesToHexStringForDisplay(Byte[] bytes)
        {
            if (bytes == null || bytes.Length < 1)
            {
                return String.Empty;
            }

            StringBuilder str = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                str.Append("0x" + bytes[i].ToString("X2") + ", ");
            }
            str.Remove(str.Length - 2, 2);
            String ret = str.ToString();
            return ret;
        }

        /// <summary>
        ///  Bytes To Hex String
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static String BytesToHexString(Byte[] bytes)
        {
            if (bytes == null || bytes.Length < 1)
            {
                return String.Empty;
            }

            StringBuilder str = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                str.Append(bytes[i].ToString("X2"));
            }

            String ret = str.ToString();
            return ret;
        }

        /// <summary>
        /// HexString To Bytes
        /// </summary> 
        /// <returns></returns>
        public static Byte[] HexStringToBytes(String hexstr)
        {
            if (hexstr.Length < 1)
            {
                return null;
            }

            if (hexstr.Length % 2 != 0)
            {
                return null;
            }
            int bytelen = hexstr.Length / 2;
            Byte[] bytes = new Byte[bytelen];
            String curbytestr = String.Empty;

            for (int bidx = 0; bidx < bytelen; bidx++)
            {
                curbytestr = hexstr.Substring(bidx * 2, 2);
                bytes[bidx] = Convert.ToByte(curbytestr, 16);
            }
            return bytes;
        }

        #endregion
    }
}

