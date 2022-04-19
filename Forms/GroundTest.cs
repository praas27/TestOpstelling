using Kvaser.CanLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestOpstelling.Forms
{
    public partial class GroundTest : Form
    {
        private int chanHandle = 0;
        private Canlib.canStatus status;
        private byte[] data648 = new byte[8] { 0, 0, 0, 0, 1, 0, 0, 11 };
        private byte[] data649 = new byte[8] { 128, 110, 129, 103, 128, 103, 248, 168 };
        private byte[] data650 = new byte[4] { 1, 8, 2, 2 };
        private byte[] data656 = new byte[8] { 0, 0, 0, 0, 1, 0, 0, 35 };
        private byte[] data657 = new byte[8] { 255, 255, 255, 255, 255, 0, 248, 248 };
        private byte[] data664 = new byte[4] { 2, 0, 0, 0 };
        private byte[] data667 = new byte[0] { };
        private byte[] data673 = new byte[8] { 121, 133, 102, 155, 20, 153, 128, 32 };
        private byte[] data676 = new byte[4] { 0, 0, 10, 246 };
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

        private void InitCanBus()
        {
            Canlib.canInitializeLibrary();
            chanHandle = Canlib.canOpenChannel(0, Canlib.canOPEN_ACCEPT_VIRTUAL);
            status = Canlib.canSetBusParams(chanHandle, Canlib.canBITRATE_50K, 0, 0, 0, 0);
            status = Canlib.canBusOn(chanHandle);
        }

        private void closeCanBus()
        {
            status = Canlib.canBusOff(chanHandle);
            status = Canlib.canClose(chanHandle);
        }

        private void canbusWrite(byte [] data658)
        {
            Canlib.canWrite(chanHandle, 648, data648, 8, 2);
            Canlib.canWrite(chanHandle, 649, data649, 8, 2);
            Canlib.canWrite(chanHandle, 650, data650, 4, 2);
            Canlib.canWrite(chanHandle, 656, data656, 8, 2);
            Canlib.canWrite(chanHandle, 657, data657, 8, 2);
            Canlib.canWrite(chanHandle, 658, data658, 4, 2);
            Canlib.canWrite(chanHandle, 664, data664, 4, 2);
            Canlib.canWrite(chanHandle, 673, data673, 8, 2);
            Canlib.canWrite(chanHandle, 676, data676, 4, 2);
        }

        private void initCansel()
        {
            bgP1D.WorkerSupportsCancellation = true;
            bgP1D.DoWork += new DoWorkEventHandler(bgP1D_DoWork);
            bgP1U.WorkerSupportsCancellation = true;
            bgP1U.DoWork += new DoWorkEventHandler(bgP1U_DoWork);
            bgP2R.WorkerSupportsCancellation = true;
            bgP2R.DoWork += new DoWorkEventHandler(bgP2R_DoWork);
            bgP2L.WorkerSupportsCancellation = true;
            bgP2L.DoWork += new DoWorkEventHandler(bgP2L_DoWork);
            bgP3D.WorkerSupportsCancellation = true;
            bgP3D.DoWork += new DoWorkEventHandler(bgP3R_DoWork);
            bgP3U.WorkerSupportsCancellation = true;
            bgP3U.DoWork += new DoWorkEventHandler(bgP3L_DoWork);
            bgP4R.WorkerSupportsCancellation = true;
            bgP4R.DoWork += new DoWorkEventHandler(bgP4D_DoWork);
            bgP4L.WorkerSupportsCancellation = true;
            bgP4L.DoWork += new DoWorkEventHandler(bgP4U_DoWork);
            bgP5D.WorkerSupportsCancellation = true;
            bgP5D.DoWork += new DoWorkEventHandler(bgP5D_DoWork);
            bgP5U.WorkerSupportsCancellation = true;
            bgP5U.DoWork += new DoWorkEventHandler(bgP5U_DoWork);
            bgP6D.WorkerSupportsCancellation = true;
            bgP6D.DoWork += new DoWorkEventHandler(bgP6D_DoWork);
            bgP6U.WorkerSupportsCancellation = true;
            bgP6U.DoWork += new DoWorkEventHandler(bgP6U_DoWork);
            bgP7R.WorkerSupportsCancellation = true;
            bgP7R.DoWork += new DoWorkEventHandler(bgP7R_DoWork);
            bgP7L.WorkerSupportsCancellation = true;
            bgP7L.DoWork += new DoWorkEventHandler(bgP7L_DoWork);
        }

        public GroundTest()
        {
            InitializeComponent();
            InitCanBus();
            initCansel();
            //canbusWrite(new byte[4] { 192, 0, 0, 14 });
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            while (true)
            {
                canbusWrite(new byte[4] { 192, 0, 0, 14 });
            }
            //closeCanBus();
        }

        private void btnP1D_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 128, 64, 0, 14 });
            p1d = !p1d;
            if (p1d)
            {
                bgP1D.RunWorkerAsync();
                btnP1D.BackColor = Color.Green;
            }
            else
            {
                bgP1D.CancelAsync();
                btnP1D.BackColor = Color.Blue;
            }  
        }

        private void btnP1U_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 136, 0, 0, 14 });
            p1u = !p1u;
            if (p1u)
            {
                bgP1U.RunWorkerAsync();
                btnP1U.BackColor = Color.Green;
            }
            else
            {
                bgP1U.CancelAsync();
                btnP1U.BackColor = Color.Blue;
            }
        }

        private void btnP2R_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 128, 8, 0, 14 });
            p2r = !p2r;
            if (p2r)
            {
                bgP2R.RunWorkerAsync();
                btnP2R.BackColor = Color.Green;
            }
            else
            {
                bgP2R.CancelAsync();
                btnP2R.BackColor = Color.Blue;
            }
        }

        private void btnP2L_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 128, 128, 0, 14 });
            p2l = !p2l;
            if (p2l)
            {
                bgP2L.RunWorkerAsync();
                btnP2L.BackColor = Color.Green;
            }
            else
            {
                bgP2L.CancelAsync();
                btnP2L.BackColor = Color.Blue;
            }
        }

        private void btnP3D_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 128, 0, 64, 14 });
            p3d = !p3d;
            if (p3d)
            {
                bgP3D.RunWorkerAsync();
                btnP3D.BackColor = Color.Green;
            }
            else
            {
                bgP3D.CancelAsync();
                btnP3D.BackColor = Color.Blue;
            }
        }

        private void btnP3U_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 129, 0, 0, 14 });
            p3u = !p3u;
            if (p3u)
            {
                bgP3U.RunWorkerAsync();
                btnP3U.BackColor = Color.Green;
            }
            else
            {
                bgP3U.CancelAsync();
                btnP3U.BackColor = Color.Blue;
            }
        }

        private void btnP4R_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 130, 0, 0, 14 });
            p4r = !p4r;
            if (p4r)
            {
                bgP4R.RunWorkerAsync();
                btnP4R.BackColor = Color.Green;
            }
            else
            {
                bgP4R.CancelAsync();
                btnP4R.BackColor = Color.Blue;
            }
        }

        private void btnP4L_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 128, 4, 0, 14 });
            p4l = !p4l;
            if (p4l)
            {
                bgP4L.RunWorkerAsync();
                btnP4L.BackColor = Color.Green;
            }
            else
            {
                bgP4L.CancelAsync();
                btnP4L.BackColor = Color.Blue;
            }
        }

        private void btnP5D_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 208, 0, 0, 14 });
            p5d = !p5d;
            if (p5d)
            {
                bgP5D.RunWorkerAsync();
                btnP5D.BackColor = Color.Green;
            }
            else
            {
                bgP5D.CancelAsync();
                btnP5D.BackColor = Color.Blue;
            }
        }

        private void btnP5U_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 192, 0, 0, 14 });
            p5u = !p5u;
            if (p5u)
            {
                bgP5U.RunWorkerAsync();
                btnP5U.BackColor = Color.Green;
            }
            else
            {
                bgP5U.CancelAsync();
                btnP5U.BackColor = Color.Blue;
            }
        }

        private void btnP6D_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 192, 16, 0, 14 });
            p6d = !p6d;
            if (p6d)
            {
                bgP6D.RunWorkerAsync();
                btnP6D.BackColor = Color.Green;
            }
            else
            {
                bgP6D.CancelAsync();
                btnP6D.BackColor = Color.Blue;
            }
        }

        private void btnP6U_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 224, 0, 0, 14 });
            p6u = !p6u;
            if (p6u)
            {
                bgP6U.RunWorkerAsync();
                btnP6U.BackColor = Color.Green;
            }
            else
            {
                bgP6U.CancelAsync();
                btnP6U.BackColor = Color.Blue;
            }
        }

        private void btnP7R_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 192, 1, 0, 14 });
            p7r = !p7r;
            if (p7r)
            {
                bgP7R.RunWorkerAsync();
                btnP7R.BackColor = Color.Green;
            }
            else
            {
                bgP7R.CancelAsync();
                btnP7R.BackColor = Color.Blue;
            }
        }

        private void btnP7L_Click(object sender, EventArgs e)
        {
            //canbusWrite(new byte[4] { 192, 32, 0, 14 });
            p7l = !p7l;
            if (p7l)
            {
                bgP7L.RunWorkerAsync();
                btnP7L.BackColor = Color.Green;
            }
            else
            {
                bgP7L.CancelAsync();
                btnP7L.BackColor = Color.Blue;
            }
        }

        private void bgP1D_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP1D.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 128, 64, 0, 14 });
            }
        }

        private void bgP1U_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP1U.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 136, 0, 0, 14 });
            }
        }

        private void bgP2R_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP2R.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 128, 8, 0, 14 });
            }
        }

        private void bgP2L_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP2L.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 128, 128, 0, 14 });
            }
        }

        private void bgP3R_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP3D.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 128, 0, 64, 14 });
            }
        }

        private void bgP3L_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP3U.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 129, 0, 0, 14 });
            }
        }

        private void bgP4D_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP4R.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 130, 0, 0, 14 });
            }
        }

        private void bgP4U_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP4L.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 128, 4, 0, 14 });
            }
        }

        private void bgP5D_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP5D.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 208, 0, 0, 14 });
            }
        }

        private void bgP5U_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP5U.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 192, 0, 0, 14 });
            }
        }

        private void bgP6D_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP6D.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 192, 16, 0, 14 });
            }
        }

        private void bgP6U_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP6U.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 224, 0, 0, 14 });
            }
        }

        private void bgP7R_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP7R.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 192, 1, 0, 14 });
            }
        }

        private void bgP7L_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bgP7L.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                canbusWrite(new byte[4] { 192, 32, 0, 14 });
            }
        }

        
    }
}
