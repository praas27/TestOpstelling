using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kvaser.CanLib;
using static Kvaser.CanLib.Canlib;

namespace TestOpstelling.Forms
{
    public partial class PlatformModule : Form
    {
        private string scriptPath = @"D:\School\4ELO\Bachloarproef\PlatformBediening.txe";

        private canStatus status;
        private int envvar_size;
        private int envvar_type;
        private int chanHandle = 0;
        private int slot = 0;
        private Color aan = Color.Green;
        private Color uit = Color.White;
        bool isConnected = false;
        String[] ports;
        //SerialPort port;
        private int pot = 30;
        private bool pVoet = false;
        string pin8 = "none";
        bool rrr = false;
        string[] checkAarding = new string[6];

        private void initCanBus()
        {
            Canlib.canInitializeLibrary();
            canBusOff(chanHandle);
            canClose(chanHandle);
            chanHandle = Canlib.canOpenChannel(chanHandle, Canlib.canOPEN_ACCEPT_VIRTUAL);
            status = Canlib.canSetBusParams(chanHandle, Canlib.canBITRATE_50K, 0, 0, 0, 0);
            tbStatus.Text += "Set canbus param: " + status;
            status = Canlib.canBusOn(chanHandle);
            tbStatus.Text += "\r\nCanbus on: " + status;
        }

        private void startScript()
        { 
            status = kvScriptLoadFile(chanHandle, slot, scriptPath);
            tbStatus.Text += "\r\nLoading script: " + status;
            status = kvScriptStart(chanHandle, slot);
            tbStatus.Text += "\r\nScript start: " + status;
            status = kvScriptStatus(chanHandle, slot, out int o);
            tbStatus.Text += "\r\nScript status: " + status + " - " + o;
        }

        private void btnUit()
        {
            btnP1D.BackColor = uit;
            btnP1U.BackColor = uit;
            btnP2D.BackColor = uit;
            btnP2U.BackColor = uit;
            btnP3D.BackColor = uit;
            btnP3U.BackColor = uit;
            btnP4D.BackColor = uit;
            btnP4U.BackColor = uit;
            btnY1D.BackColor = uit;
            btnY1U.BackColor = uit;
            btnY1R.BackColor = uit;
            btnY1L.BackColor = uit;
            btnY2D.BackColor = uit;
            btnY2U.BackColor = uit;
            btnY2R.BackColor = uit;
            btnY2L.BackColor = uit;
        }

        private void btnEn()
        {
            btnP1D.Enabled = true;
            btnP1U.Enabled = true;
            btnP2D.Enabled = true;
            btnP2U.Enabled = true;
            btnP3D.Enabled = true;
            btnP3U.Enabled = true;
            btnP4D.Enabled = true;
            btnP4U.Enabled = true;
        }

        private void btnDn()
        {
            btnP1D.Enabled = false;
            btnP1U.Enabled = false;
            btnP2D.Enabled = false;
            btnP2U.Enabled = false;
            btnP3D.Enabled = false;
            btnP3U.Enabled = false;
            btnP4D.Enabled = false;
            btnP4U.Enabled = false;
        }

        private void initPot()
        {
            trSnelheid.Maximum = 170;
            trSnelheid.Minimum = 30;
            trSnelheid.Value = pot;
            trSnelheid.SmallChange = 2;
            trSnelheid.LargeChange = 10;
        }

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

        private async void checkGrounds()
        {
            await Task.Delay(100);
            serialPort1.Write("a");
            await Task.Delay(100);
            serialPort1.Write("b");
            await Task.Delay(100);
            serialPort1.Write("c");
            await Task.Delay(100);
            serialPort1.Write("d");
            await Task.Delay(100);
            serialPort1.Write("e");
            await Task.Delay(100);
            serialPort1.Write("f");
        }

        private void connectToArduino()
        {
            isConnected = true;
            //string selectedPort = cbCom.GetItemText(cbCom.SelectedItem);
            serialPort1.PortName = cbCom.GetItemText(cbCom.SelectedItem);
            //port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            serialPort1.Open();
            btnCon.Text = "Disconnect";
            
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            serialPort1.Close();
            serialPort1.Close();
            btnCon.Text = "Connect";
        }

        public PlatformModule()
        {
            InitializeComponent();
            initCanBus();
            startScript();
            getAvailableComPorts();
            initPot();
        }

        private void btnVoet_Click(object sender, EventArgs e)
        {
            pVoet = !pVoet;
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            if (pVoet)
            {
                btnEn();
                btnUit();
                btnVoet.BackColor = aan;
                lbD0.Text = "D0: 1";
                status = kvScriptEnvvarSetInt(knopD1, 8);
                kvScriptEnvvarClose(knopD1);
                lbD1.Text = "D1: 8";
                status = kvScriptEnvvarSetInt(knopD2, 0);
                kvScriptEnvvarClose(knopD2);
                lbD2.Text = "D2: 0 "+status;
                lbD3.Text = "D3: 2";
                if (isConnected)
                    serialPort1.Write("2");
            }
            else
            {
                var C649D0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D0", out envvar_type, out envvar_size);
                status = kvScriptEnvvarSetInt(C649D0, 128);
                var C649D2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D2", out envvar_type, out envvar_size);
                btnY1U.BackColor = aan;
                status = kvScriptEnvvarSetInt(C649D2, 129);
                if (isConnected)
                    serialPort1.Write("1");
                    serialPort1.Write("7");
                btnDn();
                btnUit();
                btnVoet.BackColor = uit;
                lbD0.Text = "D0: 1";
                status = kvScriptEnvvarSetInt(knopD1, 8);
                kvScriptEnvvarClose(knopD1);
                lbD1.Text = "D1: 8 "+status;
                status = kvScriptEnvvarSetInt(knopD2, 2);
                lbD2.Text = "D2: 2 "+status;
                lbD3.Text = "D3: 2";
            }
        }

        private void btnP1D_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP1D.BackColor = aan;
            lbD0.Text = "D0: 1";
            status = kvScriptEnvvarSetInt(knopD1, 8);
            lbD1.Text = "D1: 8 "+status;
            status = kvScriptEnvvarSetInt(knopD2, 1);
            lbD2.Text = "D2: 1 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP1U_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP1U.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 "+status;
            status = kvScriptEnvvarSetInt(knopD1, 8);
            lbD1.Text = "D1: 8 "+status;
            status = kvScriptEnvvarSetInt(knopD2, 32);
            lbD2.Text = "D2: 32 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP2D_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP2D.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 " + status;
            status = kvScriptEnvvarSetInt(knopD1, 8);
            lbD1.Text = "D1: 8 "+status;
            status = kvScriptEnvvarSetInt(knopD2, 64);
            lbD2.Text = "D2: 64 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP2U_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP2U.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 " + status;
            status = kvScriptEnvvarSetInt(knopD1, 8);
            lbD1.Text = "D1: 8 "+status;
            status = kvScriptEnvvarSetInt(knopD2, 8);
            lbD2.Text = "D2: 8 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP3D_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP3D.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 " + status;
            status = kvScriptEnvvarSetInt(knopD1, 40);
            lbD1.Text = "D1: 40 " + status;
            status = kvScriptEnvvarSetInt(knopD2, 0);
            lbD2.Text = "D2: 0 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP3U_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP3U.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 " + status;
            status = kvScriptEnvvarSetInt(knopD1, 72);
            lbD1.Text = "D1: 72 " + status;
            status = kvScriptEnvvarSetInt(knopD2, 0);
            lbD2.Text = "D2: 0 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP4D_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP4D.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 " + status;
            status = kvScriptEnvvarSetInt(knopD1, 12);
            lbD1.Text = "D1: 12 " + status;
            status = kvScriptEnvvarSetInt(knopD2, 0);
            lbD2.Text = "D2: 0 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnP4U_Click(object sender, EventArgs e)
        {
            var knopD0 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D1", out envvar_type, out envvar_size);
            var knopD2 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D2", out envvar_type, out envvar_size);
            btnUit();
            btnP4U.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD0, 1);
            lbD0.Text = "D0: 1 "+ status;
            status = kvScriptEnvvarSetInt(knopD1, 10);
            lbD1.Text = "D1: 10 " + status;
            status = kvScriptEnvvarSetInt(knopD2, 0);
            lbD2.Text = "D2: 0 " + status;
            lbD3.Text = "D3: 2";
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                
                disconnectFromArduino();
            }
            else
            {
                connectToArduino();
            }
        }

        private void trSnelheid_Scroll(object sender, EventArgs e)
        {
            var potSnel = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D7", out envvar_type, out envvar_size);
            btnUit();
            status = kvScriptEnvvarSetInt(potSnel, trSnelheid.Value);
        }

        private void PlatformModule_Load(object sender, EventArgs e)
        {

        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnY1U_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D2", out envvar_type, out envvar_size);
            btnUit();
            btnY1U.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD1, 200);
        }

        private void btnY1D_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D2", out envvar_type, out envvar_size);
            btnUit();
            btnY1D.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD1, 0);
        }

        private void btnY1L_Click(object sender, EventArgs e)
        {

        }

        private void btnY1R_Click(object sender, EventArgs e)
        {

        }

        private void btnY2U_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D0", out envvar_type, out envvar_size);
            btnUit();
            btnY2U.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD1, 150);
            serialPort1.Write("6");
        }

        private void btnY2D_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C649D0", out envvar_type, out envvar_size);
            btnUit();
            btnY2D.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD1, 90);
            serialPort1.Write("6");
        }

        private void btnY2L_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            btnUit();
            btnY2L.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD1, 3);
            lbD0.Text = "D0: 3" +status;
            lbD1.Text = "D1: 8 ";
            lbD2.Text = "D2: 0 ";
            lbD3.Text = "D3: 2";
        }

        private void btnY2R_Click(object sender, EventArgs e)
        {
            var knopD1 = Canlib.kvScriptEnvvarOpen(chanHandle, "C650D0", out envvar_type, out envvar_size);
            btnUit();
            btnY2R.BackColor = aan;
            status = kvScriptEnvvarSetInt(knopD1, 5);
            lbD0.Text = "D0: 5" + status;
            lbD1.Text = "D1: 8 ";
            lbD2.Text = "D2: 0 ";
            lbD3.Text = "D3: 2";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            status = kvScriptStop(chanHandle, slot, kvSCRIPT_STOP_NORMAL);
            tbStatus.Text += "\r\nScript stop: " + status;
            status = kvScriptUnload(chanHandle, slot);
            tbStatus.Text += "\r\nScript unload: " + status;
            serialPort1.Write("0");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            serialPort1.Write("4");
            checkGrounds();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string data = serialPort1.ReadExisting();
                string[] sub = data.Split('.');
                if (sub[0] == "#PIN8")
                {
                    checkAarding[0] = sub[1];
                }
                else if (sub[0] == "#PIN10")
                {
                    checkAarding[1] = sub[1];
                }
                else if (sub[0] == "#PIN11")
                {
                    checkAarding[2] = sub[1];
                }
                else if (sub[0] == "#PIN5")
                {
                    checkAarding[3] = sub[1];
                }
                else if (sub[0] == "#PIN3")
                {
                    checkAarding[4] = sub[1];
                }
                else if (sub[0] == "#PIN14")
                {
                    checkAarding[5] = sub[1];
                }
            }
        }

        private void btnCheckGrounds_Click(object sender, EventArgs e)
        {
            tbStatus.Text += "\r\nground " + checkAarding[0];
            tbStatus.Text += "\r\nground " + checkAarding[1];
            tbStatus.Text += "\r\nground " + checkAarding[2];
            tbStatus.Text += "\r\nground " + checkAarding[3];
            tbStatus.Text += "\r\nground " + checkAarding[4];
            tbStatus.Text += "\r\nground " + checkAarding[5];
        }
    }
}
