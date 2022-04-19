using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestOpstelling.Forms
{
    public partial class DoTesting : Form
    {
        //bool knop1 = false;

        

        public DoTesting()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*knop1 = (!knop1);
            prinTest();*/
        }

        private void DoTesting_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Leave(object sender, EventArgs e)
        {
            //knop1 = false;
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*int i = 0;
            while(knop1){
                textBox1.Text = i + "\r\n";
                i = i + 1;
                Thread.Sleep(2000);
            }*/
            
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            
            //knop1 = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            //knop1 = false;
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (true)
            {
                //textBox1.Text = i + "\n";
                i = i + 1;
                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(2000);
            }
            /*textBox1.Invoke(new Action(() =>{
                
            }));*/
                
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text = ""+e.ProgressPercentage;
        }
    }
}
