using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace _3Cam_FiberAlignment
{
    public partial class FormCamera : Form
    {
        private HDevelopExport00 HDevExp = null;
        private HTuple WindowID = null;

        public string maker;        //カメラメーカ
        public int resoH;           //画像サイズ：高さ
        public int resoW;           //画像サイズ：幅
        public int number;          //カメラ番号
        public int gain;            //ゲイン
        public int exposure;        //露出時間
        public int digital_gain;    //デジタルゲイン
        public string mirror;       //鏡面

        public FormCamera()
        {
            InitializeComponent();

            FormMain.Instance.chkCAM1.Checked = false;
            FormMain.Instance.chkCAM2.Checked = false;
            FormMain.Instance.chkCAM3.Checked = false;
        }

        private void FormCamera_Load(object sender, EventArgs e)
        {
            HDevExp = new HDevelopExport00();

            this.maker = "Sentech";
            this.resoH = 1944;
            this.resoW = 2592;

            comboBoxMaker.Text = this.maker;
            labelResolution.Text = this.resoH.ToString() + " x " + this.resoW.ToString();
            if (this.number < (int)numericUpDownNumber.Minimum) this.number = (int)numericUpDownNumber.Minimum;
            if (this.number > (int)numericUpDownNumber.Maximum) this.number = (int)numericUpDownNumber.Maximum;
            numericUpDownNumber.Value = (decimal)this.number;
            if (this.gain < trackBarGain.Minimum) this.gain = trackBarGain.Minimum;
            if (this.gain > trackBarGain.Maximum) this.gain = trackBarGain.Maximum;
            trackBarGain.Value = this.gain;
            labelGain.Text = this.gain.ToString();
            if (this.exposure < trackBarExposure.Minimum) this.exposure = trackBarExposure.Minimum;
            if (this.exposure > trackBarExposure.Maximum) this.exposure = trackBarExposure.Maximum;
            trackBarExposure.Value = this.exposure;
            numericUpDownExposure.Value = (decimal)this.exposure;
            if (this.digital_gain < trackBarDigitalGain.Minimum) this.digital_gain = trackBarDigitalGain.Minimum;
            if (this.digital_gain > trackBarDigitalGain.Maximum) this.digital_gain = trackBarDigitalGain.Maximum;
            trackBarDigitalGain.Value = this.digital_gain;
            labelDigitalGain.Text = this.digital_gain.ToString();
            switch (this.mirror)
            {
                case "row":
                    checkBoxRow.Checked = true;
                    checkBoxColumn.Checked = false;
                    break;

                case "column":
                    checkBoxColumn.Checked = true;
                    checkBoxRow.Checked = false;
                    break;

                case "diagonal":
                    checkBoxRow.Checked = true;
                    checkBoxColumn.Checked = true;
                    break;

                default:
                    checkBoxRow.Checked = false;
                    checkBoxColumn.Checked = false;
                    this.mirror = "";
                    break;
            }
        }

        private void FormCamera_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            HDevExp.HDevelopStop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WindowID != null)
            {
                HDevExp.HDevelopStop();
                System.Threading.Thread.Sleep(200);
                WindowID = null;
                MessageBox.Show("Video Stop!!");
            }
            HDevExp.hv_number = numericUpDownNumber.Value.ToString();
            HDevExp.hv_gain = this.gain;
            HDevExp.hv_exposure = (double)this.exposure;
            HDevExp.hv_digital_gain = this.digital_gain;
            HDevExp.hv_mirror = this.mirror;
            int count = FormMain.Instance.HWCont;
            switch (count)
            {
                case 0:
                    //FormMain.Instance.chkCAM1.Checked = false;
                    //System.Threading.Thread.Sleep(300);
                    WindowID = FormMain.Instance.hWinCont1.HalconID;
                    //FormMain.Instance.chkCAM1.Checked = true;
                    break;

                case 1:
                    //FormMain.Instance.chkCAM2.Checked = false;
                    //System.Threading.Thread.Sleep(300);
                    WindowID = FormMain.Instance.hWinCont2.HalconID;
                    //FormMain.Instance.chkCAM2.Checked = true;
                    break;

                case 2:
                    //FormMain.Instance.chkCAM3.Checked = false;
                    //System.Threading.Thread.Sleep(300);
                    WindowID = FormMain.Instance.hWinCont3.HalconID;
                    //FormMain.Instance.chkCAM3.Checked = true;
                    break;

                default:
                    WindowID = null;
                    break;
            }

            //if (HDevExp == null)
            if (WindowID != null)
            {
                //HDevExp = new HDevelopExport00();
                HDevExp.InitHalcon();
                HDevExp.RunHalcon(WindowID);
            }

        }

        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.number = (int)numericUpDownNumber.Value;
            HDevExp.hv_number = this.number.ToString();
        }

        private void trackBarGain_Scroll(object sender, EventArgs e)
        {
            this.gain = trackBarGain.Value;
            HDevExp.hv_gain = this.gain;
            labelGain.Text = this.gain.ToString();
        }

        private void trackBarExposure_Scroll(object sender, EventArgs e)
        {
            this.exposure = trackBarExposure.Value;
            HDevExp.hv_exposure = (double)this.exposure;
            numericUpDownExposure.Value = (decimal)this.exposure;
        }

        private void numericUpDownExposure_ValueChanged(object sender, EventArgs e)
        {
            this.exposure = (int)numericUpDownExposure.Value;
            HDevExp.hv_exposure = (double)this.exposure;
            trackBarExposure.Value = this.exposure;
        }

        private void trackBarDigitalGain_Scroll(object sender, EventArgs e)
        {
            this.digital_gain = trackBarDigitalGain.Value;
            HDevExp.hv_digital_gain = this.digital_gain;
            labelDigitalGain.Text = this.digital_gain.ToString();
        }

        private void checkBoxMirror_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (checkBoxColumn.Checked)
            {
                if (checkBoxRow.Checked)
                {
                    this.mirror = "diagonal";
                }
                else
                {
                    this.mirror = "column";
                }
            }
            else
            {
                if (checkBoxRow.Checked)
                {
                    this.mirror = "row";
                }
                else
                {
                    this.mirror = "";
                }

            }
            HDevExp.hv_mirror = this.mirror;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBoxLive_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {   //LiveView開始
                cb.Text = "停止";
                HDevExp.hv_maker = this.maker;
                HDevExp.hv_resoH = this.resoH;
                HDevExp.hv_resoW = this.resoW;
                HDevExp.hv_number = this.number.ToString();
                HDevExp.hv_gain = this.gain;
                HDevExp.hv_exposure = (double)this.exposure;
                HDevExp.hv_digital_gain = this.digital_gain;
                HDevExp.hv_mirror = this.mirror;
                int count = FormMain.Instance.HWCont;
                switch (count)
                {
                    case 0:
                        WindowID = FormMain.Instance.hWinCont1.HalconID;
                        break;

                    case 1:
                        WindowID = FormMain.Instance.hWinCont2.HalconID;
                        break;

                    case 2:
                        WindowID = FormMain.Instance.hWinCont3.HalconID;
                        break;

                    default:
                        WindowID = null;
                        break;
                }

                if (WindowID != null)
                {
                    HDevExp.InitHalcon();
                    HDevExp.RunHalcon(WindowID);
                }
                else
                {
                    HDevExp = null;
                    cb.Checked = false;
                }
            }
            else
            {   //LiveView停止
                cb.Text = "開始";
                if (HDevExp != null) HDevExp.HDevelopStop();
                WindowID = null;
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
