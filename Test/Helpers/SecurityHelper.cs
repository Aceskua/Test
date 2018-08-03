using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helpers
{
    public class SecurityHelper
    {
        private const string _securityKey = "hiwei713";
        #region 老加密算法
        //加密
        //public string Encryption(string express)
        //{
        //    CspParameters param = new CspParameters();
        //    param.KeyContainerName = _securityKey;//密匙容器的名称，保持加密解密一致才能解密成功
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
        //    {
        //        byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
        //        byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
        //        return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
        //    }
        //}

        ////解密
        //public string Decrypt(string ciphertext)
        //{
        //    CspParameters param = new CspParameters();
        //    param.KeyContainerName = _securityKey;
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
        //    {
        //        byte[] encryptdata = Convert.FromBase64String(ciphertext);
        //        byte[] decryptdata = rsa.Decrypt(encryptdata, false);
        //        return Encoding.Default.GetString(decryptdata);
        //    }
        //}
        #endregion

        public string Encryption(string express)
        {
            return DesEncrypt(express, _securityKey);
        }

        /// <summary>  
        /// DES加密算法  
        /// sKey为8位或16位  
        /// </summary>  
        /// <param name="pToEncrypt">需要加密的字符串</param>  
        /// <param name="sKey">密钥</param>  
        /// <returns></returns>  
        private string DesEncrypt(string pToEncrypt, string sKey)
        {
            StringBuilder ret = new StringBuilder();

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
            }
            catch
            {

            }
            return ret.ToString();
            //return a;  
        }

        public string Decrypt(string ciphertext)
        {
            return DesDecrypt(ciphertext, _securityKey);
        }

        /// <summary>  
        /// DES解密算法  
        /// sKey为8位或16位  
        /// </summary>  
        /// <param name="pToDecrypt">需要解密的字符串</param>  
        /// <param name="sKey">密钥</param>  
        /// <returns></returns>  
        private string DesDecrypt(string pToDecrypt, string sKey)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();

            }
            catch(Exception e)
            {

            }

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}
