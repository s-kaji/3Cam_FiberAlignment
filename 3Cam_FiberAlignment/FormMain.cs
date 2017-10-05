using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;


namespace _3Cam_FiberAlignment
{
    public partial class FormMain : Form
    {
        private HDevelopExport1 HDevExp1 = null;
        private HDevelopExport2 HDevExp2 = null;
        private HDevelopExport3 HDevExp3 = null;
        private string nameLanguage;                    //設定カルチャ言語
        public AppConfClass ac = new AppConfClass();
        public int HWCont;

        //FormMainオブジェクトを保持するためのフィールド
        private static FormMain _instance;

        //FormMainオブジェクトを取得、設定するためのプロパティ
        public static FormMain Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new FormMain();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public FormMain()
        {
            //InitializeComponent();        //カルチャ言語を設定してから読まないと言語変更ができない
            string symbolLanguage;          //カルチャ言語
            ac.AutoConnect = false;
            XmlSerializ.Read(out ac);       //XMLファイルの読込み
            if (ac.Language != null)
            {
                //言語切替
                nameLanguage = ac.Language.ToLower();   //小文字変換
                switch (nameLanguage)
                {
                    case "japanese":
                        symbolLanguage = "ja";
                        break;
                    case "english":
                        symbolLanguage = "en";
                        break;
                    case "chinese":
                        symbolLanguage = "zh";
                        break;
                    default:
                        //ユーザー インターフェイス カルチャの言語を設定
                        symbolLanguage = Thread.CurrentThread.CurrentUICulture.Name;
                        nameLanguage = "default";
                        break;
                }
            }
            else
            {
                //ユーザー インターフェイス カルチャの言語を設定
                symbolLanguage = Thread.CurrentThread.CurrentUICulture.Name;
                nameLanguage = "default";
            }

            //カルチャ情報の設定
            CultureInfo myCIintl = new CultureInfo(symbolLanguage, false);
            Thread.CurrentThread.CurrentUICulture = myCIintl;

            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormMain.Instance = this;

            //フォームの位置
            if (ac.StartPosition == null) ac.StartPosition = "";
            switch (ac.StartPosition.ToLower())
            {
                case "manual":
                    this.StartPosition = FormStartPosition.Manual;
                    this.Left = ac.X;
                    this.Top = ac.Y;
                    //this.Width = ac.Width;
                    //this.Height = ac.Height;
                    break;
                case "centerscreen":
                    this.StartPosition = FormStartPosition.CenterScreen;
                    break;
                case "windowsdefaultlocation":
                    this.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    break;
                default:
                    this.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    break;
            }

            //通信設定
            FormComm.Instance.portname = ac.portname;
            FormComm.Instance.readtimeout = ac.readtimeout;
            FormComm.Instance.writetimeout = ac.writetimeout;
            FormComm.Instance.baudrate = ac.baudrate;
            FormComm.Instance.databits = ac.databits;
            FormComm.Instance.parity = ac.parity;
            FormComm.Instance.stopbits = ac.stopbits;
            FormComm.Instance.handshake = ac.handshake;
            FormComm.Instance.encode = ac.encode;

            //自動通信接続
            if (ac.AutoConnect)
            {
                if (FormComm.Instance.Portset())
                {
                    FormComm.Instance.Connect(ac.portname);
                }
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            //モニタ複数台のときの位置に対応
            Form f = (Form)sender;
            if (f.Left < Screen.GetWorkingArea(f).Left)
            { f.Left = Screen.GetWorkingArea(f).Left; }
            if (f.Right > Screen.GetWorkingArea(f).Right)
            { f.Left = Screen.GetWorkingArea(f).Right - f.Width; }
            if (f.Top < Screen.GetWorkingArea(f).Top)
            { f.Top = Screen.GetWorkingArea(f).Top; }
            if (f.Bottom > Screen.GetWorkingArea(f).Bottom)
            { f.Top = Screen.GetWorkingArea(f).Bottom - f.Height; }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保存するクラス(AppConfClass)のインスタンスを作成
            ac.Language = nameLanguage;

            if (ac.StartPosition == "")
            {
                ac.StartPosition = "Manual";
            }

            //フォームの位置
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    ac.X = this.Location.X;
                    ac.Y = this.Location.Y;
                    break;
                case FormWindowState.Minimized:
                    break;
                case FormWindowState.Maximized:
                    break;
                default:
                    break;
            }

            //通信設定
            ac.portname = FormComm.Instance.portname;
            ac.readtimeout = FormComm.Instance.readtimeout;
            ac.writetimeout = FormComm.Instance.writetimeout;
            ac.baudrate = FormComm.Instance.baudrate;
            ac.databits = FormComm.Instance.databits;
            ac.parity = FormComm.Instance.parity;
            ac.stopbits = FormComm.Instance.stopbits;
            ac.handshake = FormComm.Instance.handshake;
            ac.encode = FormComm.Instance.encode;
            //ac.CameraConfig = new _3Cam_FiberAlignment[3];
            XmlSerializ.Write(ac);      //XMLファイルの書込み

            if (FormComm.Instance.IsConnected()) FormComm.Instance.Disconnect();
        }

        private void chkCAM1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCAM1.Checked)
            {
                chkCAM1.BackColor = SystemColors.Control;

                //Window2_Runメソッドを別のスレッドで実行する
                //Threadオブジェクトを作成する
                System.Threading.Thread t1 =
                    new System.Threading.Thread(
                    new System.Threading.ThreadStart(Window1_Run));
                t1.IsBackground = true;
                //スレッドを開始する
                t1.Start();
            }
            else
            {
                try
                {
                    chkCAM1.BackColor = Color.LightGreen;
                    HDevExp1.HDevelopStop();
                    HDevExp1 = null;
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void chkCAM2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCAM2.Checked)
            {
                chkCAM2.BackColor = SystemColors.Control;

                //Window2_Runメソッドを別のスレッドで実行する
                //Threadオブジェクトを作成する
                System.Threading.Thread t2 =
                    new System.Threading.Thread(
                    new System.Threading.ThreadStart(Window2_Run));
                t2.IsBackground = true;
                //スレッドを開始する
                t2.Start();
            }
            else
            {
                try
                {
                    chkCAM2.BackColor = Color.LightGreen;
                    HDevExp2.HDevelopStop();
                    HDevExp2 = null;
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void chkCAM3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCAM3.Checked)
            {
                chkCAM3.BackColor = SystemColors.Control;

                //Window3_Runメソッドを別のスレッドで実行する
                //Threadオブジェクトを作成する
                System.Threading.Thread t3 =
                    new System.Threading.Thread(
                    new System.Threading.ThreadStart(Window3_Run));
                t3.IsBackground = true;
                //スレッドを開始する
                t3.Start();
            }
            else
            {
                try
                {
                    chkCAM3.BackColor = Color.LightGreen;
                    HDevExp3.HDevelopStop();
                    HDevExp3 = null;
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void Window1_Run()
        {
            if (HDevExp1 == null)
            {
                HDevExp1 = new HDevelopExport1();
                HDevExp1.hv_maker = ac.CameraConfig[0].maker;
                HDevExp1.hv_resoH = ac.CameraConfig[0].resoH;
                HDevExp1.hv_resoW = ac.CameraConfig[0].resoW;
                HDevExp1.hv_number = ac.CameraConfig[0].number.ToString();
                HDevExp1.hv_gain = ac.CameraConfig[0].gain;
                HDevExp1.hv_exposure = (double)ac.CameraConfig[0].exposure;
                HDevExp1.hv_digital_gain = ac.CameraConfig[0].digital_gain;
                HDevExp1.hv_mirror = ac.CameraConfig[0].mirror;

                HTuple WindowID = hWinCont1.HalconID;
                HDevExp1.InitHalcon();
                HDevExp1.RunHalcon(WindowID);
            }
        }

        private void Window2_Run()
        {
            if (HDevExp2 == null)
            {
                HDevExp2 = new HDevelopExport2();
                HDevExp2.hv_maker = ac.CameraConfig[1].maker;
                HDevExp2.hv_resoH = ac.CameraConfig[1].resoH;
                HDevExp2.hv_resoW = ac.CameraConfig[1].resoW;
                HDevExp2.hv_number = ac.CameraConfig[1].number.ToString();
                HDevExp2.hv_gain = ac.CameraConfig[1].gain;
                HDevExp2.hv_exposure = (double)ac.CameraConfig[1].exposure;
                HDevExp2.hv_digital_gain = ac.CameraConfig[1].digital_gain;
                HDevExp2.hv_mirror = ac.CameraConfig[1].mirror;

                HTuple WindowID = hWinCont2.HalconID;
                HDevExp2.InitHalcon();
                HDevExp2.RunHalcon(WindowID);
            }
        }

        private void Window3_Run()
        {
            if (HDevExp3 == null)
            {
                HDevExp3 = new HDevelopExport3();
                HDevExp3.hv_maker = ac.CameraConfig[2].maker;
                HDevExp3.hv_resoH = ac.CameraConfig[2].resoH;
                HDevExp3.hv_resoW = ac.CameraConfig[2].resoW;
                HDevExp3.hv_number = ac.CameraConfig[2].number.ToString();
                HDevExp3.hv_gain = ac.CameraConfig[2].gain;
                HDevExp3.hv_exposure = (double)ac.CameraConfig[2].exposure;
                HDevExp3.hv_digital_gain = ac.CameraConfig[2].digital_gain;
                HDevExp3.hv_mirror = ac.CameraConfig[2].mirror;

                HTuple WindowID = hWinCont3.HalconID;
                HDevExp3.InitHalcon();
                HDevExp3.RunHalcon(WindowID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormComm.Instance.myPort_Send("Test kaji");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormComm.Instance.portname = "COM10";
            FormComm.Instance.readtimeout = 1000;
            FormComm.Instance.writetimeout = 1000;
            FormComm.Instance.baudrate = 9600;
            FormComm.Instance.databits = 8;
            FormComm.Instance.parity = System.IO.Ports.Parity.None;
            FormComm.Instance.stopbits = System.IO.Ports.StopBits.One;
            FormComm.Instance.handshake = System.IO.Ports.Handshake.None;
            FormComm.Instance.encode = "ASCII";
            if (FormComm.Instance.Portset())
            {
                FormComm.Instance.Connect("COM14");
            }
            //System.Threading.Thread.Sleep(200);
        }

        private void comboBoxSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            DialogResult result;

            HWCont = cb.SelectedIndex;
            switch (HWCont)
            {
                case 0:
                    chkCAM1.Checked = false;
                    FormCamera fc1 = new FormCamera();
                    fc1.maker = ac.CameraConfig[0].maker;
                    fc1.resoH = ac.CameraConfig[0].resoH;
                    fc1.resoW = ac.CameraConfig[0].resoW;
                    fc1.number = ac.CameraConfig[0].number;
                    fc1.gain = ac.CameraConfig[0].gain;
                    fc1.exposure = ac.CameraConfig[0].exposure;
                    fc1.digital_gain = ac.CameraConfig[0].digital_gain;
                    fc1.mirror = ac.CameraConfig[0].mirror;
                    result = fc1.ShowDialog();      //カメラ設定画面を開く
                    if (result == DialogResult.OK)
                    {
                        ac.CameraConfig[0].maker = fc1.maker;
                        ac.CameraConfig[0].resoH = fc1.resoH;
                        ac.CameraConfig[0].resoW = fc1.resoW;
                        ac.CameraConfig[0].number = fc1.number;
                        ac.CameraConfig[0].gain = fc1.gain;
                        ac.CameraConfig[0].exposure = fc1.exposure;
                        ac.CameraConfig[0].digital_gain = fc1.digital_gain;
                        ac.CameraConfig[0].mirror = fc1.mirror;
                    }
                    break;

                case 1:
                    chkCAM2.Checked = false;
                    FormCamera fc2 = new FormCamera();
                    fc2.maker = ac.CameraConfig[1].maker;
                    fc2.resoH = ac.CameraConfig[1].resoH;
                    fc2.resoW = ac.CameraConfig[1].resoW;
                    fc2.number = ac.CameraConfig[1].number;
                    fc2.gain = ac.CameraConfig[1].gain;
                    fc2.exposure = ac.CameraConfig[1].exposure;
                    fc2.digital_gain = ac.CameraConfig[1].digital_gain;
                    fc2.mirror = ac.CameraConfig[1].mirror;
                    result = fc2.ShowDialog();      //カメラ設定画面を開く
                    if (result == DialogResult.OK)
                    {
                        ac.CameraConfig[1].maker = fc2.maker;
                        ac.CameraConfig[1].resoH = fc2.resoH;
                        ac.CameraConfig[1].resoW = fc2.resoW;
                        ac.CameraConfig[1].number = fc2.number;
                        ac.CameraConfig[1].gain = fc2.gain;
                        ac.CameraConfig[1].exposure = fc2.exposure;
                        ac.CameraConfig[1].digital_gain = fc2.digital_gain;
                        ac.CameraConfig[1].mirror = fc2.mirror;
                    }
                    break;

                case 2:
                    chkCAM3.Checked = false;
                    FormCamera fc3 = new FormCamera();
                    fc3.maker = ac.CameraConfig[2].maker;
                    fc3.resoH = ac.CameraConfig[2].resoH;
                    fc3.resoW = ac.CameraConfig[2].resoW;
                    fc3.number = ac.CameraConfig[2].number;
                    fc3.gain = ac.CameraConfig[2].gain;
                    fc3.exposure = ac.CameraConfig[2].exposure;
                    fc3.digital_gain = ac.CameraConfig[2].digital_gain;
                    fc3.mirror = ac.CameraConfig[2].mirror;
                    result = fc3.ShowDialog();      //カメラ設定画面を開く
                    if (result == DialogResult.OK)
                    {
                        ac.CameraConfig[2].maker = fc3.maker;
                        ac.CameraConfig[2].resoH = fc3.resoH;
                        ac.CameraConfig[2].resoW = fc3.resoW;
                        ac.CameraConfig[2].number = fc3.number;
                        ac.CameraConfig[2].gain = fc3.gain;
                        ac.CameraConfig[2].exposure = fc3.exposure;
                        ac.CameraConfig[2].digital_gain = fc3.digital_gain;
                        ac.CameraConfig[2].mirror = fc3.mirror;
                    }
                    break;

                case 3:
                    //通信設定
                    FormComm.Instance.portname = ac.portname;
                    FormComm.Instance.readtimeout = ac.readtimeout;
                    FormComm.Instance.writetimeout = ac.writetimeout;
                    FormComm.Instance.baudrate = ac.baudrate;
                    FormComm.Instance.databits = ac.databits;
                    FormComm.Instance.parity = ac.parity;
                    FormComm.Instance.stopbits = ac.stopbits;
                    FormComm.Instance.handshake = ac.handshake;
                    FormComm.Instance.encode = ac.encode;
                    FormComm.Instance.ShowDialog();
                    break;

                default:
                    break;
            }
        }

    }

    public struct _3Cam_FiberAlignment
    {
        public string maker;        //カメラメーカ
        public int resoH;           //画像サイズ：高さ
        public int resoW;           //画像サイズ：幅
        public int number;          //カメラ番号
        public int gain;            //ゲイン
        public int exposure;        //露出時間
        public int digital_gain;    //デジタルゲイン
        public string mirror;       //鏡面
    }

    public struct AppConfClass
    {
        public string Language;             //言語
        public bool AutoConnect;            //起動時の自動COM接続
        public string StartPosition;        //表示される位置
                                            //Manual：座標指定　CenterScreen：中央　WindowsDefaultLocation：Windowsの既定位置    
        public int X;                       //位置(x座標)
        public int Y;                       //位置(y座標)
        //public int Width;                   //サイズ(幅)
        //public int Height;                  //サイズ(高さ)

        //public string write_newline;        //送信デリミタ 
        //public string read_newline;         //受信デリミタ 
        public string portname;             //ポート名 
        public int baudrate;                //ボーレート 
        public int databits;                //データビット "8"
        public Parity parity;               //パリティ  "無し"
        public StopBits stopbits;           //ストップビット "1"
        public Handshake handshake;         //フロー制御 "None"
        public int readtimeout;             //リードタイムアウト
        public int writetimeout;            //ライトタイムアウト
        public string encode;               //文字コード

        public _3Cam_FiberAlignment[] CameraConfig;
    }



}
