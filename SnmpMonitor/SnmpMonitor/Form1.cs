﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnmpMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SnmpConector s = new SnmpConector();
            //s.Probar();
            SNMP sn = new SNMP();
            try
            {
                Byte[] resultado = sn.get(SNMP.Request.get, "localhost", "public", "1.3.6.1.2.1.1.5.0");
                ParseSNMPMessage(resultado);
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

    }
}
