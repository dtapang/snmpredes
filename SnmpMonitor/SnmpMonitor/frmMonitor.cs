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
        private int errorCount = 0;
        private PollCounter32 dataInPoller;
        private PollCounter32 dataOutPoller;
        private Int32 valorAnteriorIn;
        private Int32 valorAnteriorOut;
        private SnmpConector snc;
        private SNMP snmp;
        private string comunity;
        private string agent;
        private string MibIn;
        private string MibOut;
        private int availability;
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
                this.dataInPoller.Poll();
                this.dataOutPoller.Poll();
                //Random r = new Random();
                //Byte[] resultadoIn = snmp.get(SNMP.Request.get, "localhost", this.comunity, this.MibIn);
                //Byte[] resultadoOut = snmp.get(SNMP.Request.get, "localhost", this.comunity, this.MibOut);
                //SNMPSequence datosIn = parser.ObtenerValor(resultadoIn);
                //SNMPSequence datosOut = parser.ObtenerValor(resultadoOut);
                
                //Int32 datoInActual = r.Next(0, 100);
                //Int32 datoOutActual = r.Next(0, 100);
                //Int32 datoInKbps = datoInActual;
                //Int32 datoOutKbps = datoOutActual;

                //Int32 datoInActual = Convert.ToInt32(datosIn.Snmppdu.Valor);
                //Int32 datoOutActual = Convert.ToInt32(datosOut.Snmppdu.Valor);
                //Int32 datoInKbps = DatosKbps(datoInActual);
                //Int32 datoOutKbps = DatosKbps(datoOutActual);
                Int32 datoInKbps = DatosKbps(this.dataInPoller.CounterDiff);
                Int32 datoOutKbps = DatosKbps(this.dataOutPoller.CounterDiff);

                this.txtIn.Text = datoInKbps.ToString();
                this.txtOut.Text = datoOutKbps.ToString();

                this.inOutTable.AddDataInOutRow(DateTime.Now, this.dataInPoller.Counter, datoInKbps, this.dataOutPoller.Counter, datoOutKbps);

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
                errorCount++;
                if (errorCount > 2)
                {
                    Stop();
                    errorCount = 0;
                }
                MessageBox.Show(ex.Message);
            }
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
            this.dataInPoller = new PollCounter32(this.agent, this.MibIn, this.comunity);
            this.dataOutPoller = new PollCounter32(this.agent, this.MibOut, this.comunity);
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
                //valorAnteriorIn = 0;
                //valorAnteriorOut = 0;
                this.inOutTable = new dsInOut.DataInOutDataTable();
                tmrPoll.Interval = Convert.ToInt32(this.snc.PollInterval);
                tmrPoll.Start();
                this.dataInPoller.Poll();
                this.dataOutPoller.Poll();

                ////Byte[] resultado = snmp.get(SNMP.Request.get, "localhost", "public", "1.3.6.1.2.1.1.5.0");"1.3.6.1.2.1.2.2.1.10.12"
                Byte[] resultado = snmp.get(SNMP.Request.get, "127.0.0.1", "public", this.MibIn + ".12");
                ParserSNMP parser = new ParserSNMP();
                SNMPSequence seq = parser.ObtenerValor(resultado);
                MessageBox.Show(seq.Snmppdu.Valor.ToString());
                //valorAnteriorIn = Convert.ToInt32(seq.Snmppdu.Valor);
                //valorAnteriorOut = 0;
                ////ParseSNMPMessage(resultado);
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
        private Int32 DatosKbpsOut(Int32 datoActual)
        {
            Int32 datoKbps = 0;
            if (datoActual < this.valorAnteriorOut)
            { }
            else
            {
                datoKbps = (datoActual - this.valorAnteriorOut) / (this.tmrPoll.Interval / 1000);
            }
            this.valorAnteriorOut = datoActual; ;
            return datoKbps / 1024;
        }
        private Int32 DatosKbpsIn(Int32 datoActual)
        {
            Int32 datoKbps = 0;
            if (datoActual < this.valorAnteriorIn)
            { }
            else
            {
                datoKbps = (datoActual - this.valorAnteriorIn) / (this.tmrPoll.Interval / 1000);
            }
            this.valorAnteriorIn = datoActual;
            return datoKbps / 1024;
        }
        private Int32 DatosKbps(Int32 valorIntervalo)
        {
            Int32 datoKbps = 0;
            datoKbps = valorIntervalo / (this.tmrPoll.Interval / 1000);
            return datoKbps / 1024;
        }

       
    }
}
