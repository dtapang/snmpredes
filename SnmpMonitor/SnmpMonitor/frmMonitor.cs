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
        private int availability;
        private Int32 counterIn = 0;
        private Int32 counterOut = 0;
        private ParserSNMP parser;
        private dsInOut.DataInOutDataTable inOutTable;
        
        public frmMonitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void Poll()
        {
            try
            {
                Random r = new Random();
                Byte[] resultadoIn = snmp.get(SNMP.Request.get, "localhost", this.comunity, this.MibIn);
                Byte[] resultadoOut = snmp.get(SNMP.Request.get, "localhost", this.comunity, this.MibOut);
                SNMPSequence datosIn = parser.ObtenerValor(resultadoIn);
                SNMPSequence datosOut = parser.ObtenerValor(resultadoOut);
                Int32 datoInActual = r.Next(0, 100);
                Int32 datoOutActual = r.Next(0, 100);
                this.txtIn.Text = datoInActual.ToString();
                this.txtOut.Text = datoOutActual.ToString();
                //Int32 datoInActual = Convert.ToInt32(datosIn.Snmppdu.Valor);
                //Int32 datoOutActual = Convert.ToInt32(datosOut.Snmppdu.Valor);
                this.inOutTable.AddDataInOutRow(DateTime.Now, datoInActual, datoInActual, datoOutActual, datoOutActual);

                string expression = "TimeStamp > '" + DateTime.Now.AddMinutes(-10).ToString() + "'";
                chartInOut.DataSource = this.inOutTable.Select(expression);
                
                chartInOut.Series["DataIn"].YValueMembers = "ValueIn";
                chartInOut.Series["DataIn"].XValueMember = "TimeStamp";
                chartInOut.Series["DataIn"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;

                chartInOut.Series["DataOut"].YValueMembers = "ValueOut";
                chartInOut.Series["DataOut"].XValueMember = "TimeStamp";
                chartInOut.Series["DataOut"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                   
                chartInOut.DataBind();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            string avail = snc.Availability;
            this.availability = Convert.ToInt32(avail);
            this.tooltxtAgent.Text = this.agent;
            this.tooltxtComunity.Text = this.comunity;
            this.tooltxtAvailability.Text = this.availability.ToString() + "%";
            this.MibIn = snc.MIBInData;
            this.MibOut = snc.MIBDataOut;
            this.parser = new ParserSNMP();
        }

        private void tmrPoll_Tick(object sender, EventArgs e)
        {
            Poll();
        }
        private void Save()
        {
            try
            {
                snc.Community = this.comunity;
                snc.AgentIP = this.agent;
                snc.Availability = this.availability.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Stop()
        {
            tmrPoll.Stop();
        }
        private void Start()
        {
            
            try
            {
                this.inOutTable = new dsInOut.DataInOutDataTable();
                tmrPoll.Interval = Convert.ToInt32(this.snc.PollInterval);
                //tmrPoll.Start();

                //Byte[] resultado = snmp.get(SNMP.Request.get, "localhost", "public", "1.3.6.1.2.1.1.5.0");
                Byte[] resultado = snmp.get(SNMP.Request.get, "localhost", "public", "1.3.6.1.2.1.2.2.1.10.12");
                ParserSNMP parser = new ParserSNMP();
                SNMPSequence seq = parser.ObtenerValor(resultado);
                MessageBox.Show(seq.Snmppdu.Valor);
                //ParseSNMPMessage(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigMonitor f = new frmConfigMonitor();
            f.ShowDialog();
        }

        private void tooltxtAgent_Leave(object sender, EventArgs e)
        {
            this.agent = tooltxtAgent.Text;
        }

        private void tooltxtComunity_Leave(object sender, EventArgs e)
        {
            this.comunity = tooltxtComunity.Text;
        }
        private void tooltxtAvailability_Leave(object sender, EventArgs e)
        {
            try
            {
                String avail = tooltxtAvailability.Text;
                avail = avail.Replace("%", "");
                this.availability = Convert.ToInt32(avail);
            }
            catch
            {
                MessageBox.Show("Solamente se permiten los siguientes caracteres:\n\r {1,2,3,4,5,6,7,8,9,0,%}");
                this.tooltxtAvailability.Focus();
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tooltxtAvailability_Click(object sender, EventArgs e)
        {

        }

       
    }
}
