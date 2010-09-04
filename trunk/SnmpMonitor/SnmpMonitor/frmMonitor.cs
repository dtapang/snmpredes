using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnmpMonitor
{
    public partial class frmMonitor : Form
    {
        private SnmpConector snc;
        private SNMP snmp;
        private string comunity;
        private string agent;
        private string MibIn;
        private string MibOut;
        private Int32 counterIn = 0;
        private Int32 counterOut = 0;
        private ParserSNMP parser;
        private dsInOut ds;
        

        public frmMonitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ds = new dsInOut();
            tmrPoll.Interval = Convert.ToInt32(this.snc.PollInterval);
            tmrPoll.Start();
            try
            {
                Byte[] resultado = snmp.get(SNMP.Request.get, "localhost", "public", "1.3.6.1.2.1.1.5.0");
                ParseSNMPMessage(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Poll()
        {
            Byte[] resultadoIn = snmp.get(SNMP.Request.getNext, this.agent, this.comunity, this.MibIn);
            Byte[] resultadoOut = snmp.get(SNMP.Request.getNext, this.agent, this.comunity, this.MibOut);
            SNMPSequence datosIn = parser.ObtenerValor(resultadoIn);
            SNMPSequence datosOut = parser.ObtenerValor(resultadoOut);
            Int32 datoInActual = 0;
            Int32 datoOutActual = 0;
            ds.Tables;
             
            
        }

        public void ParseSNMPMessage(Byte[] message)
        {
            Byte typeByte = message[0];
            Byte lenghtByte = message[1];
            String type = "";
            int lenght = Convert.ToInt32(lenghtByte);
            switch (typeByte)
            {
                case (0x02):
                    type = "Integer";
                    break;
                case (0x04):
                    type = "Octet String";
                    break;
                case (0x05):
                    type = "Null";
                    break;
                case (0x06):
                    type = "Object identifier";
                    break;
                case (0x30):
                    type = "Sequence";
                    break;
                case (0xA0):
                    type = "GetRequestPDU";
                    break;
                case (0xA2):
                    type = "GetResponsePDU";
                    break;
                case (0xA3):
                    type = "SetRequestPDU";
                    break;
            }
            MessageBox.Show("Data type = " + type + "\rMessage length = " + lenght);

        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
            InicializarVariables();
        }
        private void InicializarVariables()
        {
            this.snmp = new SNMP();
            this.snc = new SnmpConector();
            this.comunity = snc.Community;
            this.agent = snc.AgentIP;
            this.txtAgentIP.Text = this.agent;
            this.txtComunity.Text = this.comunity;
            this.MibIn = snc.MIBInData;
            this.MibOut = snc.MIBDataOut;
            this.parser = new ParserSNMP();
        }

    }
}
