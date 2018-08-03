using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPSocketCS;

namespace Test
{
    public enum AppState
    {
        Starting, Started, Stoping, Stoped, Error
    }

    public partial class FormHPSocketUDP : Form
    {
        private AppState appState = AppState.Stoped;

        public FormHPSocketUDP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread receThread = new Thread(new ThreadStart(RecvThread));
            receThread.IsBackground = true;
            receThread.Start();

            ////取得当前系统时间
            //DateTime t = DateTime.Now;
            ////在当前时间上加上一周
            //t = t.AddDays(7);
            ////转换System.DateTime到SYSTEMTIME
            //SYSTEMTIME st = new SYSTEMTIME();
            //st.FromDateTime(t);
            ////调用Win32 API设置系统时间
            //FarProc_Win32.SetLocalTime(ref st);
            ////显示当前时间
            //MessageBox.Show(DateTime.Now.ToString());
        }

        private void RecvThread()
        {
            UdpClient UDPrece = new UdpClient(new IPEndPoint(IPAddress.Any, 9095));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] buf = UDPrece.Receive(ref endpoint);
                string msg = Encoding.Default.GetString(buf);
                //取得当前接收到的时间
                DateTime t = DateTime.Parse(msg);
                //在当前时间上加上一周
                t = t.AddDays(7);
                //转换System.DateTime到SYSTEMTIME
                SYSTEMTIME st = new SYSTEMTIME();
                st.FromDateTime(t);
                //调用Win32 API设置系统时间
                FarProc_Win32.SetLocalTime(ref st);
                //显示当前时间
                MessageBox.Show(DateTime.Now.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//初始化一个Scoket实习,采用UDP传输

            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 9095);//初始化一个发送广播和指定端口的网络端口实例

            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);//设置该scoket实例的发送形式

            string request = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//初始化需要发送而的发送数据

            byte[] buffer = Encoding.Default.GetBytes(request);

            sock.SendTo(buffer, iep);

            sock.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            Thread.Sleep(2000);
            DateTime dtEnd = DateTime.Now;
            MessageBox.Show((dtEnd - dt).TotalMilliseconds.ToString());
        }
    }
}
