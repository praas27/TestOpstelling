using Kvaser.CanLib;
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
using static Kvaser.CanLib.Canlib;

namespace TestOpstelling.Forms
{
    public partial class Auto : Form
    {
        private string scriptPathPlatform = @"D:\School\4ELO\Bachloarproef\PlatformBediening.txe";
        private string scriptPathGroud = @"D:\School\4ELO\Bachloarproef\GroundBediening.txe";
        private canStatus status;
        private int envvar_size;
        private int envvar_type;
        private int chanHandle = 0;
        private int slot = 0;
        bool isConnected = false;
        String[] ports;
        private int s5 = 5000;
        private string[] checkAarding = new string[6] {"none","none","none", "none", "none", "none" };

        private async void atomatic()
        {
            startScript(scriptPathGroud);
            serialPort1.Write("3");
            tbStatus.Text += "\r\nPowermodule powerd in groud mode";
            await Task.Delay(s5);

            serialPort1.Write("a");
            tbStatus.Text += ("\r\n ground PIN8 "+checkAarding[0]);
            
            await Task.Delay(2000);
            serialPort1.Write("b");
            tbStatus.Text += ("\r\n ground PIN10 " + checkAarding[1]);
            await Task.Delay(2000);
            serialPort1.Write("c");
            tbStatus.Text += ("\r\n ground PIN11 " + checkAarding[2]);
            await Task.Delay(2000);
            serialPort1.Write("d");
            tbStatus.Text += ("\r\n ground PIN5 " + checkAarding[3]);
            await Task.Delay(2000);
            serialPort1.Write("e");
            tbStatus.Text += ("\r\n ground PIN3 " + checkAarding[4]);
            await Task.Delay(2000);
            serialPort1.Write("f");
            tbStatus.Text += ("\r\n ground PIN14 " + checkAarding[5]);
            await Task.Delay(2000);

            tbStatus.Text += "\r\n knop 1 aan";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 64);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 1 uit";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 2 aan";
            status = kvScriptEnvvarSetInt(knoppen("C658D0"), 200);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 2 uit";
            status = kvScriptEnvvarSetInt(knoppen("C658D0"), 192);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 3 aan";
            status = kvScriptEnvvarSetInt(knoppen("C658D1"), 8);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 3 uit";
            status = kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 4 aan";
            status = kvScriptEnvvarSetInt(knoppen("C658D1"), 128);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 4 uit";
            status = kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 5 aan";
            kvScriptEnvvarSetInt(knoppen("C658D2"), 64);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 5 uit";
            kvScriptEnvvarSetInt(knoppen("C658D2"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 6 aan";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 193);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 6 uit";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 192);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 7 aan";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 194);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 7 uit";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 192);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 8 aan";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 4);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 8 uit";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 9 aan";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 208);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 9 uit";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 192);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 10 aan";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 2);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 10 uit";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 11 aan";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 16);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 11 uit";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 12 aan";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 224);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 12 uit";
            kvScriptEnvvarSetInt(knoppen("C658D0"), 192);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 13 aan";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 1);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 13 uit";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\n knop 14 aan";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 32);
            await Task.Delay(s5);
            tbStatus.Text += "\r\n knop 14 uit";
            kvScriptEnvvarSetInt(knoppen("C658D1"), 0);
            await Task.Delay(s5);

            status = kvScriptStop(chanHandle, slot, kvSCRIPT_STOP_NORMAL);
            tbStatus.Text += "\r\nScript stop: " + status;
            status = kvScriptUnload(chanHandle, slot);
            tbStatus.Text += "\r\nScript unload: " + status;
            tbStatus.Text += "\r\nPowermodule powerd off";
            serialPort1.Write("0");
            await Task.Delay(10000);

            tbStatus.Text += "\r\nPowermodule powerd in platform mode";
            serialPort1.Write("4");
            startScript(scriptPathPlatform);
            await Task.Delay(s5);

            
            tbStatus.Text += "\r\nFootswitch ingedrukt";
            serialPort1.Write("2");
            kvScriptEnvvarSetInt(knoppen("C650D2"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 1";
            kvScriptEnvvarSetInt(knoppen("C650D2"), 1);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 2";
            kvScriptEnvvarSetInt(knoppen("C650D2"), 32);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 3";
            kvScriptEnvvarSetInt(knoppen("C650D2"), 64);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 4";
            kvScriptEnvvarSetInt(knoppen("C650D2"), 8);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 5";
            kvScriptEnvvarSetInt(knoppen("C650D1"), 40);
            kvScriptEnvvarSetInt(knoppen("C650D2"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 6";
            kvScriptEnvvarSetInt(knoppen("C650D1"), 72);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 7";
            kvScriptEnvvarSetInt(knoppen("C650D1"), 12);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop 8";
            kvScriptEnvvarSetInt(knoppen("C650D1"), 10);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nknop reset";
            kvScriptEnvvarSetInt(knoppen("C650D1"), 8);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystick links";
            kvScriptEnvvarSetInt(knoppen("C650D0"), 3);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystic neurtraal";
            kvScriptEnvvarSetInt(knoppen("C650D0"), 1);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystick rechts";
            kvScriptEnvvarSetInt(knoppen("C650D0"), 5);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystic neurtraal";
            kvScriptEnvvarSetInt(knoppen("C650D0"), 1);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystic 1 up";
            kvScriptEnvvarSetInt(knoppen("C649D2"), 200);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystick 1 down ";
            kvScriptEnvvarSetInt(knoppen("C649D2"), 0);
            await Task.Delay(s5);

            tbStatus.Text += "\r\njoystick 1 reset ";
            kvScriptEnvvarSetInt(knoppen("C649D2"), 129);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nrijden achteruit ";
            serialPort1.Write("6");
            kvScriptEnvvarSetInt(knoppen("C649D0"), 90);
            await Task.Delay(10000);

            tbStatus.Text += "\r\nrijden neutraal ";
            serialPort1.Write("7");
            kvScriptEnvvarSetInt(knoppen("C649D0"), 128);
            await Task.Delay(s5);

            tbStatus.Text += "\r\nFootswitch los";
            serialPort1.Write("1");
            kvScriptEnvvarSetInt(knoppen("C650D2"), 2);
            await Task.Delay(10000);

            status = kvScriptStop(chanHandle, slot, kvSCRIPT_STOP_NORMAL);
            tbStatus.Text += "\r\nScript stop: " + status;
            status = kvScriptUnload(chanHandle, slot);
            tbStatus.Text += "\r\nScript unload: " + status;
            tbStatus.Text += "\r\nPowermodule powerd off";
            serialPort1.Write("0");
        }

        private void initCanBus()
        {
            Canlib.canInitializeLibrary();
            chanHandle = Canlib.canOpenChannel(chanHandle, Canlib.canOPEN_ACCEPT_VIRTUAL);
            status = Canlib.canSetBusParams(chanHandle, Canlib.canBITRATE_50K, 0, 0, 0, 0);
            tbStatus.Text += "Set canbus param: " + status;
            status = Canlib.canBusOn(chanHandle);
            tbStatus.Text += "\r\nCanbus on: " + status;
        }

        private void startScript(string scriptPath)
        {
            status = kvScriptLoadFile(chanHandle, slot, scriptPath);
            tbStatus.Text += "\r\nLoading script: " + status;
            status = kvScriptStart(chanHandle, slot);
            tbStatus.Text += "\r\nScript start: " + status;
            status = kvScriptStatus(chanHandle, slot, out int o);
            tbStatus.Text += "\r\nScript status: " + status + " - " + o;
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

        private void connectToArduino()
        {
            isConnected = true;
            serialPort1.PortName = cbCom.GetItemText(cbCom.SelectedItem);
            serialPort1.Open();
            btnCon.Text = "Disconnect";
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            serialPort1.Close();
            btnCon.Text = "Connect";
        }

        private long knoppen(string id)
        {
            long knop = Canlib.kvScriptEnvvarOpen(chanHandle, id, out envvar_type, out envvar_size);
            return knop;
        }

        public Auto()
        {
            InitializeComponent();
        }

        private void tbStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (isConnected)
            {
                initCanBus();
                //tbStatus.SelectionStart = tbStatus.TextLength;
                //tbStatus.ScrollToCaret();
                //groundLine();
                atomatic();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                status = kvScriptStop(chanHandle, slot, kvSCRIPT_STOP_NORMAL);
                tbStatus.Text += "\r\nScript stop: " + status;
                status = kvScriptUnload(chanHandle, slot);
                tbStatus.Text += "\r\nScript unload: " + status;
                tbStatus.Text += "\r\nPowermodule powerd off";
                serialPort1.Write("0");
            }
        }

        private void Auto_Load(object sender, EventArgs e)
        {
            getAvailableComPorts();
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

        private  void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadExisting();
            string[] sub = data.Split('.');
            //string[] rrr = checkAarding;
            switch (sub[0])
            {
                case "#PIN8":
                    checkAarding[0] = sub[1];
                    break;
                case "#PIN10":
                    checkAarding[1] = sub[1];
                    break;
                case "#PIN11":
                    checkAarding[2] = sub[1];
                    break;
                case "#PIN5":
                    checkAarding[3] = sub[1];
                    break ;
                case "#PIN3":
                    checkAarding[4] = sub[1];
                    break;
                case "#PIN14":
                    checkAarding[5] = sub[1];
                    break;
            }
        }
    }
}
