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

namespace UART
{
    public partial class SerialPortTool : Form
    {
        private string[] portnamestr = SerialPort.GetPortNames();
        private SerialPort mysp1= new SerialPort();//定义串口1
        private long received_count = 0;//接收计数      
        private StringBuilder builder = new StringBuilder();  


        public SerialPortTool()
        {
            
            InitializeComponent();

            if (portnamestr == null)
            {
                MessageBox.Show("There is no port available!", "Error");
                cbPortName.Enabled = false;
                return;
            }
            else
            {
                foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                {
                    cbPortName.Items.Add(s);//add items to object
                }


                cbBaudRate.SelectedIndex = 1;
                cbParity.SelectedIndex = 0;
                cbDataBits.SelectedIndex = 3;
                cbStopBits.SelectedIndex = 0;
                mysp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);//绑定事件
            }
            
        }

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int n = mysp1.BytesToRead;
                byte[] buf = new byte[n];
                received_count += n;
                mysp1.Read(buf, 0, n);
                builder.Clear();

                this.Invoke((EventHandler)(delegate
                {

                    if (rbtnHexRec.Checked)
                    {
                        foreach (byte b in buf)
                        {
                            builder.Append(b.ToString("X2") + " ");
                        }
                    }
                    else if (rbtnStrRec.Checked)
                    {
                        //直接按ASCII规则转换成字符串
                        builder.Append(Encoding.ASCII.GetString(buf));

                    }


                    this.txtReceive.AppendText(builder.ToString());
                    RxCount.Text = received_count.ToString();

                }));
            }
            catch (Exception ex)
            {
                //捕获到异常信息，创建一个新的comn对象，之前的不能用了
                mysp1 = new SerialPort();
                //显示异常
                MessageBox.Show(ex.Message);

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
         
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTest_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PortName_Click(object sender, EventArgs e)
        {

        }

        private void cboPortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (portnamestr == null)
            {
                MessageBox.Show("There is no port available!", "Error");
                cbPortName.Enabled = false;
                return;
            }

            if (mysp1.IsOpen == false)//port is not open
            {
                mysp1.PortName = cbPortName.SelectedItem.ToString();
                mysp1.BaudRate = Convert.ToInt32(cbBaudRate.SelectedItem.ToString());
                mysp1.Parity = (Parity)Convert.ToInt32(cbParity.SelectedIndex.ToString());
                mysp1.DataBits = Convert.ToInt32(cbDataBits.SelectedItem.ToString());
                mysp1.StopBits = (StopBits)Convert.ToInt32(cbStopBits.SelectedItem.ToString());
                try
                {
                    mysp1.Open(); //Open Serial Port
                    btnSend.Enabled = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
                btnOpenPort.Text = "ClosePort";
                PortStatus.Text = "Status: ON";
                PortStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                try
                {
                    mysp1.Close(); //Close Serial Port
                    btnSend.Enabled = false;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
                btnOpenPort.Text = "OpenPort";
                PortStatus.Text = "Status: OFF";
                PortStatus.ForeColor = System.Drawing.Color.Black;
            }
           
        }

        private void cboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void btcSend_Click(object sender, EventArgs e)
        {
            if (!mysp1.IsOpen)
            {
                MessageBox.Show("Please Open Serial Port!", "Error");
                return;
            }
            else
            {
                try
                {
                    if (rbtnHexSend.Checked)
                    {
                        byte[] sendbuf = new byte[20];
                        sendbuf = HexStringToByteArray(txtSend.Text);
                        mysp1.Write(sendbuf,0, sendbuf.Length);//发送数据
                    }
                    else if (rbntStrSend.Checked)
                    {
                        mysp1.Write(txtSend.Text);
                    }
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误：" + ex.Message);
                }
            }
        }


        private void btcClearRec_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";
            received_count = 0;
            RxCount.Text = "0";
        }



        private void gbrectype_Enter(object sender, EventArgs e)
        {

        }

        private void rbtnHexRec_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gbsendtype_Enter(object sender, EventArgs e)
        {

        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }



        private byte[] HexStringToByteArray(string s)
        {//16进制字符串转化为字节数组

            s = s.Replace(" ", "");
            s = s.Replace("0x", "");
            s = s.Replace("0X", "");
            byte[] buffer = new byte[s.Length / 2];

            for (int i = 0; i < s.Length; i += 2)

                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);

            return buffer;

        }

        private void rbntStrSend_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnHexSend_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


