using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace SnmpMonitor
{
    public class SnmpConector
    {
        private XMLData.XMLData datos;
        public SnmpConector()
        {
            this.datos = new XMLData.XMLData();
        }
        #region GetSet
        /// <summary>
        /// Nombre de host del Agente SNMP
        /// </summary>
        public String AgentHostName
        {
            get { return this.datos.GetDato("Parametros", "HostName"); }
            set { this.datos.SetDato("Parametros", "HostName", value); }
        }
        /// <summary>
        /// String con IP del agente
        /// </summary>
        public String AgentIP
        {
            get { return this.datos.GetDato("Parametros", "HostIP"); }
            set { this.datos.SetDato("Parametros", "HostIP", value); }
        }
        /// <summary>
        /// String MIB para medir datos entrantes
        /// </summary>
        public String MIBInData
        {
            get { return this.datos.GetDato("Configuracion", "MIBDataIn"); }
            set { this.datos.SetDato("Configuracion", "MIBDataIn", value); }
        }
        /// <summary>
        /// String MIB para medir datos salientes
        /// </summary>
        public String MIBDataOut
        {
            get { return this.datos.GetDato("Configuracion", "MIBDataOut"); }
            set { this.datos.SetDato("Configuracion", "MIBDataOut", value); }
        }
        /// <summary>
        /// String de comunidad
        /// </summary>
        public String Community
        {
            get { return this.datos.GetDato("Parametros", "Community"); }
            set { this.datos.SetDato("Parametros", "Community", value); }
        }
        /// <summary>
        /// Disponibilidad teorica en porcentaje
        /// </summary>
        public String Availability
        {
            get { return this.datos.GetDato("Parametros", "ISPUpTime"); }
            set { this.datos.SetDato("Parametros", "ISPUpTime", value); }
        }
        /// <summary>
        /// Intervalo de Polling en milisegundos
        /// </summary>
        public String PollInterval
        {
            get { return this.datos.GetDato("Configuracion", "PollInterval"); }
            set { this.datos.SetDato("Configuracion", "PollInterval", value); }
        }
        /// <summary>
        /// Tiempo de monitoreo en minutos
        /// </summary>
        public String MonitorTime
        {
            get { return this.datos.GetDato("Configuracion", "MonitorTime"); }
            set { this.datos.SetDato("Configuracion", "MonitorTime", value); }
        }
        /// <summary>
        /// Indice de la interfaz a consultar
        /// </summary>
        public String InterfaceIndex
        {
            get { return this.datos.GetDato("Configuracion", "InterfaceIndex"); }
            set { this.datos.SetDato("Configuracion", "InterfaceIndex", value); }
        }
        #endregion
        //public void Probar()
        //{
        //    IPHostEntry IPHost = Dns.GetHostEntry("www.hotmail.com");
        //    MessageBox.Show(IPHost.HostName);
        //    string[] aliases = IPHost.Aliases;
        //    MessageBox.Show(aliases.Length.ToString());
        //    IPAddress[] addr = IPHost.AddressList;
        //    MessageBox.Show(addr.Length.ToString());
        //    for (int i = 0; i < addr.Length; i++)
        //    {
        //        MessageBox.Show(addr[i].ToString());
        //    }
        //    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Tcp);
            
        //}
    }
}
