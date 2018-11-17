using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _3G_DownloadTool
{
    class CallBackMsgHandler : Form1
    {
        static bool MODULE_FW_test = false;
        static bool SERIAL_test = false;
        static bool TEMP_test = false;
        static bool ACCEL_test = false;
        static bool ADC_test = false;
        static bool DOOR_test = false;
        static bool IGN_test = false;
        static bool KEY_test = false;
        static bool GPS_test = false;
        static bool CHG_test = false;
        static bool SIM_test = false;
        static bool CELLULAR_test = false;
        static bool BLE_FW_test = false;
        //用一个数组来标记每一项测试
        int[] flagArray = new int[13];
        //用一个字典来保存每一项数据
        private static Dictionary<string, string> configdataDict = new Dictionary<string, string>();
        public static string m_serial = string.Empty;
        private System.ComponentModel.IContainer components;
        Form1 callBackForm;
        public CallBackMsgHandler(Form1 form)
        {
            callBackForm = form;
        }
        public string getSerial()
        {
            return m_serial;
        }
        public void ResetAllData()
        {
            displayLog("reset AllData");
            MODULE_FW_test = false;
            SERIAL_test = false;
            TEMP_test = false;
            ACCEL_test = false;
            ADC_test = false;
            DOOR_test = false;
            IGN_test = false;
            KEY_test = false;
            GPS_test = false;
            CHG_test = false;
            SIM_test = false;
            CELLULAR_test = false;
            BLE_FW_test = false;

            callBackForm.Lab1.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab2.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab3.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab4.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab5.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab6.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab7.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab8.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab9.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab10.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab11.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab12.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab13.BackColor = System.Drawing.Color.Gray;
            callBackForm.Lab14.BackColor = System.Drawing.Color.Gray;
            callBackForm.lab15.BackColor = System.Drawing.Color.Gray;
            callBackForm.lab15.Text = "开始测试";

            foreach (int i in flagArray)
            {
                flagArray[i] = 0;
            }
        }

        public bool checkAllTest()
        {
            foreach (int i in flagArray)
            {
                callBackForm.displayLog(i.ToString());
                if (i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void ParseConfigFile(string configdata)
        {
            if (configdata == string.Empty) return;
            List<string> logList = new List<string>();
            string pattern = @"{([^}]*)}";
            string Msg = configdata.Replace("\r\n", "").Replace(" ", "");
            MatchCollection results = Regex.Matches(Msg, pattern);
            foreach (Match m in results)
            {
                logList.Add(m.Value);
            }
            Match result;
            string pattern1 = @"[^{}]+";
            foreach (string data in logList)
            {
                result = Regex.Match(data, pattern1);
                string[] str = result.ToString().Split('#');
                string key = str[0];
                configdataDict[key] = str[1];
            }
        }
        public void MsgParseAndSetPass(string logInfo)
        {
            List<string> logList = new List<string>();
            Dictionary<string, string[]> dataDict = new Dictionary<string, string[]>();
            string pattern = @"{([^}]*)}";
            string Msg = logInfo.Replace("\r\n", "").Replace(" ", "").Replace(",", "");
            MatchCollection results = Regex.Matches(Msg, pattern);
            foreach (Match m in results)
            {
                logList.Add(m.Value);
            }
            Match result;
            string pattern1 = @"[^{}]+";
            foreach (string data in logList)
            {
                result = Regex.Match(data, pattern1);
                string[] str = result.ToString().Split('#');
                string key = str[0];
                int len = str.Length-1;
                string[] values = new string[len];
                for (int i = 0; i < len; i++)
                {
                    values[i] = str[i+1];
                }
                dataDict[str[0]] = values;
            }
            setFlagIfTestPass(dataDict);
        }
        public string[] getGPS()
        {
            string[] str = { };
            if (configdataDict["GPS"] != string.Empty)
            {
                str = configdataDict["GPS"].Split(':');
            }
            return str;
        }
        public string[] getADC()
        {
            string[] str = { };
            if (configdataDict["ADC"] != string.Empty)
            {
                str = configdataDict["ADC"].Split(':');
            }
            return str;
        }
        public string getBLE_FW()
        {
            string str = string.Empty;
            if (configdataDict["BLE_FW"] != string.Empty)
            {
                str = configdataDict["BLE_FW"];
            }
            return str;
        }
        public int getDOOR()
        {
            int m_int = 0;
            if (configdataDict["BLE_FW"] != string.Empty)
            {
                m_int = Int32.Parse(configdataDict["BLE_FW"]);
            }
            return m_int;
        }
        public static int getDELAY()
        {
            int m_int = 0;
            if (configdataDict["DELAY"] != string.Empty)
            {
                m_int = Int32.Parse(configdataDict["DELAY"]);
            }
            return m_int;
        }
        public int getIGN()
        {
            int m_int = 0;
            if (configdataDict["IGN"] != string.Empty)
            {
                m_int = Int32.Parse(configdataDict["IGN"]);
            }
            return m_int;
        }
        public int getKEY()
        {
            int m_int = 0;
            if (configdataDict["KEY"] != string.Empty)
            {
                m_int = Int32.Parse(configdataDict["KEY"]);
            }
            return m_int;
        }
        public int getCELLULAR()
        {
            int m_int = 0;
            if (configdataDict["CELLULAR"] != string.Empty)
            {
                m_int = Int32.Parse(configdataDict["CELLULAR"]);
            }
            return m_int;
        }
        public string[] getTemp()
        {
            string[] str = { };
            if (configdataDict["TEMP"] != string.Empty)
            {
                str = configdataDict["TEMP"].Split(':');
            }
            return str;
        }
        public void setFlagIfTestPass(Dictionary<string, string[]> dataDict)
        {
            try
            {
                foreach (KeyValuePair<string, string[]> kv in dataDict)
                {
                    string key = kv.Key;
                    //foreach (string K in kv.Value)
                    //{
                    //    callBackForm.displayLog(string.Format("setFlagIfTestPass>>> key={0}, value={1}", key, K));
                    //}
                    if (key == "MODULE_FW")
                        testModule_fw(kv.Value);
                    else if (key == "SERIAL")
                        testSerial(kv.Value);
                    else if (key == "TEMP")
                        testTemp(kv.Value);
                    else if (key == "CHG")
                        testCHG(kv.Value);
                    else if (key == "ACCEL")
                        testAccel(kv.Value);
                    else if (key == "KEY")
                        testKEY(kv.Value);
                    else if (key == "DOOR")
                        testDOOR(kv.Value);
                    else if (key == "ADC")
                        testADC(kv.Value);
                    else if (key == "GPS")
                        testGPS(kv.Value);
                    else if (key == "IGN")
                        testIGN(kv.Value);
                    else if (key == "SIM")
                        testSIM(kv.Value);
                    else if (key == "CELLULAR")
                        testCELLULAR(kv.Value);
                    else if (key == "BLE_FW")
                        testBLE_FW(kv.Value);
                    else { }
                }
            }
            catch (Exception err)
            {
                callBackForm.displayLog(string.Format("setFlagIfTestPass>>>{0}", err.Message));
            }
           
        }
        public bool testModule_fw(string[] data)
        {
            if (MODULE_FW_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab1);
            if (data.Length==1) return false;
            if (ret == 1)
            {
                string value = data[1];
                MODULE_FW_test = true;
                flagArray[0] = 1;
                return true;
            }
            flagArray[0] = 0;
            return false;
        }
        public bool testSerial(string[] data)
        {
            if (SERIAL_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab2);
            if (data.Length==1) return false;
            if (status == 1)
            {
                string value = data[1];
                m_serial = value;
                callBackForm.displayLog(m_serial);
                SERIAL_test = true;
                flagArray[1] = 1;
                return true;
            }
            flagArray[1] = 0;
            return false;
        }
        public bool testTemp(string[] data)
        {
            if (TEMP_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab3);
            if (data.Length==1) return false;
            if (ret == 1)
            {
                int temp = 0;
                try
                {
                    temp = Convert.ToInt32(float.Parse(data[1]));
                }
                catch (System.Exception err)
                {
                    callBackForm.displayLog(string.Format("error data, testTemp>>>{0}", err.Message));
                }
                string[] tmp = getTemp();
                if (temp >= Int32.Parse(tmp[0]) && temp <= Int32.Parse(tmp[1]))
                {
                    TEMP_test = true;
                    flagArray[2] = 1;
                    return true;
                }

            }
            flagArray[2] = 0;
            return false;
        }
        public bool testAccel(string[] data)
        {
            if (ACCEL_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab6);
            if (data.Length==1) return false;
            if (ret == 1)
            {
                string[] str = data[1].Split(':');
                int i = 0;
                foreach (string s in str)
                {
                    int tmp = stringToint32(s);
                    if (tmp == 0)
                    {
                        i++;
                    }
                }
                if (i != 3)
                {
                    ACCEL_test = true;
                    flagArray[3] = 1;
                    return true;
                }
            }
            flagArray[3] = 0;
            return false;
        }
        public bool testADC(string[] data)
        {
            if (ADC_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab9);
            if (data.Length==1) return false;
            int i = 0;
            if (ret == 1)
            {
                string[] str = data[1].ToString().Split(':');
                foreach (string s in str)
                {
                    int adc = stringToint32(s);
                    string[] cfgADC = getADC();
                    if (adc >= Int32.Parse(cfgADC[0]) && adc <= Int32.Parse(cfgADC[1]))
                    {
                        i = i + 1;
                    }
                }
                if (i == 3)
                {
                    ADC_test = true;
                    flagArray[4] = 1;
                    return true;
                }
            }
            flagArray[4] = 0;
            return false;
        }
        public bool testDOOR(string[] data)
        {
            if (DOOR_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab8);
            if (ret == 1)
            {
                //int value = stringToint32(data[1]);
                //if (value == 1)
                //{
                    DOOR_test = true;
                    flagArray[5] = 1;
                    return true;
                //}
            }
            flagArray[5] = 0;
            return false;
        }
        public bool testIGN(string[] data)
        {
            if (IGN_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab11);
            if (ret == 1)
            {
                //int value = stringToint32(data[1]);
                //if (value == 1)
                //{
                    IGN_test = true;
                    flagArray[6] = 1;
                    return true;
                //}
            }
            flagArray[6] = 0;
            return false;
        }
        public bool testKEY(string[] data)
        {
            if (KEY_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab5);
            callBackForm.Lab7.BackColor = System.Drawing.Color.Green;
            if (ret == 0)
            {
                callBackForm.Lab7.BackColor = System.Drawing.Color.Red;
            }
            else if (ret == 1)
            {
                KEY_test = true;
                callBackForm.Lab5.BackColor = System.Drawing.Color.Green;
                flagArray[7] = 1;
                return true;
            }
            flagArray[7] = 0;
            return false;
        }
        public bool testGPS(string[] data)
        {
            if (GPS_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab10);
            if (data.Length==1) return false;
            if (ret == 1)
            {

                int value = stringToint32(data[1]);
                string[] cfgGPS = getGPS();
                if (value >= Int32.Parse(cfgGPS[2]))
                {
                    GPS_test = true;
                    flagArray[8] = 1;
                    return true;
                }
            }
            flagArray[8] = 0;
            return false;
        }
        public bool testCHG(string[] data)
        {
            if (CHG_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab4);
            if (data.Length==1) return false;
            if (ret == 1)
            {
                string[] value = data[1].Split(':');
                //if (stringToint32(value[0]) == 3 && stringToint32(value[1]) == 8)
                //{
                    CHG_test = true;
                    flagArray[9] = 1;
                    return true;
                //}
            }
            flagArray[9] = 0;
            return false;
        }
        public bool testSIM(string[] data)
        {
            if (SIM_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab12);
            if (data.Length==1) return false;
            if (ret == 1)
            {
                string value = data[1];
                if (value.Length != 0)
                {
                    SIM_test = true;
                    flagArray[10] = 1;
                    return true;
                }

            }
            flagArray[10] = 0;
            return false;
        }
        public bool testCELLULAR(string[] data)
        {
            if (CELLULAR_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab13);
            if (data.Length==1) return false;
            if (ret == 1)
            {
                int value = stringToint32(data[1]);
                int CELLLUAR_value = getCELLULAR();
                if (value >= CELLLUAR_value)
                {
                    CELLULAR_test = true;
                    flagArray[11] = 1;
                    return true;
                }
            }
            flagArray[11] = 0;
            return false;
        }
        public bool testBLE_FW(string[] data)
        {
            if (BLE_FW_test) return true;
            int status = stringToint32(data[0]);
            int ret = setStatusColor(status, callBackForm.Lab14);
            if (ret == 1)
            {
                string value = data[1];
                string version = getBLE_FW();
                if (value.Equals(version))
                {
                    BLE_FW_test = true;
                    flagArray[12] = 1;
                    return true;
                }
            }
            flagArray[12] = 0;
            return false;
        }
        public int stringToint32(string str)
        {
            int m_int = 0;
            try
            {
                m_int = Int32.Parse(str);
            }
            catch (System.Exception err)
            {
                callBackForm.displayLog(string.Format("string turn to int, error>>> {0}", err.Message));
            }
            return m_int;
        }
        public int setStatusColor(int status, Label lab)
        {
            System.Drawing.Color color = System.Drawing.Color.White;
            if (status == 1)
            {
                color = System.Drawing.Color.Green;
                callBackForm.displayLog("Test  Pass!!!");
            }
            else if (status == 2)
            {
                color = System.Drawing.Color.Red;
                callBackForm.displayLog("Test Failed!!!");
            }
            else if (status == 3)
            {
                color = System.Drawing.Color.Yellow;
                callBackForm.displayLog("Test Timeout!!!");
            }
            else if (status == 4)
            {
                color = System.Drawing.Color.Blue;
                callBackForm.displayLog("Test Error!!!");
            }
            else
            {
                color = System.Drawing.Color.White;
            }
            lab.BackColor = color;
            return status;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CallBackMsgHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(859, 351);
            this.Name = "CallBackMsgHandler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
