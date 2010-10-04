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
    public partial class TrapSimulator : Form
    {
        public TrapSimulator()
        {
            InitializeComponent();
        }

        private void rdbLinkUp_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void SendTrap_Click(object sender, EventArgs e)
        {
            //Si el estado de la conexion es arriba, entonces mando un linkdown, de lo contrario manto un linkup
            //en la escucha del trap, deberia analizar el trap y detener o reanudar el contador
            if (rdbLinkDown.Checked)
            {
                SNMPTrapSend.Send(txtDestino.Text, 162, "down", GenericStatus.LinkDown);
            }
            else
            {
                SNMPTrapSend.Send(txtDestino.Text, 162, "up", GenericStatus.LinkUp);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
