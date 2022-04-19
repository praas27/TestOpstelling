using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kvaser.CanLib;

namespace TestOpstelling.Forms
{
    public partial class CAN_Monitor : Form
    {
        private static string DisplayError(Canlib.canStatus status, string routineName)
        {
            String errText = "";
            String error = "";
            if (status != Canlib.canStatus.canOK)
            {
                Canlib.canGetErrorText(status, out errText);
                error = "{2} failed: {0} = {1}" + status + errText + routineName;
                Environment.Exit(0);
            }
            else
            {
                error = "{0} suceeded" + routineName;
            }
            return error;
        }

        private static string DisplayMessage(int id, int dlc, byte[] data, int flags, long time)
        {
            String messege = "";
            if ((flags & Canlib.canMSGERR_OVERRUN) > 0)
            {
                messege = "********* RECIVE OVERRUN **********";
            }
            if ((flags & Canlib.canMSG_ERROR_FRAME) == Canlib.canMSG_ERROR_FRAME)
            {
                messege = "ErrorFrame                     {0}" + time;
            }
            else
            {
                /*messege = "{0:x8}" + id;
                if ((flags & Canlib.canMSG_EXT) == Canlib.canMSG_EXT)
                    messege = "X";
                else
                    messege = "  ";
                if ((flags & Canlib.canMSG_RTR) == Canlib.canMSG_RTR)
                    messege = "R";
                else
                    messege = "  ";
                if ((flags & Canlib.canMSG_TXACK) == Canlib.canMSG_TXACK)
                    messege = "A";
                else
                    messege = "  ";
                if ((flags & Canlib.canMSG_WAKEUP) == Canlib.canMSG_WAKEUP)
                    messege = "W";
                else
                    messege = "  ";
                messege = " {0:x1}" + dlc;
                for (int i = 0; i < 8; i++)
                {
                    if (i < dlc)
                        messege = " {0:x2}" + data[i];
                    else
                        messege = " ";
                }
                messege = " {0}" + time;*/
                messege = "Id: " + id + "     " + "DLC: " + dlc + "     "
                    + "Data: " + data[0] + " " + data[1] + " " + data[2] + " " + data[3] + " " + data[4] + " " + data[5] + " " + data[6] + " " + data[7]
                    + "     " + "Flags: " + flags + "     " + "Time: " + time;
            }
            return messege;
        }

        public CAN_Monitor()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Canlib.canStatus R;
            int V;

            tbMonitor.Clear();
            tbMonitor.Text = "DEMO VS2019\r\n";

            Canlib.canInitializeLibrary();

            V = Canlib.canGetVersionEx(Canlib.canVERSION_CANLIB32_PRODVER32);
            int V1 = (V & 0xFF0000) >> 16;
            int V2 = (V & 0xFF00) >> 8;
            tbMonitor.Text += string.Format("Found CANlib version {0}.{1}\r\n", V1, V2);

            R = Canlib.canGetNumberOfChannels(out int NOC);

            tbMonitor.Text += string.Format("Found {0} channels\r\n", NOC);
            tbMonitor.Text += "----------------------------------------\r\n";
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            //bool notFinished = true;

            Canlib.canStatus status;
            int chanHandle;

            Canlib.canInitializeLibrary();
            this.tbMonitor.Text += "can libirery Init\r\n";

            chanHandle = Canlib.canOpenChannel(0, Canlib.canOPEN_ACCEPT_VIRTUAL);
            this.tbMonitor.Text += DisplayError((Canlib.canStatus)chanHandle, "canChannelOpen\r\n");

            status = Canlib.canSetBusParams(chanHandle, Canlib.canBITRATE_50K, 0, 0, 0, 0);
            this.tbMonitor.Text += DisplayError(status, "canSetBusParams\r\n");

            status = Canlib.canBusOn(chanHandle);
            this.tbMonitor.Text += DisplayError(status, "canBusOn\r\n");

            //this.tbMonitor.Text += "ID   Flag    DLC Data                               Timestamp\r\n";
            //long i = 0;
            //while (notFinished)
            //{
                int id = 0;
                byte[] data = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                int flags = 0;
                int dlc = 0;
                long time = 0;

                status = Canlib.canReadWait(chanHandle, out id, data, out dlc, out flags, out time, 1000);
                
                if (status == Canlib.canStatus.canOK)
                {
                    this.tbMonitor.Text += DisplayMessage(id, dlc, data, flags, time)+"\r\n";
                }
                else if (status == Canlib.canStatus.canERR_NOMSG)
                {
                    //notFinished = false;
                    Canlib.canBusOff(chanHandle);
                    Canlib.canClose(chanHandle);
                    this.tbMonitor.Text += DisplayError(status, "canRead\r\n");
                }
            //}

            status = Canlib.canBusOff(chanHandle);
            this.tbMonitor.Text += DisplayError(status, "canBusOff\r\n");

            status = Canlib.canClose(chanHandle);
            tbMonitor.Text += DisplayError(status, "canClose\r\n");
        }
    }
}
