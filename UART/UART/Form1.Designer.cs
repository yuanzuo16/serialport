namespace UART
{
    partial class SerialPortTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.PortName = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.BaudRate = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.PortStatus = new System.Windows.Forms.Label();
            this.Rx = new System.Windows.Forms.Label();
            this.RxCount = new System.Windows.Forms.Label();
            this.Parity = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.DataBits = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.StopBits = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.btcClearRec = new System.Windows.Forms.Button();
            this.gbrectype = new System.Windows.Forms.GroupBox();
            this.rbtnStrRec = new System.Windows.Forms.RadioButton();
            this.rbtnHexRec = new System.Windows.Forms.RadioButton();
            this.gbsendtype = new System.Windows.Forms.GroupBox();
            this.rbntStrSend = new System.Windows.Forms.RadioButton();
            this.rbtnHexSend = new System.Windows.Forms.RadioButton();
            this.gbrectype.SuspendLayout();
            this.gbsendtype.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(159, 349);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(297, 77);
            this.txtSend.TabIndex = 0;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            // 
            // txtReceive
            // 
            this.txtReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceive.Location = new System.Drawing.Point(11, 3);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(536, 267);
            this.txtReceive.TabIndex = 2;
            this.txtReceive.TextChanged += new System.EventHandler(this.txtReceive_TextChanged);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(159, 288);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(67, 23);
            this.btnOpenPort.TabIndex = 5;
            this.btnOpenPort.Text = "OpenPort";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(474, 349);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btcSend_Click);
            // 
            // PortName
            // 
            this.PortName.AutoSize = true;
            this.PortName.Location = new System.Drawing.Point(11, 291);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(53, 12);
            this.PortName.TabIndex = 7;
            this.PortName.Text = "PortName";
            this.PortName.Click += new System.EventHandler(this.PortName_Click);
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(70, 288);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(70, 20);
            this.cbPortName.TabIndex = 8;
            this.cbPortName.SelectedIndexChanged += new System.EventHandler(this.cboPortName_SelectedIndexChanged);
            // 
            // BaudRate
            // 
            this.BaudRate.AutoSize = true;
            this.BaudRate.Location = new System.Drawing.Point(11, 317);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(53, 12);
            this.BaudRate.TabIndex = 10;
            this.BaudRate.Text = "BaudRate";
            this.BaudRate.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "9600",
            "115200",
            "460800"});
            this.cbBaudRate.Location = new System.Drawing.Point(70, 314);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(70, 20);
            this.cbBaudRate.TabIndex = 15;
            this.cbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // PortStatus
            // 
            this.PortStatus.AutoSize = true;
            this.PortStatus.Location = new System.Drawing.Point(11, 424);
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(89, 12);
            this.PortStatus.TabIndex = 16;
            this.PortStatus.Text = "PortStatus: ON";
            this.PortStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // Rx
            // 
            this.Rx.AutoSize = true;
            this.Rx.Location = new System.Drawing.Point(107, 424);
            this.Rx.Name = "Rx";
            this.Rx.Size = new System.Drawing.Size(29, 12);
            this.Rx.TabIndex = 17;
            this.Rx.Text = "Rx: ";
            this.Rx.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // RxCount
            // 
            this.RxCount.AutoSize = true;
            this.RxCount.Location = new System.Drawing.Point(129, 424);
            this.RxCount.Name = "RxCount";
            this.RxCount.Size = new System.Drawing.Size(11, 12);
            this.RxCount.TabIndex = 18;
            this.RxCount.Text = "0";
            // 
            // Parity
            // 
            this.Parity.AutoSize = true;
            this.Parity.Location = new System.Drawing.Point(11, 343);
            this.Parity.Name = "Parity";
            this.Parity.Size = new System.Drawing.Size(41, 12);
            this.Parity.TabIndex = 10;
            this.Parity.Text = "Parity";
            this.Parity.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cbParity.Location = new System.Drawing.Point(70, 340);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(70, 20);
            this.cbParity.TabIndex = 15;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // DataBits
            // 
            this.DataBits.AutoSize = true;
            this.DataBits.Location = new System.Drawing.Point(11, 369);
            this.DataBits.Name = "DataBits";
            this.DataBits.Size = new System.Drawing.Size(53, 12);
            this.DataBits.TabIndex = 10;
            this.DataBits.Text = "DataBits";
            this.DataBits.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(70, 366);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(70, 20);
            this.cbDataBits.TabIndex = 15;
            this.cbDataBits.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // StopBits
            // 
            this.StopBits.AutoSize = true;
            this.StopBits.Location = new System.Drawing.Point(11, 395);
            this.StopBits.Name = "StopBits";
            this.StopBits.Size = new System.Drawing.Size(53, 12);
            this.StopBits.TabIndex = 10;
            this.StopBits.Text = "StopBits";
            this.StopBits.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(70, 392);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(70, 20);
            this.cbStopBits.TabIndex = 15;
            this.cbStopBits.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // btcClearRec
            // 
            this.btcClearRec.Location = new System.Drawing.Point(232, 288);
            this.btcClearRec.Name = "btcClearRec";
            this.btcClearRec.Size = new System.Drawing.Size(75, 23);
            this.btcClearRec.TabIndex = 23;
            this.btcClearRec.Text = "ClearRec";
            this.btcClearRec.UseVisualStyleBackColor = true;
            this.btcClearRec.Click += new System.EventHandler(this.btcClearRec_Click);
            // 
            // gbrectype
            // 
            this.gbrectype.Controls.Add(this.rbtnStrRec);
            this.gbrectype.Controls.Add(this.rbtnHexRec);
            this.gbrectype.Location = new System.Drawing.Point(313, 275);
            this.gbrectype.Name = "gbrectype";
            this.gbrectype.Size = new System.Drawing.Size(128, 45);
            this.gbrectype.TabIndex = 24;
            this.gbrectype.TabStop = false;
            this.gbrectype.Enter += new System.EventHandler(this.gbrectype_Enter);
            // 
            // rbtnStrRec
            // 
            this.rbtnStrRec.AutoSize = true;
            this.rbtnStrRec.Location = new System.Drawing.Point(68, 17);
            this.rbtnStrRec.Name = "rbtnStrRec";
            this.rbtnStrRec.Size = new System.Drawing.Size(59, 16);
            this.rbtnStrRec.TabIndex = 1;
            this.rbtnStrRec.Text = "StrRec";
            this.rbtnStrRec.UseVisualStyleBackColor = true;
            // 
            // rbtnHexRec
            // 
            this.rbtnHexRec.AutoSize = true;
            this.rbtnHexRec.Checked = true;
            this.rbtnHexRec.Location = new System.Drawing.Point(3, 17);
            this.rbtnHexRec.Name = "rbtnHexRec";
            this.rbtnHexRec.Size = new System.Drawing.Size(59, 16);
            this.rbtnHexRec.TabIndex = 0;
            this.rbtnHexRec.TabStop = true;
            this.rbtnHexRec.Text = "HexRec";
            this.rbtnHexRec.UseVisualStyleBackColor = true;
            this.rbtnHexRec.CheckedChanged += new System.EventHandler(this.rbtnHexRec_CheckedChanged);
            // 
            // gbsendtype
            // 
            this.gbsendtype.Controls.Add(this.rbntStrSend);
            this.gbsendtype.Controls.Add(this.rbtnHexSend);
            this.gbsendtype.Location = new System.Drawing.Point(474, 373);
            this.gbsendtype.Name = "gbsendtype";
            this.gbsendtype.Size = new System.Drawing.Size(75, 53);
            this.gbsendtype.TabIndex = 25;
            this.gbsendtype.TabStop = false;
            this.gbsendtype.Enter += new System.EventHandler(this.gbsendtype_Enter);
            // 
            // rbntStrSend
            // 
            this.rbntStrSend.AutoSize = true;
            this.rbntStrSend.Location = new System.Drawing.Point(7, 31);
            this.rbntStrSend.Name = "rbntStrSend";
            this.rbntStrSend.Size = new System.Drawing.Size(65, 16);
            this.rbntStrSend.TabIndex = 1;
            this.rbntStrSend.TabStop = true;
            this.rbntStrSend.Text = "StrSend";
            this.rbntStrSend.UseVisualStyleBackColor = true;
            this.rbntStrSend.CheckedChanged += new System.EventHandler(this.rbntStrSend_CheckedChanged);
            // 
            // rbtnHexSend
            // 
            this.rbtnHexSend.AutoSize = true;
            this.rbtnHexSend.Checked = true;
            this.rbtnHexSend.Location = new System.Drawing.Point(7, 12);
            this.rbtnHexSend.Name = "rbtnHexSend";
            this.rbtnHexSend.Size = new System.Drawing.Size(65, 16);
            this.rbtnHexSend.TabIndex = 0;
            this.rbtnHexSend.TabStop = true;
            this.rbtnHexSend.Text = "HexSend";
            this.rbtnHexSend.UseVisualStyleBackColor = true;
            this.rbtnHexSend.CheckedChanged += new System.EventHandler(this.rbtnHexSend_CheckedChanged);
            // 
            // SerialPortTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 438);
            this.Controls.Add(this.gbsendtype);
            this.Controls.Add(this.gbrectype);
            this.Controls.Add(this.btcClearRec);
            this.Controls.Add(this.RxCount);
            this.Controls.Add(this.Rx);
            this.Controls.Add(this.PortStatus);
            this.Controls.Add(this.cbStopBits);
            this.Controls.Add(this.StopBits);
            this.Controls.Add(this.cbDataBits);
            this.Controls.Add(this.DataBits);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.Parity);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.cbPortName);
            this.Controls.Add(this.PortName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtSend);
            this.Name = "SerialPortTool";
            this.Text = "SerialPortTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbrectype.ResumeLayout(false);
            this.gbrectype.PerformLayout();
            this.gbsendtype.ResumeLayout(false);
            this.gbsendtype.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label PortName;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label BaudRate;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label PortStatus;
        private System.Windows.Forms.Label Rx;
        private System.Windows.Forms.Label RxCount;
        private System.Windows.Forms.Label Parity;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label DataBits;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label StopBits;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Button btcClearRec;
        private System.Windows.Forms.GroupBox gbrectype;
        private System.Windows.Forms.RadioButton rbtnHexRec;
        private System.Windows.Forms.RadioButton rbtnStrRec;
        private System.Windows.Forms.GroupBox gbsendtype;
        private System.Windows.Forms.RadioButton rbntStrSend;
        private System.Windows.Forms.RadioButton rbtnHexSend;
    }
}

