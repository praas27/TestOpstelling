using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kvaser.CanLib;
using static Kvaser.CanLib.Canlib;

namespace TestOpstelling.Forms
{
    public partial class GroundBedening : Form
    {
        private string scriptPath = @"D:\School\4ELO\Bachloarproef\GroundBediening.txe";
        private canStatus status;
        private int envvar_size;
        private int envvar_type;
        private int chanHandle = 0;
        private int slot = 0;
        private Color aan = Color.Green;
        private Color uit = Color.White;
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        private bool p1d = false;
        private bool p1u = false;
        private bool p2r = false;
        private bool p2l = false;
        private bool p3d = false;
        private bool p3u = false;
        private bool p4r = false;
        private bool p4l = false;
        private bool p5d = false;
        private bool p5u = false;
        private bool p6d = false;
        private bool p6u = false;
        private bool p7r = false;
        private bool p7l = false;

        private void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
            btnCon.Text = "Connect";
            foreach (string port in ports)
            {
                cbCom.Items.Add(port);
                if (ports[0] != null)
                {
                    cbCom.SelectedItem = ports[0];
                }
            }
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = cbCom.GetItemText(cbCom.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            btnCon.Text = "Disconnect";
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
            btnCon.Text = "Connect";
        }

        private void initCanBus()
        {
            Canlib.canInitializeLibrary();
            chanHandle = Canlib.canOpenChannel(chanHandle, Canlib.canOPEN_ACCEPT_VIRTUAL);
            status = Canlib.canSetBusParams(chanHandle, Canlib.canBITRATE_50K, 0, 0, 0, 0);
            tbStatus.Text += "Set canbus param: "+status;
            status = Canlib.canBusOn(chanHandle);
            tbStatus.Text += "\r\nCanbus on: " + status;
        }

        private void disableKnoppen()
        {
            btnP1D.Enabled = false;
            btnP1U.Enabled = false;
            btnP2R.Enabled = false;
            btnP2L.Enabled = false;
            btnP3D.Enabled = false;
            btnP3U.Enabled = false;
            btnP4R.Enabled = false;
            btnP4L.Enabled = false;
            btnP5D.Enabled = false;
            btnP5U.Enabled = false;
            btnP6D.Enabled = false;
            btnP6U.Enabled = false;
            btnP7R.Enabled = false;
            btnP7L.Enabled = false;
        }

        private void enableKnoppen()
        {
            btnP1D.Enabled = true;
            btnP1U.Enabled = true;
            btnP2R.Enabled = true;
            btnP2L.Enabled = true;
            btnP3D.Enabled = true;
            btnP3U.Enabled = true;
            btnP4R.Enabled = true;
            btnP4L.Enabled = true;
            btnP5D.Enabled = true;
            btnP5U.Enabled = true;
            btnP6D.Enabled = true;
            btnP6U.Enabled = true;
            btnP7R.Enabled = true;
            btnP7L.Enabled = true;
        }

        private void startScript()
        {
            status = Canlib.kvScriptLoadFile(chanHandle, slot, scriptPath);
            tbStatus.Text += "\r\nLoading script: " + status;
            status = kvScriptStart(chanHandle, slot);
            tbStatus.Text += "\r\nScript start: " + status;
            status = kvScriptStatus(chanHandle, slot, out int o);
            tbStatus.Text += "\r\nScript status: " + status + " - "+o;
        }

        public GroundBedening()
        {
            InitializeComponent();
            initCanBus();
            getAvailableComPorts();
        }

        private void btnP1D_Click(object sender, EventArgs e)
        {
            p1d = !p1d;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p1d)
            {
                disableKnoppen();
                btnP1D.Enabled = true;
                btnP1D.BackColor = aan;
                lbD0.Text = "P1D: 192";
                status = kvScriptEnvvarSetInt(knopD1, 64);
                lbD1.Text = "P1D: 64 "+ status;
                lbD2.Text = "P1D: 0";
                lbD3.Text = "P1D: 14";
            }
            else
            {
                enableKnoppen();
                btnP1D.BackColor = uit;
                lbD0.Text = "P1D: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P1D: 0 "+status;
                lbD2.Text = "P1D: 0";
                lbD3.Text = "P1D: 14";
            }
        }

        private void btnP1U_Click(object sender, EventArgs e)
        {
            p1u = !p1u;
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D0", out envvar_type, out envvar_size);
            if (p1u)
            {
                disableKnoppen();
                btnP1U.Enabled = true;
                btnP1U.BackColor = aan;
                status = kvScriptEnvvarSetInt(knopD0, 200);
                lbD0.Text = "P1U: 200 " + status;
                lbD1.Text = "P1U: 0";
                lbD2.Text = "P1U: 0";
                lbD3.Text = "P1U: 14";
            }
            else
            {
                enableKnoppen();
                btnP1U.BackColor = uit;
                status = kvScriptEnvvarSetInt(knopD0, 192);
                lbD0.Text = "P1U: 192 " + status;
                lbD1.Text = "P1U: 0";
                lbD2.Text = "P1U: 0";
                lbD3.Text = "P1U: 14";
            }
        }

        private void btnP2R_Click(object sender, EventArgs e)
        {
            p2r = !p2r;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p2r)
            {
                disableKnoppen();
                btnP2R.Enabled = true;
                btnP2R.BackColor = aan;
                lbD0.Text = "P2R: 192";
                status = kvScriptEnvvarSetInt(knopD1, 8);
                lbD1.Text = "P2R: 8 "+ status;
                lbD2.Text = "P2R: 0";
                lbD3.Text = "P2R: 14";
            }
            else
            {
                enableKnoppen();
                btnP2R.BackColor = uit;
                lbD0.Text = "P2R: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P2R: 0 " + status;
                lbD2.Text = "P2R: 0";
                lbD3.Text = "P2R: 14";
            }
        }

        private void btnP2L_Click(object sender, EventArgs e)
        {
            p2l = !p2l;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p2l)
            {
                disableKnoppen();
                btnP2L.Enabled = true;
                btnP2L.BackColor = aan;
                lbD0.Text = "P2L: 192";
                status = kvScriptEnvvarSetInt(knopD1, 128);
                lbD1.Text = "P2L: 128 " + status;
                lbD2.Text = "P2L: 0 ";
                lbD3.Text = "P2L: 14";
            }
            else
            {
                enableKnoppen();
                btnP2L.BackColor = uit;
                lbD0.Text = "P2L: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P2L: 0" + status;
                lbD2.Text = "P2L: 0";
                lbD3.Text = "P2L: 14";
            }
        }

        private void btnP3D_Click(object sender, EventArgs e)
        {
            p3d = !p3d;
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D2", out envvar_type, out envvar_size);
            if (p3d)
            {
                disableKnoppen();
                btnP3D.Enabled = true;
                btnP3D.BackColor = aan;

                lbD0.Text = "P3D: 192"; ;
                status = kvScriptEnvvarSetInt(knopD2, 64);
                lbD1.Text = "P3D: 64 "+status;
                lbD2.Text = "P3D: 0";
                lbD3.Text = "P3D: 14";
            }
            else
            {
                enableKnoppen();
                btnP3D.BackColor = uit;
                lbD0.Text = "P3D: 192";
                status = kvScriptEnvvarSetInt(knopD2, 0);
                lbD1.Text = "P3D: 0 "+status;
                lbD2.Text = "P3D: 0";
                lbD3.Text = "P3D: 14";
            }
        }

        private void btnP3U_Click(object sender, EventArgs e)
        {
            p3u = !p3u;
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D0", out envvar_type, out envvar_size);
            if (p3u)
            {
                disableKnoppen();
                btnP3U.Enabled = true;
                btnP3U.BackColor = aan;
                status = kvScriptEnvvarSetInt(knopD0, 193);
                lbD0.Text = "P3U: 193 " + status;
                lbD1.Text = "P3U: 0";
                lbD2.Text = "P3U: 0";
                lbD3.Text = "P3U: 14";
            }
            else
            {
                enableKnoppen();
                btnP3U.BackColor = uit;
                status = kvScriptEnvvarSetInt(knopD0, 192);
                lbD0.Text = "P3U: 192 " + status;
                lbD1.Text = "P3U: 0";
                lbD2.Text = "P3U: 0";
                lbD3.Text = "P3U: 14";
            }
        }

        private void btnP4R_Click(object sender, EventArgs e)
        {
            p4r = !p4r;
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D0", out envvar_type, out envvar_size);
            if (p4r)
            {
                disableKnoppen();
                btnP4R.Enabled = true;
                btnP4R.BackColor = aan;
                status = kvScriptEnvvarSetInt(knopD0, 194);
                lbD0.Text = "P4R: 194 " + status;
                lbD1.Text = "P4R: 0";
                lbD2.Text = "P4R: 0";
                lbD3.Text = "P4R: 14";
            }
            else
            {
                enableKnoppen();
                btnP4R.BackColor = uit;
                status = kvScriptEnvvarSetInt(knopD0, 192);
                lbD0.Text = "P4R: 192 " + status;
                lbD1.Text = "P4R: 0";
                lbD2.Text = "P4R: 0";
                lbD3.Text = "P4R: 14";
            }
        }

        private void btnP4L_Click(object sender, EventArgs e)
        {
            p4l = !p4l;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p4l)
            {
                disableKnoppen();
                btnP4L.Enabled = true;
                btnP4L.BackColor = aan;
                lbD0.Text = "P4L: 192";
                status = kvScriptEnvvarSetInt(knopD1, 4);
                lbD1.Text = "P4L: 4 " + status;
                lbD2.Text = "P4L: 0 ";
                lbD3.Text = "P4L: 14 ";
            }
            else
            {
                enableKnoppen();
                btnP4L.BackColor = uit;
                lbD0.Text = "P4L: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P4L: 0 " + status;
                lbD2.Text = "P4L: 0 ";
                lbD3.Text = "P4L: 14 ";
            }
        }

        private void btnP5D_Click(object sender, EventArgs e)
        {
            p5d = !p5d;
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D0", out envvar_type, out envvar_size);
            if (p5d)
            {
                disableKnoppen();
                btnP5D.Enabled = true;
                btnP5D.BackColor = aan;
                status = kvScriptEnvvarSetInt(knopD0, 208);
                lbD0.Text = "P5D: 208 " + status;
                lbD1.Text = "P5D: 0";
                lbD2.Text = "P3D: 0";
                lbD3.Text = "P3D: 14";
            }
            else
            {
                enableKnoppen();
                btnP5D.BackColor = uit;
                status = kvScriptEnvvarSetInt(knopD0, 192);
                lbD0.Text = "P3D: 192 " + status;
                lbD1.Text = "P3D: 0";
                lbD2.Text = "P3D: 0";
                lbD3.Text = "P3D: 14";
            }
        }

        private void btnP5U_Click(object sender, EventArgs e)
        {
            p5u = !p5u;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p5u)
            {
                disableKnoppen();
                btnP5U.Enabled = true;
                btnP5U.BackColor = aan;
                lbD0.Text = "P5U: 192";
                status = kvScriptEnvvarSetInt(knopD1, 2);
                lbD1.Text = "P5U: 2 " + status;
                lbD2.Text = "P5U: 0";
                lbD3.Text = "P5U: 14";
            }
            else
            {
                enableKnoppen();
                btnP5U.BackColor = uit;
                lbD0.Text = "P5U: 192 ";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P5U: 0 " +status;
                lbD2.Text = "P5U: 0";
                lbD3.Text = "P5U: 14";
            }
        }

        private void btnP6D_Click(object sender, EventArgs e)
        {
            p6d = !p6d;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p6d)
            {
                disableKnoppen();
                btnP6D.Enabled = true;
                btnP6D.BackColor = aan;
                lbD0.Text = "P6D: 192";
                status = kvScriptEnvvarSetInt(knopD1, 16);
                lbD1.Text = "P6D: 16 "+ status;
                lbD2.Text = "P6D: 0";
                lbD3.Text = "P6D: 14";
            }
            else
            {
                enableKnoppen();
                btnP6D.BackColor = uit;
                lbD0.Text = "P6D: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P6D: 0";
                lbD2.Text = "P6D: 0";
                lbD3.Text = "P6D: 14";
            }
        }

        private void btnP6U_Click(object sender, EventArgs e)
        {
            p6u = !p6u;
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D0", out envvar_type, out envvar_size);
            if (p6u)
            {
                disableKnoppen();
                btnP6U.Enabled = true;
                btnP6U.BackColor = aan;
                status = kvScriptEnvvarSetInt(knopD0, 224);
                lbD0.Text = "P6U: 224 " + status;
                lbD1.Text = "P6U: 0";
                lbD2.Text = "P6U: 0";
                lbD3.Text = "P6U: 14";
            }
            else
            {
                enableKnoppen();
                btnP6U.BackColor = uit;
                status = kvScriptEnvvarSetInt(knopD0, 0);
                lbD0.Text = "P5U: 192 "+status;
                lbD1.Text = "P5U: 0";
                lbD2.Text = "P5U: 0";
                lbD3.Text = "P5U: 14";
            }
        }

        private void btnP7R_Click(object sender, EventArgs e)
        {
            p7r = !p7r;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p7r)
            {
                disableKnoppen();
                btnP7R.Enabled = true;
                btnP7R.BackColor = aan;
                lbD0.Text = "P7R: 192";
                status = kvScriptEnvvarSetInt(knopD1, 1);
                lbD1.Text = "P7R: 1 " +status;
                lbD2.Text = "P7R: 0";
                lbD3.Text = "P7R: 14";
            }
            else
            {
                enableKnoppen();
                btnP7R.BackColor = uit;
                lbD0.Text = "P7R: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P7R: 0 "+status;
                lbD2.Text = "P7R: 0";
                lbD3.Text = "P7R: 14";
            }
        }

        private void btnP7L_Click(object sender, EventArgs e)
        {
            p7l = !p7l;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C658D1", out envvar_type, out envvar_size);
            if (p7l)
            {
                disableKnoppen();
                btnP7L.Enabled = true;
                btnP7L.BackColor = aan;
                lbD0.Text = "P4L: 192";
                status = kvScriptEnvvarSetInt(knopD1, 32);
                lbD1.Text = "P4L: 32 " + status;
                lbD2.Text = "P4L: 0 ";
                lbD3.Text = "P4L: 14 ";
            }
            else
            {
                enableKnoppen();
                btnP7L.BackColor = uit;
                lbD0.Text = "P4L: 192";
                status = kvScriptEnvvarSetInt(knopD1, 0);
                lbD1.Text = "P4L: 0 " + status;
                lbD2.Text = "P4L: 0 ";
                lbD3.Text = "P4L: 14 ";
            }
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                
                disconnectFromArduino();
                isConnected = false;
            }
            else
            {
                connectToArduino();
                
                isConnected = true;
            }
        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            status = kvScriptStop(chanHandle, slot, kvSCRIPT_STOP_NORMAL);
            tbStatus.Text += "\r\nScript stop: " + status;
            status = kvScriptUnload(chanHandle, slot);
            tbStatus.Text += "\r\nScript unload: " + status;
            port.Write("0");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            port.Write("3");
            startScript();
        }
    }
}
