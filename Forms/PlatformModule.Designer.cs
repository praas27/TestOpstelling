
namespace TestOpstelling.Forms
{
    partial class PlatformModule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnP1D = new System.Windows.Forms.Button();
            this.btnP1U = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnP2D = new System.Windows.Forms.Button();
            this.btnP2U = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnP3D = new System.Windows.Forms.Button();
            this.btnP3U = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnP4D = new System.Windows.Forms.Button();
            this.btnP4U = new System.Windows.Forms.Button();
            this.trSnelheid = new System.Windows.Forms.TrackBar();
            this.btnY1D = new System.Windows.Forms.Button();
            this.btnY1U = new System.Windows.Forms.Button();
            this.btnY1R = new System.Windows.Forms.Button();
            this.btnY1L = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnY2L = new System.Windows.Forms.Button();
            this.btnY2R = new System.Windows.Forms.Button();
            this.btnY2U = new System.Windows.Forms.Button();
            this.btnY2D = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnVoet = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.lbD3 = new System.Windows.Forms.Label();
            this.lbD2 = new System.Windows.Forms.Label();
            this.lbD1 = new System.Windows.Forms.Label();
            this.lbD0 = new System.Windows.Forms.Label();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.btnCon = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnCheckGrounds = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trSnelheid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.panel3.Controls.Add(this.btnP1D);
            this.panel3.Controls.Add(this.btnP1U);
            this.panel3.Location = new System.Drawing.Point(90, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 200);
            this.panel3.TabIndex = 17;
            // 
            // btnP1D
            // 
            this.btnP1D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP1D.BackColor = System.Drawing.Color.White;
            this.btnP1D.Image = global::TestOpstelling.Properties.Resources.angle_square_down;
            this.btnP1D.Location = new System.Drawing.Point(12, 115);
            this.btnP1D.Name = "btnP1D";
            this.btnP1D.Size = new System.Drawing.Size(75, 75);
            this.btnP1D.TabIndex = 15;
            this.btnP1D.UseVisualStyleBackColor = false;
            this.btnP1D.Click += new System.EventHandler(this.btnP1D_Click);
            // 
            // btnP1U
            // 
            this.btnP1U.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP1U.BackColor = System.Drawing.Color.White;
            this.btnP1U.Image = global::TestOpstelling.Properties.Resources.angle_square_up;
            this.btnP1U.Location = new System.Drawing.Point(12, 14);
            this.btnP1U.Name = "btnP1U";
            this.btnP1U.Size = new System.Drawing.Size(75, 75);
            this.btnP1U.TabIndex = 14;
            this.btnP1U.UseVisualStyleBackColor = false;
            this.btnP1U.Click += new System.EventHandler(this.btnP1U_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.btnP2D);
            this.panel1.Controls.Add(this.btnP2U);
            this.panel1.Location = new System.Drawing.Point(210, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 200);
            this.panel1.TabIndex = 18;
            // 
            // btnP2D
            // 
            this.btnP2D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP2D.BackColor = System.Drawing.Color.White;
            this.btnP2D.Image = global::TestOpstelling.Properties.Resources.angle_square_down;
            this.btnP2D.Location = new System.Drawing.Point(12, 115);
            this.btnP2D.Name = "btnP2D";
            this.btnP2D.Size = new System.Drawing.Size(75, 75);
            this.btnP2D.TabIndex = 15;
            this.btnP2D.UseVisualStyleBackColor = false;
            this.btnP2D.Click += new System.EventHandler(this.btnP2D_Click);
            // 
            // btnP2U
            // 
            this.btnP2U.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP2U.BackColor = System.Drawing.Color.White;
            this.btnP2U.Image = global::TestOpstelling.Properties.Resources.angle_square_up;
            this.btnP2U.Location = new System.Drawing.Point(12, 14);
            this.btnP2U.Name = "btnP2U";
            this.btnP2U.Size = new System.Drawing.Size(75, 75);
            this.btnP2U.TabIndex = 14;
            this.btnP2U.UseVisualStyleBackColor = false;
            this.btnP2U.Click += new System.EventHandler(this.btnP2U_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Blue;
            this.panel2.Controls.Add(this.btnP3D);
            this.panel2.Controls.Add(this.btnP3U);
            this.panel2.Location = new System.Drawing.Point(430, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 200);
            this.panel2.TabIndex = 19;
            // 
            // btnP3D
            // 
            this.btnP3D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP3D.BackColor = System.Drawing.Color.White;
            this.btnP3D.Image = global::TestOpstelling.Properties.Resources.angle_square_down;
            this.btnP3D.Location = new System.Drawing.Point(12, 115);
            this.btnP3D.Name = "btnP3D";
            this.btnP3D.Size = new System.Drawing.Size(75, 75);
            this.btnP3D.TabIndex = 15;
            this.btnP3D.UseVisualStyleBackColor = false;
            this.btnP3D.Click += new System.EventHandler(this.btnP3D_Click);
            // 
            // btnP3U
            // 
            this.btnP3U.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP3U.BackColor = System.Drawing.Color.White;
            this.btnP3U.Image = global::TestOpstelling.Properties.Resources.angle_square_up;
            this.btnP3U.Location = new System.Drawing.Point(12, 14);
            this.btnP3U.Name = "btnP3U";
            this.btnP3U.Size = new System.Drawing.Size(75, 75);
            this.btnP3U.TabIndex = 14;
            this.btnP3U.UseVisualStyleBackColor = false;
            this.btnP3U.Click += new System.EventHandler(this.btnP3U_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.Controls.Add(this.btnP4D);
            this.panel4.Controls.Add(this.btnP4U);
            this.panel4.Location = new System.Drawing.Point(550, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 200);
            this.panel4.TabIndex = 20;
            // 
            // btnP4D
            // 
            this.btnP4D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP4D.BackColor = System.Drawing.Color.White;
            this.btnP4D.Image = global::TestOpstelling.Properties.Resources.angle_square_down;
            this.btnP4D.Location = new System.Drawing.Point(12, 115);
            this.btnP4D.Name = "btnP4D";
            this.btnP4D.Size = new System.Drawing.Size(75, 75);
            this.btnP4D.TabIndex = 15;
            this.btnP4D.UseVisualStyleBackColor = false;
            this.btnP4D.Click += new System.EventHandler(this.btnP4D_Click);
            // 
            // btnP4U
            // 
            this.btnP4U.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnP4U.BackColor = System.Drawing.Color.White;
            this.btnP4U.Image = global::TestOpstelling.Properties.Resources.angle_square_up;
            this.btnP4U.Location = new System.Drawing.Point(12, 14);
            this.btnP4U.Name = "btnP4U";
            this.btnP4U.Size = new System.Drawing.Size(75, 75);
            this.btnP4U.TabIndex = 14;
            this.btnP4U.UseVisualStyleBackColor = false;
            this.btnP4U.Click += new System.EventHandler(this.btnP4U_Click);
            // 
            // trSnelheid
            // 
            this.trSnelheid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trSnelheid.Location = new System.Drawing.Point(259, 281);
            this.trSnelheid.Name = "trSnelheid";
            this.trSnelheid.Size = new System.Drawing.Size(200, 56);
            this.trSnelheid.TabIndex = 21;
            this.trSnelheid.Scroll += new System.EventHandler(this.trSnelheid_Scroll);
            // 
            // btnY1D
            // 
            this.btnY1D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY1D.Image = global::TestOpstelling.Properties.Resources.angle_square_down;
            this.btnY1D.Location = new System.Drawing.Point(163, 525);
            this.btnY1D.Name = "btnY1D";
            this.btnY1D.Size = new System.Drawing.Size(75, 75);
            this.btnY1D.TabIndex = 22;
            this.btnY1D.UseVisualStyleBackColor = true;
            this.btnY1D.Click += new System.EventHandler(this.btnY1D_Click);
            // 
            // btnY1U
            // 
            this.btnY1U.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY1U.Image = global::TestOpstelling.Properties.Resources.angle_square_up;
            this.btnY1U.Location = new System.Drawing.Point(163, 383);
            this.btnY1U.Name = "btnY1U";
            this.btnY1U.Size = new System.Drawing.Size(75, 75);
            this.btnY1U.TabIndex = 23;
            this.btnY1U.UseVisualStyleBackColor = true;
            this.btnY1U.Click += new System.EventHandler(this.btnY1U_Click);
            // 
            // btnY1R
            // 
            this.btnY1R.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY1R.Image = global::TestOpstelling.Properties.Resources.angle_square_right;
            this.btnY1R.Location = new System.Drawing.Point(235, 455);
            this.btnY1R.Name = "btnY1R";
            this.btnY1R.Size = new System.Drawing.Size(75, 75);
            this.btnY1R.TabIndex = 24;
            this.btnY1R.UseVisualStyleBackColor = true;
            this.btnY1R.Click += new System.EventHandler(this.btnY1R_Click);
            // 
            // btnY1L
            // 
            this.btnY1L.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY1L.Image = global::TestOpstelling.Properties.Resources.angle_square_left;
            this.btnY1L.Location = new System.Drawing.Point(90, 455);
            this.btnY1L.Name = "btnY1L";
            this.btnY1L.Size = new System.Drawing.Size(75, 75);
            this.btnY1L.TabIndex = 25;
            this.btnY1L.UseVisualStyleBackColor = true;
            this.btnY1L.Click += new System.EventHandler(this.btnY1L_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.Blue;
            this.panel5.Location = new System.Drawing.Point(90, 383);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(220, 217);
            this.panel5.TabIndex = 26;
            // 
            // btnY2L
            // 
            this.btnY2L.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY2L.Image = global::TestOpstelling.Properties.Resources.angle_square_left;
            this.btnY2L.Location = new System.Drawing.Point(430, 455);
            this.btnY2L.Name = "btnY2L";
            this.btnY2L.Size = new System.Drawing.Size(75, 75);
            this.btnY2L.TabIndex = 30;
            this.btnY2L.UseVisualStyleBackColor = true;
            this.btnY2L.Click += new System.EventHandler(this.btnY2L_Click);
            // 
            // btnY2R
            // 
            this.btnY2R.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY2R.Image = global::TestOpstelling.Properties.Resources.angle_square_right;
            this.btnY2R.Location = new System.Drawing.Point(575, 455);
            this.btnY2R.Name = "btnY2R";
            this.btnY2R.Size = new System.Drawing.Size(75, 75);
            this.btnY2R.TabIndex = 29;
            this.btnY2R.UseVisualStyleBackColor = true;
            this.btnY2R.Click += new System.EventHandler(this.btnY2R_Click);
            // 
            // btnY2U
            // 
            this.btnY2U.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY2U.Image = global::TestOpstelling.Properties.Resources.angle_square_up;
            this.btnY2U.Location = new System.Drawing.Point(503, 383);
            this.btnY2U.Name = "btnY2U";
            this.btnY2U.Size = new System.Drawing.Size(75, 75);
            this.btnY2U.TabIndex = 28;
            this.btnY2U.UseVisualStyleBackColor = true;
            this.btnY2U.Click += new System.EventHandler(this.btnY2U_Click);
            // 
            // btnY2D
            // 
            this.btnY2D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnY2D.Image = global::TestOpstelling.Properties.Resources.angle_square_down;
            this.btnY2D.Location = new System.Drawing.Point(503, 525);
            this.btnY2D.Name = "btnY2D";
            this.btnY2D.Size = new System.Drawing.Size(75, 75);
            this.btnY2D.TabIndex = 27;
            this.btnY2D.UseVisualStyleBackColor = true;
            this.btnY2D.Click += new System.EventHandler(this.btnY2D_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.Color.Blue;
            this.panel6.Location = new System.Drawing.Point(430, 383);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(220, 217);
            this.panel6.TabIndex = 31;
            // 
            // btnVoet
            // 
            this.btnVoet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVoet.Location = new System.Drawing.Point(606, 665);
            this.btnVoet.Name = "btnVoet";
            this.btnVoet.Size = new System.Drawing.Size(121, 66);
            this.btnVoet.TabIndex = 32;
            this.btnVoet.Text = "VOET";
            this.btnVoet.UseVisualStyleBackColor = true;
            this.btnVoet.Click += new System.EventHandler(this.btnVoet_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbStatus.Location = new System.Drawing.Point(714, 161);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(192, 439);
            this.tbStatus.TabIndex = 33;
            // 
            // lbD3
            // 
            this.lbD3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbD3.AutoSize = true;
            this.lbD3.Location = new System.Drawing.Point(711, 126);
            this.lbD3.Name = "lbD3";
            this.lbD3.Size = new System.Drawing.Size(26, 17);
            this.lbD3.TabIndex = 37;
            this.lbD3.Text = "D3";
            // 
            // lbD2
            // 
            this.lbD2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbD2.AutoSize = true;
            this.lbD2.Location = new System.Drawing.Point(711, 93);
            this.lbD2.Name = "lbD2";
            this.lbD2.Size = new System.Drawing.Size(26, 17);
            this.lbD2.TabIndex = 36;
            this.lbD2.Text = "D2";
            // 
            // lbD1
            // 
            this.lbD1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbD1.AutoSize = true;
            this.lbD1.Location = new System.Drawing.Point(711, 57);
            this.lbD1.Name = "lbD1";
            this.lbD1.Size = new System.Drawing.Size(26, 17);
            this.lbD1.TabIndex = 35;
            this.lbD1.Text = "D1";
            // 
            // lbD0
            // 
            this.lbD0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbD0.AutoSize = true;
            this.lbD0.Location = new System.Drawing.Point(711, 24);
            this.lbD0.Name = "lbD0";
            this.lbD0.Size = new System.Drawing.Size(26, 17);
            this.lbD0.TabIndex = 34;
            this.lbD0.Text = "D0";
            // 
            // cbCom
            // 
            this.cbCom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(102, 668);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(121, 24);
            this.cbCom.TabIndex = 38;
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
            // 
            // btnCon
            // 
            this.btnCon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCon.Location = new System.Drawing.Point(102, 708);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(121, 23);
            this.btnCon.TabIndex = 39;
            this.btnCon.Text = "COM";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Location = new System.Drawing.Point(442, 665);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(121, 66);
            this.btnStop.TabIndex = 50;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Location = new System.Drawing.Point(285, 665);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 66);
            this.btnStart.TabIndex = 49;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM9";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnCheckGrounds
            // 
            this.btnCheckGrounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckGrounds.Location = new System.Drawing.Point(769, 668);
            this.btnCheckGrounds.Name = "btnCheckGrounds";
            this.btnCheckGrounds.Size = new System.Drawing.Size(121, 66);
            this.btnCheckGrounds.TabIndex = 51;
            this.btnCheckGrounds.Text = "GROUNDS";
            this.btnCheckGrounds.UseVisualStyleBackColor = true;
            this.btnCheckGrounds.Click += new System.EventHandler(this.btnCheckGrounds_Click);
            // 
            // PlatformModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.btnCheckGrounds);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.cbCom);
            this.Controls.Add(this.lbD3);
            this.Controls.Add(this.lbD2);
            this.Controls.Add(this.lbD1);
            this.Controls.Add(this.lbD0);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.btnVoet);
            this.Controls.Add(this.btnY2L);
            this.Controls.Add(this.btnY2R);
            this.Controls.Add(this.btnY2U);
            this.Controls.Add(this.btnY2D);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnY1L);
            this.Controls.Add(this.btnY1R);
            this.Controls.Add(this.btnY1U);
            this.Controls.Add(this.btnY1D);
            this.Controls.Add(this.trSnelheid);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlatformModule";
            this.Text = "PlatformModule";
            this.Load += new System.EventHandler(this.PlatformModule_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trSnelheid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnP1D;
        private System.Windows.Forms.Button btnP1U;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnP2D;
        private System.Windows.Forms.Button btnP2U;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnP3D;
        private System.Windows.Forms.Button btnP3U;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnP4D;
        private System.Windows.Forms.Button btnP4U;
        private System.Windows.Forms.TrackBar trSnelheid;
        private System.Windows.Forms.Button btnY1D;
        private System.Windows.Forms.Button btnY1U;
        private System.Windows.Forms.Button btnY1R;
        private System.Windows.Forms.Button btnY1L;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnY2L;
        private System.Windows.Forms.Button btnY2R;
        private System.Windows.Forms.Button btnY2U;
        private System.Windows.Forms.Button btnY2D;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnVoet;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label lbD3;
        private System.Windows.Forms.Label lbD2;
        private System.Windows.Forms.Label lbD1;
        private System.Windows.Forms.Label lbD0;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnCheckGrounds;
    }
}