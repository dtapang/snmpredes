using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace SnmpMonitor
{
    class SnmpConector
    {
        public void Probar()
        {
            IPHostEntry IPHost = Dns.GetHostEntry("www.hotmail.com");
            MessageBox.Show(IPHost.HostName);
            string[] aliases = IPHost.Aliases;
            MessageBox.Show(aliases.Length.ToString());
            IPAddress[] addr = IPHost.AddressList;
            MessageBox.Show(addr.Length.ToString());
            for (int i = 0; i < addr.Length; i++)
            {
                MessageBox.Show(addr[i].ToString());
            }
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Tcp);
            
        }
    }
}
