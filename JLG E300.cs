using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestOpstelling
{
    public partial class E300 : Form
    {
        private Form activeForm;

        private void OpenSchildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelStart.Controls.Add(childForm);
            this.panelStart.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public E300()
        {
            InitializeComponent();
        }


            

        private void btnMonitor_Click_1(object sender, EventArgs e)
        {
            OpenSchildForm(new Forms.CAN_Monitor(), sender);
            pnlNav.Height = btnMonitor.Height;
            pnlNav.Top = btnMonitor.Top;
            pnlNav.Left = btnMonitor.Left;
            btnMonitor.ForeColor = Color.FromArgb(0, 129, 249);
        }

        private void btnGround_Click_1(object sender, EventArgs e)
        {
            OpenSchildForm(new Forms.GroundTest(), sender);
            pnlNav.Height = btnGround.Height;
            pnlNav.Top = btnGround.Top;
            pnlNav.Left = btnGround.Left;
            btnGround.ForeColor = Color.FromArgb(0, 129, 249);
        }

        private void btnPlatform_Click(object sender, EventArgs e)
        {
            OpenSchildForm(new Forms.PlatformModule(), sender);
            pnlNav.Height = btnPlatform.Height;
            pnlNav.Top = btnPlatform.Top;
            pnlNav.Left = btnPlatform.Left;
            btnPlatform.ForeColor = Color.FromArgb(0, 129, 249);
        }

        private void btnMonitor_Leave(object sender, EventArgs e)
        {
            btnMonitor.ForeColor = Color.FromArgb(147, 140, 151);
        }

        private void btnGround_Leave(object sender, EventArgs e)
        {
            btnGround.ForeColor = Color.FromArgb(147, 140, 151);
        }

        private void btnGroundScript_Click(object sender, EventArgs e)
        {
            OpenSchildForm(new Forms.GroundBedening(), sender);
            pnlNav.Height = btnGroundScript.Height;
            pnlNav.Top = btnGroundScript.Top;
            pnlNav.Left = btnGroundScript.Left;
            btnGroundScript.ForeColor = Color.FromArgb(0, 129, 249);
        }

        private void btnGroundScript_Leave(object sender, EventArgs e)
        {
            btnGroundScript.ForeColor = Color.FromArgb(147, 140, 151);
        }

        private void btnPlatform_Leave(object sender, EventArgs e)
        {
            btnPlatform.ForeColor = Color.FromArgb(147, 140, 151);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            OpenSchildForm(new Forms.Auto(), sender);
            pnlNav.Height = btnAuto.Height;
            pnlNav.Top = btnAuto.Top;
            pnlNav.Left = btnAuto.Left;
            btnAuto.ForeColor = Color.FromArgb(0, 129, 249);
        }

        private void btnAuto_Leave(object sender, EventArgs e)
        {
            btnAuto.ForeColor = Color.FromArgb(147, 140, 151);
        }
    }
}
