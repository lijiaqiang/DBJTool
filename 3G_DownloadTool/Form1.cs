using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _3G_DownloadTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            displayLog("APP Start...");
        }
        public string configDataString;
        public byte[] scriptDataByte;
        public byte[] configDataByte;
        public int configFileSize;
        public int scriptFileSize;
        private string rightUsbCom = string.Empty;
        private string rightDataCom = string.Empty;
        private bool justTestTerminal = false;
        const string rightPortResp = "OK";
        const string isRunning = "M2M:0";
        const string checkTerminalCmd = "AT+M2M?\r";
        const string enterMODFile = "AT#M2MCHDIR=\"MOD\"\r";
        const string resetTerminal = "AT+M2M=0\r";
        const string writeScriptToTerminal = "AT#M2MWRITE=";
        const string setScriptMode = "AT#M2MRUN=2,";
        const string runTerminal = "AT+M2M=4,10\r";
        const string delTestFile = "AT#M2MDEL=\"mat_data\"\r";
        const string enterBaseFileCmd = "AT#M2MCHDIR=\"\\\"\r";
        const string CH3G_MATFILE = "CH3G_MAT.bin";
        const string CONFIG_FIEL = "mat_config";
        protected int tickCount = 0;


        CallBackMsgHandler callHandler;
        public delegate bool StartConnectPort();
        protected Thread m_connectThread;

        public object Enumerable { get; private set; }

        private delegate void FlushClient();//代理刷新端口
        //打印log
        public void displayLog(string log)
        {
            logTb.AppendText(DateTime.Now.ToString("HH:mm:ss  ") + log + "\r\n");
        }
        //获取时间戳
        public static int getTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
        //获取COM端口
        public string[] getComPort()
        {
            string comPorts = string.Empty;
            string[] coms;
            try
            {
                string comfilepath = getPathLocation() + @"\" + "comdata.txt";
                comPorts = System.IO.File.ReadAllText(comfilepath);
                coms = comPorts.Split(',');
                return coms;
            }
            catch(System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return null;
        }
        //获取当前文件目录路径
        private string getPathLocation()
        {
            string stmp = Assembly.GetExecutingAssembly().Location;
            stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));
            return stmp;
        }
        /****************************************************************************************
        函数接口：发送AT指令
        参数：1、指令（字符串）2、期待正确回复（默认是OK字符串）3、错误回复（默认是ERROR）
        返回值：收到正确回复放回true,超时或者收到错误回复放回false
        ****************************************************************************************/
        private bool sendCMD(string cmd, string rightResp = rightPortResp, string errorResp = "ERROR")
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
                serialPort1.Write(cmd);
                displayLog(string.Format("write {0} to Terminal", cmd));   
            }
            catch
            {
                displayLog(string.Format("Open serialPort error when write {0} to Terminal", cmd));
                return false;
            }
            return readSerialData(rightResp, errorResp);
        }
        /****************************************************************************************
        函数接口：主动读取串口信息
        参数：1、期待正确回复（默认是OK字符串）2、错误回复（默认是ERROR）
        返回值：收到正确回复放回true,超时或者收到错误回复放回false
        ****************************************************************************************/
        public bool readSerialData(string rightResp = rightPortResp, string errorResp = "ERROR")
        {
            string respdata = string.Empty;
            int timeout = getTimestamp() + 3;
            while (timeout > getTimestamp())
            {
                Thread.Sleep(50);
                respdata = serialPort1.ReadExisting().Replace("\r", "").Replace("\0", "").Replace("\n", ",").Replace(",", "").Replace(" ", "");
                displayLog(string.Format("read {0} to Terminal", respdata));
                if (-1 != respdata.IndexOf(rightResp))
                {
                    return true;
                }
                else if (-1 != respdata.IndexOf(errorResp))
                {
                    return false;
                }
                else { }
            }
            return false;
        }
        public void StartDownload()
        {
            StartConnectPort connectPort_delegate = new StartConnectPort(StartDownloadAndTest);
            this.Invoke(connectPort_delegate);
        }
        public bool StartDownloadAndTest()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            m_connectThread = new Thread(downloadFileAndTest);
            m_connectThread.Start();

            return true;
        }
        //读取文件
        public void readFile(string filePath, byte[] dataByte, int fileSize)
        {
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                fileSize = Convert.ToInt32(file.Length);
                displayLog(string.Format("read fileSize {0}", fileSize));
                BinaryReader readFile = new BinaryReader(file);
                dataByte = new byte[fileSize];
                dataByte = readFile.ReadBytes(fileSize);
                file.Close();
            }
            catch
            {
                Console.WriteLine("open file error");
            }
        }
        public void ReadConfigFile()
        {
            string configFilePath = getPathLocation() + @"\" + "mat_config";
            displayLog(configFilePath);
            try
            {
                FileStream fileLog = new FileStream(configFilePath, FileMode.Open);
                fileLog.Seek(0, SeekOrigin.Begin);
                configFileSize = Convert.ToInt32(fileLog.Length);
                System.IO.BinaryReader read = new System.IO.BinaryReader(fileLog);
                configDataByte = new byte[configFileSize];
                configDataByte = read.ReadBytes(configFileSize);
                configDataString = System.Text.Encoding.Default.GetString(configDataByte);
                fileLog.Close();
            }
            catch
            {
                Console.WriteLine("open file error");
            }
            displayLog(string.Format("read ReadConfigFile fileSize {0}", configFileSize));
        }
        public void ReadScriptFile()
        {
            string scriptFilepath = getPathLocation() + @"\" + "CH3G_MAT.bin";
            try
            {
                FileStream file = new FileStream(scriptFilepath, FileMode.Open, FileAccess.Read);
                scriptFileSize = Convert.ToInt32(file.Length);
                BinaryReader readFile = new BinaryReader(file);
                scriptDataByte = new byte[scriptFileSize];
                scriptDataByte = readFile.ReadBytes(scriptFileSize);
                file.Close();
            }
            catch
            {
                Console.WriteLine("open file error");
            }
            displayLog(string.Format("read ReadScriptFile fileSize {0}", scriptFileSize));
        }
        /****************************************************************************************
        函数接口：写入文件数据
        参数：1、一次写入字节大小（KB）2、文件总大小 3、文件数据
        返回值：无
        ****************************************************************************************/
        public void writeData(int m_TranSize, int m_filesize, byte[] m_downloadData)
        {
            downloadPBar.Value = 0;
            downloadPBar.Minimum = 0;
            int max = Convert.ToInt32(Math.Ceiling((Double)m_filesize / (double)m_TranSize));
            downloadPBar.Maximum = max - 1;
            int offset = 0;
            if (m_TranSize < m_filesize)
            {
                byte[] buf = new byte[m_filesize];
                Buffer.BlockCopy(m_downloadData, 0, buf, 0, m_filesize);
                while (((int)m_filesize - offset) >= m_TranSize)
                {
                    try
                    {
                        serialPort1.Write(buf, offset, m_TranSize);
                    }
                    catch
                    {
                        displayLog("writeData error return");
                        return;
                    }
                    offset += m_TranSize;
                    downloadPBar.Value += 1;
                    Thread.Sleep(50);
                }
                serialPort1.Write(buf, offset, (m_filesize - offset));
            }
            else
            {
                byte[] buf = new byte[m_filesize];
                Buffer.BlockCopy(m_downloadData, offset, buf, 0, m_filesize);
                try
                {
                    serialPort1.Write(buf, 0, m_filesize);
                }
                catch
                {
                    displayLog("writeData error return");
                    return;
                }
            }
        }
        /****************************************************************************************
        函数接口：下载文件
        参数：1、下载文件名 2、文件总大小 3、下载指令 4、文件数据 5、设置文件模式（0：不需要设置，1：按照指令设置）
        返回值：下载成功放回true,否则返回false
        ****************************************************************************************/
        public bool WriteFileData(string Tofilename, int size, string cmd, byte[] downloadData, int mode)
        {
            if (sendCMD(cmd, rightPortResp))
            {
                string downloadCmd = writeScriptToTerminal + "\"" + Tofilename + "\"" + "," + size + "," + mode + "\r";
                if (sendCMD(downloadCmd, ">>>"))
                {
                    displayLog("write script to terminal...");
                    writeData(8196, size, downloadData);
                    if (readSerialData(rightPortResp))
                    {
                        if (mode == 1)
                        {
                            string setModeCmd = setScriptMode + "\"" + Tofilename + "\"" + "\r";
                            if (sendCMD(setModeCmd, rightPortResp))
                            {
                                return true;
                            }
                            else
                            {
                                displayLog("can not enter set mode");
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        displayLog("download data failed...");
                        return false;
                    }
                }
            }
            return false;
        }
        private void setPassLabelColor()
        {
            Lab1.BackColor = Color.Green;
            Lab2.BackColor = Color.Green;
            Lab3.BackColor = Color.Green;
            Lab4.BackColor = Color.Green;
            Lab5.BackColor = Color.Green;
            Lab6.BackColor = Color.Green;
            Lab7.BackColor = Color.Green;
            Lab8.BackColor = Color.Green;
            Lab9.BackColor = Color.Green;
            Lab10.BackColor = Color.Green;
            Lab11.BackColor = Color.Green;
            Lab12.BackColor = Color.Green;
            Lab13.BackColor = Color.Green;
            Lab14.BackColor = Color.Green;
            lab15.BackColor = Color.Green;
        }
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string portRecv = string.Empty;
            portRecv = serialPort1.ReadExisting().Replace("\r", "").Replace("\0", "").Replace("\n", ",");
            if (portRecv.Length > 0)
            {
                displayLog(string.Format("SerialDataReceivedEventArgs >>>{0}", portRecv));
                callHandler.MsgParseAndSetPass(portRecv);
                if (-1 != portRecv.IndexOf("12V"))
                {
                    bool ret = callHandler.checkAllTest();
                    if (-1 != portRecv.IndexOf("BMAT#1") || ret)
                    {
                        setPassLabelColor();
                        lab15.Text = "PASS!!!";
                    }
                    else
                    {
                        lab15.BackColor = Color.Red;
                        lab15.Text = "NO PASS!";
                    }
                    //serialPort1.DataReceived -= SerialPort1_DataReceived;
                }
            }
        }
        public bool openSerialPort(string com)
        {
            if (com == string.Empty) return false;
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    displayLog(string.Format("close the {0}", serialPort1.PortName));
                    serialPort1.Close();
                    displayLog(string.Format("will connecting the {0}", com));
                }
                serialPort1.PortName = com;
                serialPort1.Open();
                displayLog(string.Format("Connected the {0}, successful", serialPort1.PortName));
                return true;
            }
            catch (System.Exception error)
            {
                displayLog(string.Format("OpenComAgine({0}) error:{1}", serialPort1.PortName, error.Message));
            }
            return false;
        }
        public void DataReceived()
        {
            string portRecv = string.Empty;
            lab15.Text = "正在测试";
            lab15.BackColor = Color.Red;
            int timeout = getTimestamp() + 3*60;
            try
            {
                while (timeout > getTimestamp())
                {
                    portRecv = serialPort1.ReadExisting().Replace("\r", "").Replace("\0", "").Replace("\n", ",").Replace(",", "").Replace(" ", "");
                    if (portRecv.Length > 0)
                    {
                        displayLog(string.Format("DataReceived >>>{0}", portRecv));
                        callHandler.MsgParseAndSetPass(portRecv);
                        if (-1 != portRecv.IndexOf("12V"))
                        {
                            bool ret = callHandler.checkAllTest();
                            if (-1 != portRecv.IndexOf("BMAT#1") || ret)
                            {
                                setPassLabelColor();
                                lab15.Text = "PASS!!!";
                                return;
                            }
                            else if (-1 != portRecv.IndexOf("BMAT#2"))
                            {
                                lab15.BackColor = Color.Red;
                                lab15.Text = "NO PASS!";
                                return;
                            }
                            else { }
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch(Exception err)
            {
                displayLog(string.Format("read data({0}) error:{1}", serialPort1.PortName, err.Message));
            }
           
            lab15.BackColor = Color.Red;
            lab15.Text = "NO PASS!";
            displayLog("DataReceived 3mins timeout");
            stopTimer();
        }
        public void testDataReceived()
        {
            //string data = "{BMAT#0}StartingCloudHawkMATProcedure...ConfiguredMODULE_FW=12.00.318ConfiguredBLE_FW=0105ConfiguredTEMP=0:60ConfiguredADC=1400:1700ConfiguredCELLULAR=15ConfiguredGPS=120:30:32ConfiguredDOOR=1ConfiguredIGN=1ConfiguredKEY=30ConfiguredDELAY=0{MODULE_FW#0}Checkingfirmwareversion...{MODULE_FW#1#12.00.318}Firmwareversioncheckpassed!{SERIAL#0}Obtainingserialnumber...{SERIAL#4#0000031117}Serialnumberis0000031117{TEMP#0}{TEMP#2#27.000000}Temperaturesensortestpassed!{ACCEL#0}Testingaccelerometer...{ACCEL#1#-2:1:-4}Accelerometertestpassed.{ADC#0}TestingexternalADCs...{ADC#1#1559:1560:1559:1413}ADCtestpassed.{DOOR#0}{IGN#0}TestingexternalGPIOs...{DOOR#1#1}{IGN#1#1}{KEY#0}Testingkeybutton.Pleasepressthekeybuttonnow.{KEY#3}Keybuttontestpassed.{GPS#0}TestingGPSreceiver...GPScoldstartsuccessful.C/N=41TTFF=13991RestartingGPSreceiverGPShotstartsuccessful.C/N=40TTFF=2526{GPS#1#40}GPStestpassed.{CHG#0}TestingpowermanagementIC...{CHG#1#3:8:4075}PowermanagementICtestpassed.Chargerstatus:nobattery{SIM#0}TestingSIMCard...{SIM#1#302720393018876}SIMcardtestpassed.{CELLULAR#0}Testingcellularradio...{CELLULAR#1#37}Cellularradiotestpassed.Currentnetwork:ROGERS3G{BLE_FW#0}ReadingBLEfirmwareversion...{BLE_FW#1#0105}BLEversioncheckpassed.{BMAT#1}MATTestpassed.Devicewillshutoffnow.PleaseremoveUSBand12Vpower.";
            //string errorDdata = "{BMAT#0}StartingCloudHawkMATProcedure...ConfiguredMODULE_FW=12.00.318ConfiguredBLE_FW=0105ConfiguredTEMP=0:60ConfiguredADC=1400:1700ConfiguredCELLULAR=15ConfiguredGPS=120:30:32ConfiguredDOOR=1ConfiguredIGN=1ConfiguredKEY=30ConfiguredDELAY=0{MODULE_FW#0}Checkingfirmwareversion...{MODULE_FW#1#12.00.318}Firmwareversioncheckpassed!{SERIAL#0}Obtainingserialnumber...{SERIAL#1#0000031117}Serialnumberis0000031117{TEMP#0}0000031117{TEMP#1#27.000000}Temperaturesensortestpassed!{ACCEL#0}Testingaccelerometer...{ACCEL#1#-1:3:-3}Accelerometertestpassed.{ADC#0}TestingexternalADCs...{ADC#2#1559:1560:1559:1249}ADCtestfailed.{DOOR#0}{IGN#0}TestingexternalGPIOs...{DOOR#1#1}{IGN#1#1}{KEY#0}Testingkeybutton.Pleasepressthekeybuttonnow.{KEY#1}Keybuttontestpassed.{GPS#0}TestingGPSreceiver...GPScoldstartsuccessful.C/N=41TTFF=20971RestartingGPSreceiverGPShotstartsuccessful.C/N=40TTFF=2791{GPS#1#40}GPStestpassed.{CHG#0}TestingpowermanagementIC...{CHG#1#3:8:3980}PowermanagementICtestpassed.Chargerstatus:nobattery{SIM#0}TestingSIMCard...{SIM#2}SIMcarddoesnotexist.Skippingcellularradiotest...{BMAT#2}MATTestfailed.Devicewillshutoffnow.PleaseremoveUSBand12Vpower.";
            //callHandler.MsgParseAndSetPass(errorDdata);
            while (true)
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = "COM11";
                    serialPort1.Open();
                }
                serialPort1.WriteLine("DBJ_Detect_COM");
                displayLog(string.Format("DBJ_Detect_COM"));
                Thread.Sleep(1000);
                string recv = serialPort1.ReadExisting();
                displayLog(string.Format("read:{0}", recv));

            }
        }
        public void StartTest()
        {
            while (true)
            {
                try
                {
                    if (openSerialPort(rightDataCom))
                    {
                        break;
                    }  
                }
                catch(System.Exception error)
                {
                    displayLog(string.Format("connecting com failed ({0}) error:{1}", serialPort1.PortName, error.Message));
                }
                Thread.Sleep(1000);
            }
            DataReceived();
            try
            {
                if (serialPort1!=null && serialPort1.IsOpen) serialPort1.Close();
            }
            catch
            {
                displayLog("close serialPort1 error");
            }
            
        }
        public void downloadFileAndTest()
        {
#if true
            testDataReceived();
#else
            while (true)
            {
                if (openSerialPort(rightUsbCom))
                {
                    if (justTestTerminal)
                    {
                        if (sendCMD(delTestFile, rightPortResp))
                        {
                            sendCMD(runTerminal, rightPortResp);
                        }
                        break;
                    }
                    else
                    {
                        if (sendCMD(checkTerminalCmd, isRunning))
                        {

                            if (WriteFileData(CONFIG_FIEL, configFileSize, enterBaseFileCmd, configDataByte, 0))
                            {
                                if (WriteFileData(CH3G_MATFILE, scriptFileSize, enterMODFile, scriptDataByte, 1))
                                {
                                    sendCMD(runTerminal, rightPortResp);
                                    break;
                                }
                                else
                                {
                                    displayLog("WriteFileData CH3G_MATFILE Failed try again");
                                    continue;
                                }
                            }
                            else
                            {
                                displayLog("WriteFileData CONFIG_FIEL Failed try again");
                                continue;
                            }
                        }
                        else
                        {
                            sendCMD(resetTerminal, rightPortResp);
                            displayLog("checkTerminalCmd Failed try again");
                            Thread.Sleep(5000);
                            continue;
                        }
                    }
                }
                Thread.Sleep(1000);
            }
            StartTest();
#endif
        }
        public void BtnEvent()
        {
            string[] comports = getComPort();
            setButtonEnableColor(false, Color.Gray);
            if (comports.Length == 2)
            {
                rightUsbCom = comports[0];
                rightDataCom = comports[1];
                displayLog(string.Format("COM1 = {0}, COM2 = {1}", rightUsbCom, rightDataCom));
            }
            else
            {
                MessageBox.Show("请在配置文件comdata 中填写正确的com端口，com1是AT COM，com2是data COM");
                return;
            }
            callHandler = new CallBackMsgHandler(this);
            ReadConfigFile();
            ReadScriptFile();
            callHandler.ParseConfigFile(configDataString);
            callHandler.ResetAllData();
        }
        public void setButtonEnableColor(bool enable, System.Drawing.Color color)
        {
            StartBtn.Enabled = enable;
            TestBtn.Enabled = enable;
            StartBtn.BackColor = color;
            TestBtn.BackColor = color;
        }
        private void StartBtn_Click_1(object sender, EventArgs e)
        {
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            startTimer();
            BtnEvent();
            StartDownload();
        }
        private void TestBtn_Click(object sender, EventArgs e)
        {
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            startTimer();
            justTestTerminal = true;
            BtnEvent();
            StartDownload();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            downloadPBar.Value = 0;
            justTestTerminal = false;
            stopTimer();
            setButtonEnableColor(true, Color.Green);
            try
            {
                if (serialPort1!=null && serialPort1.IsOpen)
                    serialPort1.Close();
                m_connectThread.Abort();
                callHandler.ResetAllData();
            }
            catch (System.Exception error)
            {
                displayLog(string.Format("CloseComAgine error! {0}", error.Message));
            }
        }
        public void startTimer()
        {
            timer1.Start();
            timer1.Interval = 1000;
        }
        protected void stopTimer()
        {
            timer1.Stop();
            tickCount = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            tickCount++;
            int minuteNumber = tickCount / 60;
            int secondNumber = tickCount % 60;
            if (minuteNumber / 60 > 0)
            {
                tickCount = 0;
            }
            timerLab.Text = String.Format("{0,2:D}:{1,2:D}", minuteNumber, secondNumber);
        }
    }
}
