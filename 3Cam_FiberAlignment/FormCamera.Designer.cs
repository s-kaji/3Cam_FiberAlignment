namespace _3Cam_FiberAlignment
{
    partial class FormCamera
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarGain = new System.Windows.Forms.TrackBar();
            this.trackBarExposure = new System.Windows.Forms.TrackBar();
            this.trackBarDigitalGain = new System.Windows.Forms.TrackBar();
            this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMaker = new System.Windows.Forms.ComboBox();
            this.labelResolution = new System.Windows.Forms.Label();
            this.checkBoxColumn = new System.Windows.Forms.CheckBox();
            this.checkBoxRow = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDigitalGain = new System.Windows.Forms.Label();
            this.labelGain = new System.Windows.Forms.Label();
            this.numericUpDownExposure = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxLive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDigitalGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExposure)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "カメラ番号";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "ゲイン";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(14, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "露出";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(14, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "デジタルゲイン";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(14, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "カメラメーカ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "サイズ H × W";
            // 
            // trackBarGain
            // 
            this.trackBarGain.AutoSize = false;
            this.trackBarGain.Location = new System.Drawing.Point(120, 112);
            this.trackBarGain.Maximum = 63;
            this.trackBarGain.Minimum = 1;
            this.trackBarGain.Name = "trackBarGain";
            this.trackBarGain.Size = new System.Drawing.Size(120, 20);
            this.trackBarGain.TabIndex = 2;
            this.trackBarGain.Value = 1;
            this.trackBarGain.Scroll += new System.EventHandler(this.trackBarGain_Scroll);
            // 
            // trackBarExposure
            // 
            this.trackBarExposure.AutoSize = false;
            this.trackBarExposure.LargeChange = 100;
            this.trackBarExposure.Location = new System.Drawing.Point(120, 152);
            this.trackBarExposure.Maximum = 10000;
            this.trackBarExposure.Name = "trackBarExposure";
            this.trackBarExposure.Size = new System.Drawing.Size(120, 20);
            this.trackBarExposure.SmallChange = 10;
            this.trackBarExposure.TabIndex = 2;
            this.trackBarExposure.Scroll += new System.EventHandler(this.trackBarExposure_Scroll);
            // 
            // trackBarDigitalGain
            // 
            this.trackBarDigitalGain.AutoSize = false;
            this.trackBarDigitalGain.LargeChange = 10;
            this.trackBarDigitalGain.Location = new System.Drawing.Point(120, 192);
            this.trackBarDigitalGain.Maximum = 511;
            this.trackBarDigitalGain.Name = "trackBarDigitalGain";
            this.trackBarDigitalGain.Size = new System.Drawing.Size(120, 20);
            this.trackBarDigitalGain.TabIndex = 2;
            this.trackBarDigitalGain.Scroll += new System.EventHandler(this.trackBarDigitalGain_Scroll);
            // 
            // numericUpDownNumber
            // 
            this.numericUpDownNumber.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownNumber.Location = new System.Drawing.Point(153, 80);
            this.numericUpDownNumber.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumber.Name = "numericUpDownNumber";
            this.numericUpDownNumber.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownNumber.TabIndex = 3;
            this.numericUpDownNumber.ValueChanged += new System.EventHandler(this.numericUpDownNumber_ValueChanged);
            // 
            // comboBoxMaker
            // 
            this.comboBoxMaker.Enabled = false;
            this.comboBoxMaker.FormattingEnabled = true;
            this.comboBoxMaker.Location = new System.Drawing.Point(143, 20);
            this.comboBoxMaker.Name = "comboBoxMaker";
            this.comboBoxMaker.Size = new System.Drawing.Size(121, 20);
            this.comboBoxMaker.TabIndex = 4;
            this.comboBoxMaker.Text = "SENTECH";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelResolution.Location = new System.Drawing.Point(150, 50);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(88, 15);
            this.labelResolution.TabIndex = 5;
            this.labelResolution.Text = "1944 x 2592";
            // 
            // checkBoxColumn
            // 
            this.checkBoxColumn.AutoSize = true;
            this.checkBoxColumn.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxColumn.Location = new System.Drawing.Point(53, 253);
            this.checkBoxColumn.Name = "checkBoxColumn";
            this.checkBoxColumn.Size = new System.Drawing.Size(86, 19);
            this.checkBoxColumn.TabIndex = 6;
            this.checkBoxColumn.Text = "垂直反転";
            this.checkBoxColumn.UseVisualStyleBackColor = true;
            this.checkBoxColumn.CheckedChanged += new System.EventHandler(this.checkBoxMirror_CheckedChanged);
            // 
            // checkBoxRow
            // 
            this.checkBoxRow.AutoSize = true;
            this.checkBoxRow.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxRow.Location = new System.Drawing.Point(167, 253);
            this.checkBoxRow.Name = "checkBoxRow";
            this.checkBoxRow.Size = new System.Drawing.Size(86, 19);
            this.checkBoxRow.TabIndex = 6;
            this.checkBoxRow.Text = "水平反転";
            this.checkBoxRow.UseVisualStyleBackColor = true;
            this.checkBoxRow.CheckedChanged += new System.EventHandler(this.checkBoxMirror_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(14, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "鏡面";
            // 
            // labelDigitalGain
            // 
            this.labelDigitalGain.AutoSize = true;
            this.labelDigitalGain.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDigitalGain.Location = new System.Drawing.Point(251, 200);
            this.labelDigitalGain.Name = "labelDigitalGain";
            this.labelDigitalGain.Size = new System.Drawing.Size(39, 15);
            this.labelDigitalGain.TabIndex = 7;
            this.labelDigitalGain.Text = "1000";
            // 
            // labelGain
            // 
            this.labelGain.AutoSize = true;
            this.labelGain.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelGain.Location = new System.Drawing.Point(251, 117);
            this.labelGain.Name = "labelGain";
            this.labelGain.Size = new System.Drawing.Size(39, 15);
            this.labelGain.TabIndex = 7;
            this.labelGain.Text = "1000";
            // 
            // numericUpDownExposure
            // 
            this.numericUpDownExposure.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownExposure.Location = new System.Drawing.Point(244, 152);
            this.numericUpDownExposure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownExposure.Name = "numericUpDownExposure";
            this.numericUpDownExposure.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownExposure.TabIndex = 8;
            this.numericUpDownExposure.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownExposure.ValueChanged += new System.EventHandler(this.numericUpDownExposure_ValueChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(143, 287);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(228, 287);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxLive
            // 
            this.checkBoxLive.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLive.Location = new System.Drawing.Point(17, 286);
            this.checkBoxLive.Name = "checkBoxLive";
            this.checkBoxLive.Size = new System.Drawing.Size(75, 24);
            this.checkBoxLive.TabIndex = 11;
            this.checkBoxLive.Text = "開始";
            this.checkBoxLive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxLive.UseVisualStyleBackColor = true;
            this.checkBoxLive.CheckedChanged += new System.EventHandler(this.checkBoxLive_CheckedChanged);
            // 
            // FormCamera
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(314, 322);
            this.Controls.Add(this.checkBoxLive);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericUpDownExposure);
            this.Controls.Add(this.labelGain);
            this.Controls.Add(this.labelDigitalGain);
            this.Controls.Add(this.checkBoxRow);
            this.Controls.Add(this.checkBoxColumn);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.comboBoxMaker);
            this.Controls.Add(this.numericUpDownNumber);
            this.Controls.Add(this.trackBarDigitalGain);
            this.Controls.Add(this.trackBarExposure);
            this.Controls.Add(this.trackBarGain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "カメラ設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCamera_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCamera_FormClosed);
            this.Load += new System.EventHandler(this.FormCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDigitalGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExposure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarGain;
        private System.Windows.Forms.TrackBar trackBarExposure;
        private System.Windows.Forms.TrackBar trackBarDigitalGain;
        private System.Windows.Forms.NumericUpDown numericUpDownNumber;
        private System.Windows.Forms.ComboBox comboBoxMaker;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.CheckBox checkBoxColumn;
        private System.Windows.Forms.CheckBox checkBoxRow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelDigitalGain;
        private System.Windows.Forms.Label labelGain;
        private System.Windows.Forms.NumericUpDown numericUpDownExposure;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxLive;
    }
}