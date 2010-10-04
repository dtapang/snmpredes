using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace SnmpMonitor
{
    class SnmpTrapManager
    {
        Socket mainSocket;
        public void StartListening()
        {
            try
            {
                int port = 162;
                // Create the listening socket...
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);
                // Bind to local IP Address...
                mainSocket.Bind(ipLocal);
                // Start listening...
                //mainSocket.Listen(4);
                // Create the call back for any client connections...
                //mainSocket.BeginAccept(new AsyncCallback(RecieveTrap), null);
                
                SocketAsyncEventArgs e = new SocketAsyncEventArgs();

                byte[] resultado = new byte[1024];
                //bool Event_Connect = false;
                e.SetBuffer(resultado, 0, 200);
                e.RemoteEndPoint = (EndPoint)ipLocal;
                e.AcceptSocket = mainSocket;

                mainSocket.ConnectAsync(e); //CONNECTS ASYNCRONOUSLY


                e.Completed += new EventHandler<SocketAsyncEventArgs>(this.RecieveTrap); //EVENT HANDLER FOR TRAP RECIEVE
                mainSocket.ReceiveAsync(e); //ACTIVATE RECIEVE TRAPS
            }
            catch (SocketException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
        }
        public void RecieveTrap(Object sender, SocketAsyncEventArgs e)
        {
            ////Code to recieve handler..Deleted for now.////
            byte[] resultado = e.Buffer;
            e.SetBuffer(new byte[1024],0,512);
            mainSocket.ReceiveAsync(e); //Call recieve handler again.
        } 
        //public void RecieveTrap(IAsyncResult asyn)
        //{
        //    try
        //    {
        //        // Here we complete/end the BeginAccept() asynchronous call
        //        // by calling EndAccept() - which returns the reference to
        //        // a new Socket object
        //        Socket workerSocket = mainSocket.EndAccept(asyn);
        //        byte[] resultado = new byte[1024];
        //        workerSocket.BeginReceive(resultado, 0, 512, SocketFlags.None, DataRecieved, resultado);
        //        // Let the worker Socket do the further processing for the 
        //        // just connected client
        //        //WaitForData(m_workerSocket[m_clientCount]);
        //        // Now increment the client count
        //        //++m_clientCount;
        //        // Display this client connection as a status message on the GUI	
        //        //String str = String.Format("Client # {0} connected", m_clientCount);
        //        //textBoxMsg.Text = str;

        //        // Since the main Socket is now free, it can go back and wait for
        //        // other clients who are attempting to connect
        //        mainSocket.BeginAccept(new AsyncCallback(RecieveTrap), null);
        //    }
        //    catch (ObjectDisposedException)
        //    {
        //        System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
        //    }
        //    catch (SocketException se)
        //    {
        //        MessageBox.Show(se.Message);
        //    }

        //}
        public void DataRecieved(IAsyncResult async)
        {
            byte[] resultado = (byte[])async.AsyncState;
            MessageBox.Show(resultado.ToString());
        }
    }
}
