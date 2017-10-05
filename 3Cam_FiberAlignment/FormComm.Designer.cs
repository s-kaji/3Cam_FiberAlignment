namespace _3Cam_FiberAlignment
{
    partial class FormComm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkConnect = new System.Windows.Forms.CheckBox();
            this.numReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.numWriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEncoding = new System.Windows.Forms.ComboBox();
            this.cboHandshake = new System.Windows.Forms.ComboBox();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.cboPortname = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReadTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkConnect);
            this.panel1.Controls.Add(this.numReadTimeout);
            this.panel1.Controls.Add(this.numWriteTimeout);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboEncoding);
            this.panel1.Controls.Add(this.cboHandshake);
            this.panel1.Controls.Add(this.cboStopBits);
            this.panel1.Controls.Add(this.cboParity);
            this.panel1.Controls.Add(this.cboDataBits);
            this.panel1.Controls.Add(this.cboBaudRate);
            this.panel1.Controls.Add(this.cboPortname);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 182);
            this.panel1.TabIndex = 109;
            // 
            // chkConnect
            // 
            this.chkConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chkConnect.Checked = true;
            this.chkConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkConnect.Location = new System.Drawing.Point(357, 7);
            this.chkConnect.Name = "chkConnect";
            this.chkConnect.Size = new System.Drawing.Size(75, 24);
            this.chkConnect.TabIndex = 7;
            this.chkConnect.Text = "接続";
            this.chkConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkConnect.UseVisualStyleBackColor = false;
            this.chkConnect.CheckedChanged += new System.EventHandler(this.chkConnect_CheckedChanged);
            // 
            // numReadTimeout
            // 
            this.numReadTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numReadTimeout.Location = new System.Drawing.Point(349, 145);
            this.numReadTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numReadTimeout.Name = "numReadTimeout";
            this.numReadTimeout.Size = new System.Drawing.Size(80, 19);
            this.numReadTimeout.TabIndex = 129;
            this.numReadTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numReadTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numWriteTimeout
            // 
            this.numWriteTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWriteTimeout.Location = new System.Drawing.Point(128, 145);
            this.numWriteTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWriteTimeout.Name = "numWriteTimeout";
            this.numWriteTimeout.Size = new System.Drawing.Size(80, 19);
            this.numWriteTimeout.TabIndex = 128;
            this.numWriteTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWriteTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 12);
            this.label12.TabIndex = 126;
            this.label12.Text = "文字コード";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 123;
            this.label6.Text = "パリティ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 122;
            this.label11.Text = "読取りタイムアウト[ms]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 121;
            this.label5.Text = "データビット";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 12);
            this.label10.TabIndex = 120;
            this.label10.Text = "書込みタイムアウト[ms]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 12);
            this.label9.TabIndex = 127;
            this.label9.Text = "ハンドシェイク";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 12);
            this.label8.TabIndex = 119;
            this.label8.Text = "ストップビット";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 12);
            this.label4.TabIndex = 118;
            this.label4.Text = "ボーレート";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 117;
            this.label1.Text = "ポート番号";
            // 
            // cboEncoding
            // 
            this.cboEncoding.FormattingEnabled = true;
            this.cboEncoding.Items.AddRange(new object[] {
            "ASCII コード",
            "Shift-JIS",
            "バイナリ(16進)"});
            this.cboEncoding.Location = new System.Drawing.Point(87, 44);
            this.cboEncoding.Name = "cboEncoding";
            this.cboEncoding.Size = new System.Drawing.Size(121, 20);
            this.cboEncoding.TabIndex = 111;
            this.cboEncoding.Text = "文字コード";
            this.cboEncoding.SelectedIndexChanged += new System.EventHandler(this.cboEncoding_SelectedIndexChanged);
            // 
            // cboHandshake
            // 
            this.cboHandshake.FormattingEnabled = true;
            this.cboHandshake.Items.AddRange(new object[] {
            "None",
            "XON/XOFF",
            "ハードウェア",
            "ハード&ソフト"});
            this.cboHandshake.Location = new System.Drawing.Point(87, 114);
            this.cboHandshake.Name = "cboHandshake";
            this.cboHandshake.Size = new System.Drawing.Size(121, 20);
            this.cboHandshake.TabIndex = 116;
            this.cboHandshake.Text = "ハンドシェイク";
            this.cboHandshake.SelectedIndexChanged += new System.EventHandler(this.cboHandshake_SelectedIndexChanged);
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "1.5"});
            this.cboStopBits.Location = new System.Drawing.Point(308, 114);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(121, 20);
            this.cboStopBits.TabIndex = 115;
            this.cboStopBits.Text = "ストップビット";
            this.cboStopBits.SelectedIndexChanged += new System.EventHandler(this.cboStopBits_SelectedIndexChanged);
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "None",
            "奇数",
            "偶数",
            "1",
            "0"});
            this.cboParity.Location = new System.Drawing.Point(87, 77);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 20);
            this.cboParity.TabIndex = 114;
            this.cboParity.Text = "パリティ";
            this.cboParity.SelectedIndexChanged += new System.EventHandler(this.cboParity_SelectedIndexChanged);
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(308, 79);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 20);
            this.cboDataBits.TabIndex = 113;
            this.cboDataBits.Text = "データビット";
            this.cboDataBits.SelectedIndexChanged += new System.EventHandler(this.cboDataBits_SelectedIndexChanged);
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "    2,400bps",
            "    4,800bps",
            "    9,600bps",
            "  19,200bps",
            "  38,400bps",
            "  57,600bps",
            "115,200bps"});
            this.cboBaudRate.Location = new System.Drawing.Point(308, 44);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 20);
            this.cboBaudRate.TabIndex = 112;
            this.cboBaudRate.Text = "ボーレート";
            this.cboBaudRate.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // cboPortname
            // 
            this.cboPortname.FormattingEnabled = true;
            this.cboPortname.Location = new System.Drawing.Point(87, 10);
            this.cboPortname.Name = "cboPortname";
            this.cboPortname.Size = new System.Drawing.Size(264, 20);
            this.cboPortname.TabIndex = 108;
            this.cboPortname.Text = "ポート番号";
            this.cboPortname.DropDown += new System.EventHandler(this.cboPortname_DropDown);
            this.cboPortname.SelectedIndexChanged += new System.EventHandler(this.cboPortname_SelectedIndexChanged);
            // 
            // FormComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 177);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormComm";
            this.Text = "com0com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormComm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormComm_FormClosed);
            this.Load += new System.EventHandler(this.FormComm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReadTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numReadTimeout;
        private System.Windows.Forms.NumericUpDown numWriteTimeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEncoding;
        private System.Windows.Forms.ComboBox cboHandshake;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.ComboBox cboPortname;
        public System.Windows.Forms.CheckBox chkConnect;
    }
}