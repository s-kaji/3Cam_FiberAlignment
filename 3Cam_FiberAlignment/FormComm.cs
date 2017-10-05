using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;

namespace _3Cam_FiberAlignment
{
    public partial class FormComm : Form
    {
        //ただ一つのフォームのインスタンスを保持するフィールド
        private static FormComm _instance;

        public bool flagConnected;                      //232C接続状態
        public SerialPort myPort = new SerialPort();    //SerialPortクラスのインスタンス作成
        
        //通信設定
        //public string write_newline;                //送信デリミタ 
        //public string read_newline;                 //受信デリミタ 
        public string portname;                     //ポート名 
        public int baudrate;                        //ボーレート 
        public int databits;                        //データビット "8"
        public Parity parity;                       //パリティ  "無し"
        public StopBits stopbits;                   //ストップビット "1"
        public Handshake handshake;                 //フロー制御 "None"
        public int readtimeout;                     //リードタイムアウト
        public int writetimeout;                    //ライトタイムアウト
        public string encode;                       //文字コード

        private string str_s = "";                  //STX文字（0x02）
        private string str_e = "";                  //ETX文字（0x03）

        public FormComm()
        {
            InitializeComponent();
        }

        public static FormComm Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FormComm();
                }
                return _instance;
            }
        }

        private void FormComm_Load(object sender, EventArgs e)
        {
            //通信設定の表示
            switch (this.baudrate)
            {
                case 2400:
                    this.cboBaudRate.SelectedIndex = 0;
                    break;
                case 4800:
                    this.cboBaudRate.SelectedIndex = 1;
                    break;
                case 9600:
                    this.cboBaudRate.SelectedIndex = 2;
                    break;
                case 19200:
                    this.cboBaudRate.SelectedIndex = 3;
                    break;
                case 38400:
                    this.cboBaudRate.SelectedIndex = 4;
                    break;
                case 57600:
                    this.cboBaudRate.SelectedIndex = 5;
                    break;
                case 115200:
                    this.cboBaudRate.SelectedIndex = 6;
                    break;
                default:
                    this.cboBaudRate.SelectedIndex = 2;
                    break;
            }

            this.cboDataBits.Text = this.databits.ToString();

            switch (this.parity)
            {
                case Parity.None:
                    this.cboParity.SelectedIndex = 0;
                    break;
                case Parity.Odd:
                    this.cboParity.SelectedIndex = 1;
                    break;
                case Parity.Even:
                    this.cboParity.SelectedIndex = 2;
                    break;
                case Parity.Mark:
                    this.cboParity.SelectedIndex = 3;
                    break;
                case Parity.Space:
                    this.cboParity.SelectedIndex = 4;
                    break;
                default:
                    this.cboParity.SelectedIndex = 0;
                    break;
            }

            switch (this.stopbits)
            {
                case StopBits.One:
                    this.cboStopBits.SelectedIndex = 0;
                    break;
                case StopBits.Two:
                    this.cboStopBits.SelectedIndex = 1;
                    break;
                case StopBits.OnePointFive:
                    this.cboStopBits.SelectedIndex = 2;
                    break;
                default:
                    this.cboStopBits.SelectedIndex = 0;
                    break;
            }

            switch (this.handshake)
            {
                case Handshake.None:
                    this.cboHandshake.SelectedIndex = 0;
                    break;
                case Handshake.XOnXOff:
                    this.cboHandshake.SelectedIndex = 1;
                    break;
                case Handshake.RequestToSend:
                    this.cboHandshake.SelectedIndex = 2;
                    break;
                case Handshake.RequestToSendXOnXOff:
                    this.cboHandshake.SelectedIndex = 3;
                    break;
                default:
                    this.cboHandshake.SelectedIndex = 0;
                    break;
            }

            switch (this.encode)
            {
                case "ASCII":   //ASCII
                    this.cboEncoding.SelectedIndex = 0;
                    break;
                case "JIS":     //Shift-JIS
                    this.cboEncoding.SelectedIndex = 1;
                    break;
                case "BINARY":  //
                    this.cboEncoding.SelectedIndex = 2;
                    break;
                default:
                    this.cboEncoding.SelectedIndex = 0;
                    break;
            }

            this.numReadTimeout.Value = (decimal)this.readtimeout;
            this.numWriteTimeout.Value = (decimal)this.writetimeout;

            //シリアルポートの取得
            GetDeviceNames();   //全てのデバイスを取得するため時間が掛かる。
                                //フォーム読み込み時に一度読み込んでおく
            this.cboPortname.Text = this.portname;
        }

        private void FormComm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void FormComm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Disconnect();   //通信切断
        }

        /// <summary>
        /// シリアルポート初期設定
        /// </summary>
        /// <returns>
        /// True:成功 / False:失敗
        /// </returns>
        public bool Portset()
        {
            try
            {
                if (!myPort.IsOpen)
                {
                    if (portname != "") myPort.PortName = portname;
                }

                switch (encode)
                {
                    case "ASCII": //ASCII
                        myPort.Encoding = Encoding.ASCII;
                        break;
                    case "JIS":
                        myPort.Encoding = Encoding.GetEncoding(932);
                        break;
                    //case "BINARY":
                    //    break;
                    default:
                        myPort.Encoding = Encoding.ASCII;
                        break;
                }
                myPort.ReadTimeout = readtimeout;       //リードタイムアウト
                myPort.WriteTimeout = writetimeout;     //ライトタイムアウト
                myPort.BaudRate = baudrate;             //ボーレート
                myPort.DataBits = databits;             //データビット
                myPort.Parity = parity;                 //パリティ
                myPort.StopBits = stopbits;             //ストップビット     
                myPort.Handshake = handshake;           //ハンドシェイク
                return true;
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("接続先のシリアルポート(" + portname + ")が無効です", "RS-232C接続"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("\t\t" + "Portset:Port = {0} / " + ex.Message, portname);
                chkConnect.Checked = false;
                return false;
            }
            catch (System.Exception ex)
            {
                //すべての例外をキャッチする
                //例外の説明を表示する
                MessageBox.Show("(" + portname + ")" + ex.Message, "RS-232C接続"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("\t\t" + "Portset:Port = {0} / " + ex.Message, portname);
                chkConnect.Checked = false;
                return false;
            }
        }

        /// <summary>
        /// シリアルポート接続
        /// 実行後にIsConnected()で状態確認を推奨
        /// </summary>
        /// <param name="portName">ポート番号</param>
        public void Connect(string portName)
        {
            try
            {
                //myPort.PortName = portName;
                //データ受信のイベントハンドラを追加
                myPort.DataReceived += new SerialDataReceivedEventHandler(myPort_ReceivedHandler);
                //シリアルポート接続
                myPort.Open();
                this.flagConnected = true;

                //STX,ETX文字の定義を行う
                byte[] bytesData = new byte[1];
                switch (encode)
                {
                    case "ASCII":
                        bytesData[0] = 0x02;
                        //ASCIIとして文字列に変換
                        str_s = Encoding.ASCII.GetString(bytesData);
                        bytesData[0] = 0x03;
                        //ASCIIとして文字列に変換
                        str_e = Encoding.ASCII.GetString(bytesData);
                        break;
                    case "JIS":
                        bytesData[0] = 0x02;
                        //Shift JISとして文字列に変換
                        str_s = Encoding.GetEncoding(932).GetString(bytesData);
                        bytesData[0] = 0x03;
                        //Shift JISとして文字列に変換
                        str_e = Encoding.GetEncoding(932).GetString(bytesData);
                        break;
                    default:
                        bytesData[0] = 0x02;
                        //ASCIIとして文字列に変換
                        str_s = Encoding.ASCII.GetString(bytesData);
                        bytesData[0] = 0x03;
                        //ASCIIとして文字列に変換
                        str_e = Encoding.ASCII.GetString(bytesData);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                //データ受信のイベントハンドラを削除
                myPort.DataReceived -= new SerialDataReceivedEventHandler(myPort_ReceivedHandler);
                //シリアルポート切断
                myPort.Close();
                Console.WriteLine("\t\t" + "Connect:Port = {0} / " + ex.Message, portname);
                this.flagConnected = false;
                chkConnect.Checked = false;
            }
        }

        /// <summary>
        /// シリアルポート切断
        /// </summary>
        public void Disconnect()
        {
            try
            {
                //データ受信のイベントハンドラを削除
                myPort.DataReceived -= new SerialDataReceivedEventHandler(myPort_ReceivedHandler);
                //シリアルポート切断
                myPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Disconnect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.flagConnected = false;
            }
        }

        /// <summary>
        /// 電源状態の確認
        /// 実行後にIsConnected()で状態確認を推奨
        /// </summary>
        /// <remarks>シリアルポートがあるならTrueを返す</remarks>
        public bool IsConnected()
        {
            Console.WriteLine("\t\t" + "IsConnected:" + flagConnected);
            return this.flagConnected;
        }

        private void chkConnect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            switch (chk.Checked)
            {
                case true:
                    chk.Text = "切 断";
                    //switch (cboEncoding.SelectedIndex)
                    //{
                    //    case 0: //ASCII
                    //        myPort.Encoding = Encoding.ASCII;
                    //        break;
                    //    case 1: //Shift-JIS
                    //        myPort.Encoding = Encoding.GetEncoding(932);
                    //        break;
                    //    default:
                    //        myPort.Encoding = Encoding.ASCII;
                    //        break;
                    //}
                    this.writetimeout = (int)this.numWriteTimeout.Value;
                    this.readtimeout = (int)this.numReadTimeout.Value;
                    if (Portset())
                    {
                        Connect(portname);
                        if (IsConnected())
                        {
                            MessageBox.Show("通信接続に成功しました。", portname);
                        }
                        else
                        {
                            MessageBox.Show("通信接続に失敗しました！", portname
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Disconnect();
                            chk.Checked = false;
                        }
                    }
                    break;
                case false:
                    chk.Text = "接 続";
                    this.writetimeout = (int)this.numWriteTimeout.Value;
                    this.readtimeout = (int)this.numReadTimeout.Value;
                    Disconnect();
                    break;
                default:
                    chk.Text = "";
                    break;
            }
        }

        private void cboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            switch (cbo.SelectedIndex)
            {
                case 0:
                    this.baudrate = 2400;
                    break;
                case 1:
                    this.baudrate = 4800;
                    break;
                case 2:
                    this.baudrate = 9600;
                    break;
                case 3:
                    this.baudrate = 19200;
                    break;
                case 4:
                    this.baudrate = 38400;
                    break;
                case 5:
                    this.baudrate = 57600;
                    break;
                case 6:
                    this.baudrate = 115200;
                    break;
                default:
                    this.baudrate = 9600;
                    break;
            }
            chkConnect.Checked = false;
        }

        private void cboDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            this.databits = int.Parse(cbo.Text);
            chkConnect.Checked = false;
        }

        private void cboParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            switch (cbo.SelectedIndex)
            {
                case 0:
                    this.parity = Parity.None;
                    break;
                case 1:
                    this.parity = Parity.Odd;
                    break;
                case 2:
                    this.parity = Parity.Even;
                    break;
                case 3:
                    this.parity = Parity.Mark;
                    break;
                case 4:
                    this.parity = Parity.Space;
                    break;
                default:
                    this.parity = Parity.None;
                    break;
            }
            chkConnect.Checked = false;
        }

        private void cboStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            switch (cbo.SelectedIndex)
            {
                case 0:
                    this.stopbits = StopBits.One;
                    break;
                case 1:
                    this.stopbits = StopBits.Two;
                    break;
                case 2:
                    this.stopbits = StopBits.OnePointFive;
                    break;
                default:
                    this.stopbits = StopBits.One;
                    break;
            }
            chkConnect.Checked = false;
        }

        private void cboHandshake_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            switch (cbo.SelectedIndex)
            {
                case 0:
                    this.handshake = Handshake.None;
                    break;
                case 1:
                    this.handshake = Handshake.XOnXOff;
                    break;
                case 2:
                    this.handshake = Handshake.RequestToSend;
                    break;
                case 3:
                    this.handshake = Handshake.RequestToSendXOnXOff;
                    break;
                default:
                    this.handshake = Handshake.None;
                    break;
            }
            chkConnect.Checked = false;
        }

        private void cboPortname_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.Items.Clear();
            string[] ports = new string[] { };
            int i = 0;
            foreach (string port in GetDeviceNames())
            {
                Array.Resize(ref ports, i + 1);
                if (port == "")
                {
                    cbo.Items.Add("No Port");
                    break;
                }
                ports[i] = port;
                i++;
            }
            //要素を昇順で並び替える[LINQ]
            var query = ports.OrderBy(s => s);
            cbo.Items.AddRange(query.ToArray());
        }

        /// <summary>
        /// ポート番号の選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPortname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //デバイス名からポート番号を抜き出す
            ComboBox cbo = (ComboBox)sender;
            int searchIndex = cbo.Text.IndexOf("(COM");                 //文字列の検索
            int searchIndexE = cbo.Text.IndexOf(")", searchIndex);      //文字列の検索
            //COM**の文字列を取得
            this.portname = cbo.Text.Substring(searchIndex + 1, searchIndexE - searchIndex - 1);
            chkConnect.Checked = false;
        }

        public static string[] GetDeviceNames()
        {
            var deviceNameList = new System.Collections.ArrayList();
            var check = new System.Text.RegularExpressions.Regex("(COM[1-9][0-9]?[0-9]?)");

            ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

            //全てのPnPデバイスを探索しシリアル通信が行われるデバイスを随時追加する
            foreach (ManagementObject manageObj in manageObjCol)
            {
                //Nameプロパティを取得
                var namePropertyValue = manageObj.GetPropertyValue("Name");
                if (namePropertyValue == null)
                {
                    continue;
                }

                //Nameプロパティ文字列の一部が"(COM1)～(COM999)"と一致するときリストに追加"
                string name = namePropertyValue.ToString();
                if (check.IsMatch(name))
                {
                    deviceNameList.Add(name);
                }
            }

            //戻り値作成
            string[] deviceNames = new string[deviceNameList.Count];
            if (deviceNameList.Count > 0)
            {
                int index = 0;
                foreach (var name in deviceNameList)
                {
                    deviceNames[index++] = name.ToString();
                }
            }
            else
            {
                deviceNames = new string[1];
                deviceNames[0] = "";
            }
            return deviceNames;
        }

        private void myPort_ReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receiveStr = myPort.ReadExisting();
                if (receiveStr == "")
                {
                    throw new Exception("Not Data!!");
                }
                else if (str_s != receiveStr.Substring(0, 1))
                {
                    throw new Exception("Not STX!");
                }
                else if (str_e != receiveStr.Substring(receiveStr.Length - 1, 1))
                {
                    throw new Exception("Not ETX!");
                }

                int commandIndex = receiveStr.IndexOf(",");
                string commandStr = receiveStr.Substring(1, commandIndex - 1);
                int CamNo = 0;
                switch (commandStr.ToUpper())
                {
                    case "RUN":
                        CamNo = int.Parse(receiveStr.Substring(5, 1));
                        if (CamNo > 0 && CamNo < 4)
                        {
                            //カメラ開始
                            SetCheckBox(CamNo, true);   //スレッド内でコントロールの呼び出し
                            myPort_Send("RUN," + CamNo.ToString());
                            //myPort_Send("OK");
                        }
                        else { myPort_Send("NG"); }
                        break;

                    case "STOP":
                        CamNo = int.Parse(receiveStr.Substring(6, 1));
                        if (CamNo > 0 && CamNo < 4)
                        {
                            //カメラ停止
                            SetCheckBox(CamNo, false);   //スレッド内でコントロールの呼び出し
                            myPort_Send("STOP," + CamNo.ToString());
                            //myPort_Send("OK");
                        }
                        else { myPort_Send("NG"); }
                        break;

                    case "ALIG":
                        CamNo = int.Parse(receiveStr.Substring(6, 1));
                        if (CamNo > 0 && CamNo < 4)
                        {
                            //アライメントデータ検出
                            myPort_Send("ALIG," + CamNo.ToString());
                            //myPort_Send("OK");
                        }
                        else { myPort_Send("NG"); }
                        break;

                    default:
                        myPort_Send("NG");
                        //myPort_Send("NotData:" + commandStr.ToUpper());
                        break;
                }
            }
            catch (Exception ex)
            {   //予期せぬエラー
                myPort_Send("NG");
                //MessageBox.Show(ex.Message, myPort.PortName.ToString(),
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("\t\t" + "myPort_ReceivedHandler: " + ex.Message);
            }
        }

        public void myPort_Send(string SendStr)
        {
            if (this.flagConnected)
            {   //コマンド送受信
                myPort.Write(str_s + SendStr + str_e);
            }
        }

        delegate void SetCheckBoxCallBack(int number, bool enable);

        /// <summary>
        /// スレッド内でカメラのON/OFFを制御
        /// </summary>
        /// <param name="number"></param>
        /// <param name="enable"></param>
        private void SetCheckBox(int number, bool enable)
        {
            CheckBox cb;
            switch (number)
            {
                case 1:
                    cb = FormMain.Instance.chkCAM1;
                    break;
                case 2:
                    cb = FormMain.Instance.chkCAM2;
                    break;
                case 3:
                    cb = FormMain.Instance.chkCAM3;
                    break;
                default:
                    cb = null;
                    return;
                    //break;
            }
            if (cb.InvokeRequired)
            {
                SetCheckBoxCallBack d = new SetCheckBoxCallBack(SetCheckBox);
                FormMain.Instance.Invoke(d, new object[] { number, enable });
            }
            else
            {
                cb.Checked = enable;
            }
        }

        private void cboEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboEncoding.SelectedIndex)
            {
                case 0: //ASCII
                    encode = "ASCII";
                    break;
                case 1: //Shift-JIS
                    encode = "JIS";
                    break;
                case 2: //Shift-JIS
                    encode = "BINARY";
                    break;
                default:
                    encode = "ASCII";
                    break;
            }

        }


        //public struct AppConfClass
        //{
        //    public string portname;             //ポート名 
        //    public int baudrate;                //ボーレート 
        //    public int databits;                //データビット "8"
        //    public Parity parity;               //パリティ  "無し"
        //    public StopBits stopbits;           //ストップビット "1"
        //    public Handshake handshake;         //フロー制御 "None"
        //    public int readtimeout;             //リードタイムアウト
        //    public int writetimeout;            //ライトタイムアウト
        //    public string encode;               //文字コード
        //}


    }
}
