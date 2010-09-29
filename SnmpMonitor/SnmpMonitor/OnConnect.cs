using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SnmpMonitor
{
    class OnConnect
    {
        Socket Myclient;

        public OnConnect(IAsyncResult ar)
        {
            /*
             * Socket listener = (Socket)ar.AsyncState;
             * Myclient = listener.EndAccept(ar);
               Myclient.Send(data to be send);
             * listener.BeginAccept(new AsyncCallback(OnConnect), listener);
             */
        }

        public void OnConnectDo() { }
    }
}
