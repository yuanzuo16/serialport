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
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {       
        
        //*******************定义变量*******************
        string[] str = SerialPort.GetPortNames();//get an array of the serial port names for the current computer
        private bool spflag = false;  
        SerialPort sp1 = new SerialPort(); 
        FolderBrowserDialog openpath = new FolderBrowserDialog();//保存文件路径
        string[] path = new string[1]; //路径字符串
        string[] filename  = new string[1]; //文件名字符串
        string[] bfile = new string[1];  //波形保存文件名
        string[] pfile = new string[1];  //测试保存文件名
        string[] sfile = new string[1];  //数据保存文件名

        private long received_count = 0;//接收计数     
        private StringBuilder builder = new StringBuilder();
        int saveflag = 0; 
        //*******************定义变量*******************

        public Form1()
        {
            InitializeComponent();

            if (str.Length == 0)
            {
                MessageBox.Show("未检测到串口！", "Error");
                comboBox2.Enabled = false;
                return;
            }
            else
            {
                foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                { 
                    comboBox2.Items.Add(s);
                }

                comboBox2.SelectedIndex = 0;
            }
            comboBox5.SelectedIndex = 0;
            textBox2.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            sp1.DataReceived += sp1_DataReceived;
            //Control.CheckForIllegalCrossThreadCalls = false;   
            //sp1.DataReceived += new SerialDataReceivedEventHandler(button3_Click); 
        }  //初始化窗口 

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = sp1.BytesToRead;   
            byte[] buf = new byte[n];  
            received_count += n;  
            sp1.Read(buf, 0, n);   
            builder.Clear(); 

            this.Invoke((EventHandler)(delegate
            {
                if(saveflag == 1)  //读取保存固件1
                {
                    filename[0] = textBox2.Text;
                    bfile[0] = path[0] + "\\" + filename[0] + "_FW01.bin";
                  
                    foreach (byte b in buf)              
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }
                    
                    this.textBox5.AppendText(builder.ToString());             
                    label10.Text = received_count.ToString();                
                    
                    try
                    {
                        Stream bstr = new FileStream(bfile[0], FileMode.Append, FileAccess.Write);
                        BinaryWriter sw = new BinaryWriter(bstr, Encoding.Unicode);
                        sw.Write(buf);
                        sw.Close();
                        bstr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (saveflag == 2)   //保存固件3
                {
                    filename[0] = textBox2.Text;
                    pfile[0] = path[0] + "\\" + filename[0] + "_FW03.bin";

                    foreach (byte b in buf)                 
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }

                    this.textBox5.AppendText(builder.ToString());                  
                    label10.Text = received_count.ToString();              

                    try
                    {
                        Stream pstr = new FileStream(pfile[0], FileMode.Append, FileAccess.Write);
                        BinaryWriter sw = new BinaryWriter(pstr, Encoding.Unicode);
                        sw.Write(buf);
                        sw.Close();
                        pstr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (saveflag == 3)   //保存固件2
                {
                    filename[0] = textBox2.Text;
                    sfile[0] = path[0] + "\\" + filename[0] + "_FW02.bin";

                    foreach (byte b in buf)                 
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }

                    this.textBox5.AppendText(builder.ToString());                 
                    label10.Text = received_count.ToString();               
 
                    try
                    {
                        Stream sstr = new FileStream(sfile[0], FileMode.Append, FileAccess.Write);
                        BinaryWriter sw = new BinaryWriter(sstr, Encoding.Unicode);
                        sw.Write(buf);
                        sw.Close();
                        sstr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (saveflag == 4)   //保存表头    sh
                {
                    filename[0] = textBox2.Text;
                    sfile[0] = path[0] + "\\" + filename[0] + "_sh.bin";

                    foreach (byte b in buf)                 
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }

                    this.textBox5.AppendText(builder.ToString());              
                    label10.Text = received_count.ToString();             

                    try
                    {
                        Stream sstr = new FileStream(sfile[0], FileMode.Append, FileAccess.Write);
                        BinaryWriter sw = new BinaryWriter(sstr, Encoding.Unicode);
                        sw.Write(buf);
                        sw.Close();
                        sstr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    foreach (byte b in buf)
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }
                    this.textBox5.AppendText(builder.ToString());                  
                    label10.Text = received_count.ToString();      
                }
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (spflag == false)   //如果串口处于关闭状态
            {
                button1.Text = "关闭串口";
                label4.Text = "状态：开";
                label4.ForeColor = System.Drawing.Color.Red;

                if (sp1.IsOpen == true)
                {
                    sp1.Close();
                }
                if (!sp1.IsOpen)
                {
                    try
                    {
                        string serialName = comboBox2.SelectedItem.ToString();
                        sp1.PortName = serialName;

                        string BRtmp = comboBox5.SelectedItem.ToString();
                        int BR = Convert.ToInt32(BRtmp);

                        sp1.BaudRate = BR;       //波特率
                        sp1.DataBits = 8;       //数据位   8
                        sp1.StopBits = StopBits.One;  //停止位   1
                        sp1.Parity = Parity.None;   //校验位  无
                      //  sp1.ReadBufferSize = ; //设置串口缓存区大小

                        comboBox2.Enabled = false;
                        comboBox5.Enabled = false;

                        sp1.Open(); //打开串口
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message, "Error");
                        return;
                    }
                }
            }
            else   //如果串口处于打开状态
            {
                button1.Text = "打开串口";
                label4.Text = "状态：关";
                label4.ForeColor = System.Drawing.Color.Black;

                comboBox2.Enabled = Enabled;
                comboBox5.Enabled = Enabled;
                sp1.Close(); 
            };

            spflag = !spflag;  
            saveflag = 0;
        }// 串口打开/关闭

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //保存固件2
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("请打开串口！", "Error");
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("请选择路径！", "Error");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入文件名！", "Error");
                return;
            }
            else
            {
                textBox5.Text = "";
                received_count = 0;
                label10.Text = "0";
                saveflag = 3;
                Byte[] BSendTemp = new Byte[1];
                BSendTemp[0] = 0x2B;
                sp1.Write(BSendTemp, 0, 1);  
            }
        } //保存数据



        private void button3_Click(object sender, EventArgs e)  //保存固件1
        {               
            if (!sp1.IsOpen) 
            {
                MessageBox.Show("请打开串口！", "Error");
                return;
            }
            else if(textBox1.Text == "")
            {
                MessageBox.Show("请选择路径！", "Error");
                return;
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("请输入文件名！", "Error");
                return;
            }
            else
            {
                textBox5.Text = "";
                received_count = 0;
                label10.Text = "0";
                saveflag = 1;
                Byte[] BSendTemp = new Byte[1];
                BSendTemp[0] = 0x1B;
                sp1.Write(BSendTemp, 0, 1);  
            }
        }

        private void button1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            comboBox2.SelectedIndex = -1;

            str = SerialPort.GetPortNames();
             if (str.Length == 0)
             {
                 comboBox2.Enabled = false;
                 MessageBox.Show("未检测到串口！", "Error");
                 return;
             }
             else
             {
                 comboBox2.Enabled = Enabled;
                 foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                 {
                     comboBox2.Items.Add(s); 
                 }
             }
        }//刷新

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveflag = 0;
            if (!sp1.IsOpen) 
            {
                MessageBox.Show("请打开串口！", "Error");
                return;
            }
            else
            {
                Byte[] BSendTemp = new Byte[1];
                BSendTemp[0] = 0x0C;
                sp1.Write(BSendTemp, 0, 1); 
            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //textBox5.SelectionStart = textBox5.Text.Length; //Set the current caret position at the end
           // textBox5.ScrollToCaret();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            received_count = 0;
            label10.Text = "0";
        } //清空窗口

        private void button2_Click(object sender, EventArgs e)
        {
            openpath.ShowDialog();
            openpath.Description = "请选择文件夹";
            path[0] = openpath.SelectedPath.ToString();
            textBox1.Text = path[0];
        } //选择文件夹

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveflag = 0;
        }

        private void button4_Click(object sender, EventArgs e) //固件3
        {
            if (!sp1.IsOpen) 
            {
                MessageBox.Show("请打开串口！", "Error");
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("请选择路径！", "Error");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入文件名！", "Error");
                return;
            }
            else
            {
                textBox5.Text = "";
                received_count = 0;
                label10.Text = "0";
                saveflag = 2;
                Byte[] BSendTemp = new Byte[1];
                BSendTemp[0] = 0x3B;
                sp1.Write(BSendTemp, 0, 1);  

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            saveflag = 0;
            if (!sp1.IsOpen) 
            {
                MessageBox.Show("请打开串口！", "Error");
                return;
            }
            else
            {
                String sendstr = textBox6.Text;
                sp1.Write(sendstr);  
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen) 
            {
                MessageBox.Show("请打开串口！", "Error");
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("请选择路径！", "Error");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入文件名！", "Error");
                return;
            }
            else
            {
                textBox5.Text = "";
                received_count = 0;
                label10.Text = "0";
                saveflag = 4;
                Byte[] BSendTemp = new Byte[1];
                BSendTemp[0] = 0x0A;
                sp1.Write(BSendTemp, 0, 1);  
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

//try
//{

//filename[0] = textBox2.Text;
// bfile[0] = path[0] + "\\" +filename[0] + "_b.bin";
// bfile_w = new BinaryWriter(new FileStream(bfile[0], FileMode.Create));

// String sendbx = "sendbx";
// sp1.Write(sendbx);  //向手表发送请求

//byte[] receivedData = new Byte[sp1.BytesToRead];
//sp1.Read(receivedData, 0, receivedData.Length);

//sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer  
//string strRcv = null;

//for (int i = 0; i < receivedData.Length; i++) //窗体显示  
//{
//    strRcv += receivedData[i].ToString();  //16进制显示  
//}

//  }
//   catch (IOException ex)
//  {
//      MessageBox.Show("Error:" + ex.Message, "Error");
//     return;
// }

//byte[] byteRead = new byte[sp1.BytesToRead];
//try
//{
//    Byte[] receivedData = new Byte[sp1.BytesToRead];        //创建接收字节数组  
//    sp1.Read(receivedData, 0, receivedData.Length);         //读取数据                         
//    sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer  
//    string strRcv = null;

//    for (int i = 0; i < receivedData.Length; i++) //窗体显示  
//    {

//        strRcv += receivedData[i].ToString("X2");  //16进制显示  
//    }
//    textBox5.Text += strRcv + "\r\n";
//}
//catch (System.Exception ex)
//{
//    MessageBox.Show(ex.Message, "出错提示");
//}