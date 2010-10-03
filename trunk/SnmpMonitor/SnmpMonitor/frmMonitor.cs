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
        private SnmpConector snc;
        private SNMP snmp;
        private string comunity;
        private string agent;
        private string MibIn;
        private string MibOut;
        private int availability;
        private ParserSNMP parser;
        private dsInOut.DataInOutDataTable inOutTable;
        private Boolean statusLinkUp;
        private StopWatch disponibilidad;
        
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
                
                double datoInKbps = DatosKbps(this.dataInPoller.CounterDiff);
                double datoOutKbps = DatosKbps(this.dataOutPoller.CounterDiff);

                this.txtIn.Text = datoInKbps.ToString();
                this.txtOut.Text = datoOutKbps.ToString();
                this.toolStripKbin.Text = "Data In: " + datoInKbps.ToString() + " Kb/s";
                this.toolStripKbout.Text = "Data Out: " + datoOutKbps.ToString() + " Kb/s";

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
            this.tooltxtAgent.Text = this.agent;
            this.tooltxtCommunity.Text = this.comunity;
            this.tooltxtAvailability.Text = this.availability.ToString() + "%";
            this.MibIn = snc.MIBInData;
            this.MibOut = snc.MIBDataOut;
            this.parser = new ParserSNMP();
            int interfaceIndex = Convert.ToInt32(snc.InterfaceIndex);
            this.dataInPoller = new PollCounter32(this.agent, this.MibIn, interfaceIndex, this.comunity);
            this.dataOutPoller = new PollCounter32(this.agent, this.MibOut, interfaceIndex, this.comunity);
            this.statusLinkUp = true;
            this.disponibilidad = new StopWatch();
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
            DetenerProgressBar();
        }
        private void Start()
        {
            
            try
            {
                this.inOutTable = new dsInOut.DataInOutDataTable();
                tmrPoll.Interval = Convert.ToInt32(this.snc.PollInterval);
                this.dataInPoller.Poll();
                this.dataOutPoller.Poll();
                InicializarProgressBar(Convert.ToInt32(this.snc.PollInterval));
                tmrPoll.Start();


                //Byte[] resultado = snmp.get(SNMP.Request.get, "localhost", "public", "1.3.6.1.2.1.1.5.0");
                //"1.3.6.1.2.1.2.2.1.10.12"
                //Byte[] resultado = snmp.get(SNMP.Request.get, "127.0.0.1", "public", this.MibIn + ".12");
                //ParserSNMP parser = new ParserSNMP();
                //SNMPSequence seq = parser.ObtenerValor(resultado);
                //MessageBox.Show(seq.Snmppdu.Valor.ToString());
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
            frmConfigMonitor f = new frmConfigMonitor(this.snc);
            f.ShowDialog();
        }

        private void tooltxtAgent_Leave(object sender, EventArgs e)
        {
            this.agent = tooltxtAgent.Text;
        }

        private void tooltxtComunity_Leave(object sender, EventArgs e)
        {
            this.comunity = tooltxtDestTrap.Text;
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
        private double DatosKbps(Int32 valorIntervalo)
        {
            double datoKbps = 0;
            datoKbps = valorIntervalo / (this.tmrPoll.Interval / 1000);
            datoKbps = datoKbps / 1024;
            return Math.Round(datoKbps, 2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void tmrSeconds_Tick(object sender, EventArgs e)
        {
            if (this.toolStripPrgbr.Style == ProgressBarStyle.Marquee)
            {
                //this.toolStripPrgbr.MarqueeAnimationSpeed = 100;
            }
            else
            {
                this.toolStripPrgbr.PerformStep();
                if (this.toolStripPrgbr.ProgressBar.Value == this.toolStripPrgbr.Maximum)
                {
                    this.toolStripPrgbr.Value = this.toolStripPrgbr.Minimum;
                }
            }
        }
        private void InicializarProgressBar(int intervalo)
        {
            this.toolStripPrgbr.Value = this.toolStripPrgbr.Minimum;
            if (this.toolStripPrgbr.Style == ProgressBarStyle.Marquee)
            {
                this.toolStripPrgbr.Maximum = 100;
                this.toolStripPrgbr.Step = 10;
                this.toolStripPrgbr.MarqueeAnimationSpeed = 100;
            }
            else
            {
                this.toolStripPrgbr.Maximum = intervalo - 500;
                this.toolStripPrgbr.Step = 500;
            }
            this.tmrSeconds.Start();
        }
        private void DetenerProgressBar()
        {
            if (this.toolStripPrgbr.Style == ProgressBarStyle.Marquee)
            {
                this.toolStripPrgbr.MarqueeAnimationSpeed = 0;
            }
            this.toolStripPrgbr.Value = this.toolStripPrgbr.Minimum;
            this.tmrSeconds.Stop();
            
        }
        private void toolStripPrgbr_Click(object sender, EventArgs e)
        {

        }

        private void verDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGridDatos g = new frmGridDatos();
            g.dataGridView1.DataSource = this.inOutTable;
            g.dataGridView1.Refresh();
            g.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //Si el estado de la conexion es arriba, entonces mando un linkdown, de lo contrario manto un linkup
            //en la escucha del trap, deberia analizar el trap y detener o reanudar el contador
            if (statusLinkUp == true)
            {
                SNMPTrapSend.Send(tooltxtDestTrap.Text, 162, "trap de caida del link", GenericStatus.LinkDown);
            }
            else
            {
                SNMPTrapSend.Send(tooltxtDestTrap.Text, 162, "trap de subida del link", GenericStatus.LinkUp);
            }
 
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtDestinoTrap_Click(object sender, EventArgs e)
        {

        }

        private void tooltxtCommunity_Click(object sender, EventArgs e)
        {
            this.tooltxtDestTrap.Leave += new System.EventHandler(this.tooltxtComunity_Leave);
        }

       
    }
}
