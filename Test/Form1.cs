using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private bool m_bInitSDK = false;

        public Form1()
        {
            InitializeComponent();
        }

        private string RandomNumFour()
        {
            Random rad = new Random();
            return rad.Next(1000, 10000).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helpers.SecurityHelper securityHelper = new Helpers.SecurityHelper();
            string result = securityHelper.Encryption("admin123");
            MessageBox.Show(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Helpers.SecurityHelper securityHelper = new Helpers.SecurityHelper();
            //string result = securityHelper.Decrypt("A115C5B50665CE1E99F09A43EC5DDBF7");


            //string path = "C:\\Users\\Admin\\Desktop\\临时用\\管理制度\\文档.jpg";
            //string pathNew = "C:\\Users\\Admin\\Desktop\\临时用\\党建工作\\新文档.jpg";
            //if (File.Exists(path))
            //{
            //    File.Move(path,pathNew);
            //    MessageBox.Show("移动文件成功！");
            //}
            //else
            //{
            //    MessageBox.Show("文件不存在！");
            //}

            //string path = "C:\\Users\\Admin\\Desktop\\临时用\\test";
            //string pathDestination = "E:\\test2";

            //DirectoryInfo dir = new DirectoryInfo(path);
            //FileInfo[] files = dir.GetFiles();
            //foreach (FileInfo file in files)
            //{
            //    string filePath = file.FullName;
            //    string fileDirectory = file.DirectoryName;
            //    string fileName = file.Name;
            //    string fileNewPath = pathDestination + "\\" + fileName;
            //    File.Move(filePath, fileNewPath);
            //}
            //MessageBox.Show("文件移动完毕！");
            //string s = "grehy3hy7,Card:N00001";
            //Encoding encoding = new UTF8Encoding();
            //string shex = StringToHexString(s, encoding);
            //byte[] bytes = strToToHexByte(shex);
            //byte[] bytesUniqueCode = bytes.Skip(bytes.Length - 11).Take(11).ToArray();
            //List<byte> listbytes = bytes.ToList();
            //listbytes.RemoveRange(listbytes.Count - 12, 12);
            //byte[] bytesSource = listbytes.ToArray();
            //MessageBox.Show(Encoding.Default.GetString(bytesUniqueCode).Substring(5));
            //MessageBox.Show(Encoding.Default.GetString(bytesSource));
            string s =
            "0x030149210000000000000000C000C002C002C002C002C002C002C002C002C002C002E002E002FFFE00000000000000000000000000000000760A965E6696855E331794DE4B99849E5B2A475E5A3C0BDE3104159F361D53BF53A2DA7F35A46C1F2B2B8E3F1CADCE5F4E37CA7F538DC2FA29390CBA238AC0386A9FDBD85C8896796D9F053348B249790C8BAC702D3A62D713896C14630A8034210DD5CE37B58C541A08D60F120B568F688D01F3490DC2503BB60BF0540A56454F8AAC42000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003013C170000000600060006803E803E803E803E803E803E803E803E803E803E803E803E807EFFFE00000000000000000000000000000000620B173E2E1E149E432044FE3022531E1030667E23348DFE12B70D5E0C062B174B2A5B1F2DAAECBF10A5E4B33914261211A3285830071699310DD6D64E10CFB02F0B56D70C0DEA0C129F238C499840C81E06982714088089180DEC64000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            string r = Regex.Replace(s, @"(?<=.{2}).{2}", " $0");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SDK初始化
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //decimal result = Math.Round((decimal) 2 / 9, 2);
            //int rrr = (int) (result * 100);
            //byte by = 0x78;
            //byte[] bytes = {0x54, 0x7, 0x50};

            //DateTime dt1 = Convert.ToDateTime("2017-03-17 09:49:55.667");
            //DateTime dt2 = Convert.ToDateTime("2017-03-17 09:51:46.310");

            //TimeSpan ts = dt2 - dt1;

            string sss = "03 01 37 1D 00 00 00 00 00 00 00 00 00 00 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 06 C0 06 C0 0E FF FE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 6E 16 D2 BE 4D 28 96 7E 52 AD 16 5E 5F B0 AB 5E 28 BE 18 3E 50 93 E8 BF 51 98 69 FF 60 1A 69 3F 13 1E 44 7F 60 A4 A9 BF 12 B2 43 77 5C B7 15 3F 3F 39 EC 9F 36 26 9E 3C 5C 1D E9 BA 58 20 55 FB 4F 1E 96 98 44 2B 96 B9 32 B8 40 79 26 A9 1B 57 31 BA 18 F4 3F 28 C0 55 22 A6 5C 73 4C B9 55 F3 0C 0D 46 0B 1F 22 DB 4F 77 0A 4D 4C 52 8E 12 EC 35 20 5E E7 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";

            string ss1 = "03 01 3B 16 00 00 00 00 00 00 00 00 80 02 80 02 80 02 80 02 80 02 80 02 80 06 80 06 C0 06 E0 06 F0 0E F8 1E FF FE FF FE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 49 91 A4 9E 3B 18 E6 FE 26 28 1A 3E 62 2C 27 7E 52 2E 53 DE 1D 94 1F 5F 42 9E 27 FF 12 AB 5B 97 2D AC 2C 3F 59 34 53 9F 35 B7 AB FF 69 11 A5 DA 0F 8A 80 98 57 0C 8F 39 64 8C 90 17 30 94 9E F5 74 06 0F AD 17 0E 49 13 6A 0C D3 31 32 10 24 4A 50 8A 80 62 46 8C 4E 22 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";

            string ss2 = "EF 01 FF FF FF FF 07 00 03 00 00 0A EF 01 FF FF FF FF 02 00 82 03 01 54 1C 00 00 00 00 00 00 00 00 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 02 80 02 C0 06 C0 0E FF FE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 4A A1 93 BE 48 2B 13 DE 4C 32 12 9E 31 B2 D4 7E 76 87 18 3F 60 9B D1 5F 1B 9C 18 5F 28 B2 16 5F 53 37 92 3F 37 B8 13 FF 28 96 EC 1C 5E B8 A7 BC 61 BB 91 BC 2B 86 55 F2 1C 87 6C 3A 13 0E 41 9A 1C 8E 6C FA 1E 0A EC FB 29 7E EF 01 FF FF FF FF 02 00 82 4F 8B EC FB 5B 0C D4 5B 14 8A 80 58 2F 93 96 98 31 16 55 B8 26 06 80 33 4B 0F 53 F9 36 8E 16 36 5F 8D 13 D7 37 07 16 B2 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 10 06 EF 01 FF FF FF FF 02 00 82 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 84 EF 01 FF FF FF FF 08 00 82 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 8A";

            byte[] b = strToToHexByte(ss2);
            byte[] b1 = GetFingerInfo(b);
            string finger = Convert.ToBase64String(b1, 0, b1.Length);
            string rrr = "111";

            foreach (byte bt in b1)
            {
                rrr = rrr + " " + bt.ToString("X2");
            }

            //Student stu = new Student();
            //stu.ID = 1;
            //stu.Name = "张三";
            //stu.Class = new Class() { ID = 0121, Name = "CS0121" };

            //使用方法1
            //实体序列化、反序列化
            //结果：{"ID":1,"Name":"张三","Class":{"ID":121,"Name":"CS0121"}}
            //string json1 = JsonConvert.SerializeObject(stu);
            //this.button4.PerformClick();

            //MessageBox.Show(json1);

            //string s = "Camera:0,Player:0";

            //string[] sarray = s.Split(',');

            //if (sarray[0].IndexOf("0") > 0)
            //{
            //    MessageBox.Show("相机故障！");
            //}

            //if (sarray[1].IndexOf("0") > 0)
            //{
            //    MessageBox.Show("广告机故障！");
            //}

            //string s = "5ee4b024-c38d-471d-b13a-913bb49a231b20";
            //Encoding encoding = Encoding.UTF8;
            //string s1 = StringToHexString(s, encoding);
            //string s2 = HexStringToString(s1, encoding);
            //byte[] bytes = strToToHexByte("01" + s1);
        }

        private byte[] GetFingerInfo(byte[] bytesrc)
        {
            byte[] temp = new byte[128];
            List<byte> fingerInfo = new List<byte>();

            List<byte> fingerInfoSource = bytesrc.ToList();
            fingerInfoSource.RemoveRange(0, 21);
            Buffer.BlockCopy(fingerInfoSource.ToArray(), 0, temp, 0, 128);
            fingerInfo.AddRange(temp);
            fingerInfoSource.RemoveRange(0, 139);
            Buffer.BlockCopy(fingerInfoSource.ToArray(), 0, temp, 0, 128);
            fingerInfo.AddRange(temp);
            fingerInfoSource.RemoveRange(0, 139);
            Buffer.BlockCopy(fingerInfoSource.ToArray(), 0, temp, 0, 128);
            fingerInfo.AddRange(temp);
            fingerInfoSource.RemoveRange(0, 139);
            Buffer.BlockCopy(fingerInfoSource.ToArray(), 0, temp, 0, 128);
            fingerInfo.AddRange(temp);

            return fingerInfo.ToArray();
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符，以%隔开
            {
                result += " " + Convert.ToString(b[i], 16);
            }
            return result;
        }
        private string HexStringToString(string hs, Encoding encode)
        {
            //以%分割字符串，并去掉空字符
            string[] chars = hs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] b = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < chars.Length; i++)
            {
                b[i] = Convert.ToByte(chars[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ss2 = "AwFUHAAAAAAAAAAAgAKAAoACgAKAAoACgAKAAoACgAKAAsAGwA7//gAAAAAAAAAAAAAAAAAAAABKoZO+SCsT3kwyEp4xstR+docYP2Cb0V8bnBhfKLIWX1M3kj83uBP/KJbsHF64p7xhu5G8K4ZV8hyHbDoTDkGaHI5s+h4K7PtPi+z7WwzUWxSKgFgvk5aYMRZVuCYGgDNLD1P5No4WNl+NE9c3BxayAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";

            //byte[] b = strToToHexByte(ss2);

            //byte[] b1 = GetFingerInfo(b);

            //string finger = Convert.ToBase64String(b1, 0, b1.Length);

            string url = "http://192.168.0.102/api/Fingerprint/comparison";

            //string para = "?zwxx=" + finger + "&ipAddress=127.0.0.2&imageAdress=1111";

            //var str = HttpGet(url + para);

            FingerInfo fingerInfo = new FingerInfo();
            fingerInfo.zwxx = ss2;
            fingerInfo.zngbh = "N00001";
            fingerInfo.imageAdress = "111111.jpg";

            string para = JsonConvert.SerializeObject(fingerInfo);

            var str = HttpPost(url, para);

            ApiReturnInfo result = JsonConvert.DeserializeObject<ApiReturnInfo>(str);

            if (result.type == 0)
            {
                MessageBox.Show(result.message);
            }
            if (result.type == 1)
            {
                MessageBox.Show(result.message);
            }
        }

        public string HttpPost(string url, string body)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            byte[] buffer = encoding.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public string HttpGet(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 调用api返回json
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public string HttpApi(string url, string jsonstr, string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString();//get或者post
            byte[] buffer = encoding.GetBytes(jsonstr);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }

    /// <summary>
    /// 学生信息实体
    /// </summary>
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
    }

    /// <summary>
    /// 学生班级实体
    /// </summary>
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class FingerInfo
    {
        public string zwxx { get; set; }
        public string zngbh { get; set; }
        public string imageAdress { get; set; }
    }

    public class ApiReturnInfo
    {
        public int type { get; set; }
        public string message { get; set; }
    }
}
