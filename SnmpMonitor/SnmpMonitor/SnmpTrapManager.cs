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
        ITrapListener listener;
        public SnmpTrapManager(ITrapListener listener)
        {
            this.listener = listener;
        }
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
                
                SocketAsyncEventArgs e = new SocketAsyncEventArgs();

                byte[] resultado = new byte[1024];
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
        public void StopListening()
        {
            try
            {
                mainSocket.Shutdown(SocketShutdown.Both);
                mainSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RecieveTrap(Object sender, SocketAsyncEventArgs e)
        {
            ////Code to recieve handler..Deleted for now.////
            try
            {
                byte[] resultado = e.Buffer;

                ParserSNMPTrap parser = new ParserSNMPTrap();
                SNMPTrapSequence sequence = parser.ObtenerValor(resultado);
                if (sequence.SnmpTrapPdu.GenericTrap == 3)
                {
                    listener.ListenTrap(false);
                }
                else if (sequence.SnmpTrapPdu.GenericTrap == 2)
                {
                    listener.ListenTrap(true);
                }
                else
                {
                    e.SetBuffer(new byte[1024], 0, 512);
                    throw new Exception("Trap no considerado");
                }


                //if ()
                e.SetBuffer(new byte[1024], 0, 512);
                mainSocket.ReceiveAsync(e); //Call recieve handler again.
            }
            catch (ObjectDisposedException oEx)
            { 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        //public void DataRecieved(IAsyncResult async)
        //{
        //    byte[] resultado = (byte[])async.AsyncState;
        //    MessageBox.Show(resultado.ToString());
        //}
    }
}
