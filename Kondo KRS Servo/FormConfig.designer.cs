using EZ_Builder.UCForms;
namespace LewanSoul_Servos {
  partial class FormConfig {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.ucUseSoftwareUart = new EZ_Builder.UCForms.UC.UCCheckGroupBox();
      this.cbSoftwareUart = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.ucUseHardwareUART = new EZ_Builder.UCForms.UC.UCCheckGroupBox();
      this.cbHardwareUArt = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.clbPorts = new System.Windows.Forms.CheckedListBox();
      this.ucTabControl1 = new EZ_Builder.UCForms.UCTabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnChangeId = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cbNewId = new System.Windows.Forms.ComboBox();
      this.cbOrginalId = new System.Windows.Forms.ComboBox();
      this.ucUseComPort = new EZ_Builder.UCForms.UC.UCCheckGroupBox();
      this.cbComPort = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.groupBox5.SuspendLayout();
      this.ucUseSoftwareUart.SuspendLayout();
      this.ucUseHardwareUART.SuspendLayout();
      this.panel1.SuspendLayout();
      this.ucTabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.ucUseComPort.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.ucUseComPort);
      this.groupBox5.Controls.Add(this.ucUseSoftwareUart);
      this.groupBox5.Controls.Add(this.ucUseHardwareUART);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox5.Location = new System.Drawing.Point(3, 3);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(987, 87);
      this.groupBox5.TabIndex = 7;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Settings";
      // 
      // ucUseSoftwareUart
      // 
      this.ucUseSoftwareUart.Controls.Add(this.cbSoftwareUart);
      this.ucUseSoftwareUart.Controls.Add(this.label2);
      this.ucUseSoftwareUart.Dock = System.Windows.Forms.DockStyle.Left;
      this.ucUseSoftwareUart.Location = new System.Drawing.Point(222, 16);
      this.ucUseSoftwareUart.Name = "ucUseSoftwareUart";
      this.ucUseSoftwareUart.Size = new System.Drawing.Size(244, 68);
      this.ucUseSoftwareUart.TabIndex = 2;
      this.ucUseSoftwareUart.TabStop = false;
      this.ucUseSoftwareUart.Text = "Use Software UART";
      // 
      // cbSoftwareUart
      // 
      this.cbSoftwareUart.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbSoftwareUart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSoftwareUart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbSoftwareUart.FormattingEnabled = true;
      this.cbSoftwareUart.Location = new System.Drawing.Point(92, 16);
      this.cbSoftwareUart.Name = "cbSoftwareUart";
      this.cbSoftwareUart.Size = new System.Drawing.Size(149, 21);
      this.cbSoftwareUart.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Left;
      this.label2.Location = new System.Drawing.Point(3, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "EZ-B UART Port:";
      // 
      // ucUseHardwareUART
      // 
      this.ucUseHardwareUART.Controls.Add(this.cbHardwareUArt);
      this.ucUseHardwareUART.Controls.Add(this.label1);
      this.ucUseHardwareUART.Dock = System.Windows.Forms.DockStyle.Left;
      this.ucUseHardwareUART.Location = new System.Drawing.Point(3, 16);
      this.ucUseHardwareUART.Name = "ucUseHardwareUART";
      this.ucUseHardwareUART.Size = new System.Drawing.Size(219, 68);
      this.ucUseHardwareUART.TabIndex = 1;
      this.ucUseHardwareUART.TabStop = false;
      this.ucUseHardwareUART.Text = "Use Hardware UART";
      // 
      // cbHardwareUArt
      // 
      this.cbHardwareUArt.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbHardwareUArt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbHardwareUArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbHardwareUArt.FormattingEnabled = true;
      this.cbHardwareUArt.Location = new System.Drawing.Point(92, 16);
      this.cbHardwareUArt.Name = "cbHardwareUArt";
      this.cbHardwareUArt.Size = new System.Drawing.Size(124, 21);
      this.cbHardwareUArt.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Left;
      this.label1.Location = new System.Drawing.Point(3, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "EZ-B UART Port:";
      // 
      // btnSave
      // 
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Location = new System.Drawing.Point(8, 3);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 41);
      this.btnSave.TabIndex = 8;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Location = new System.Drawing.Point(103, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 41);
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 598);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1001, 48);
      this.panel1.TabIndex = 10;
      // 
      // clbPorts
      // 
      this.clbPorts.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clbPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.clbPorts.FormattingEnabled = true;
      this.clbPorts.Location = new System.Drawing.Point(3, 90);
      this.clbPorts.MultiColumn = true;
      this.clbPorts.Name = "clbPorts";
      this.clbPorts.Size = new System.Drawing.Size(987, 447);
      this.clbPorts.TabIndex = 11;
      this.clbPorts.ThreeDCheckBoxes = true;
      // 
      // ucTabControl1
      // 
      this.ucTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.ucTabControl1.BackColor = System.Drawing.Color.White;
      this.ucTabControl1.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(170)))), ((int)(((byte)(234)))));
      this.ucTabControl1.ButtonSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(146)))), ((int)(((byte)(66)))));
      this.ucTabControl1.ButtonTextColor = System.Drawing.Color.White;
      this.ucTabControl1.Controls.Add(this.tabPage1);
      this.ucTabControl1.Controls.Add(this.tabPage2);
      this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTabControl1.ItemSize = new System.Drawing.Size(60, 50);
      this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
      this.ucTabControl1.Margin = new System.Windows.Forms.Padding(0);
      this.ucTabControl1.MarginLeft = 0;
      this.ucTabControl1.MarginTop = 0;
      this.ucTabControl1.Multiline = true;
      this.ucTabControl1.Name = "ucTabControl1";
      this.ucTabControl1.Padding = new System.Drawing.Point(0, 0);
      this.ucTabControl1.SelectedIndex = 0;
      this.ucTabControl1.Size = new System.Drawing.Size(1001, 598);
      this.ucTabControl1.TabIndex = 3;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.clbPorts);
      this.tabPage1.Controls.Add(this.groupBox5);
      this.tabPage1.Location = new System.Drawing.Point(4, 54);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(993, 540);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Settings";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.groupBox1);
      this.tabPage2.Location = new System.Drawing.Point(4, 54);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(993, 540);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Utlities";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnChangeId);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.cbNewId);
      this.groupBox1.Controls.Add(this.cbOrginalId);
      this.groupBox1.Location = new System.Drawing.Point(46, 66);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(265, 158);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Change Servo ID";
      // 
      // btnChangeId
      // 
      this.btnChangeId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnChangeId.Location = new System.Drawing.Point(74, 97);
      this.btnChangeId.Name = "btnChangeId";
      this.btnChangeId.Size = new System.Drawing.Size(140, 39);
      this.btnChangeId.TabIndex = 4;
      this.btnChangeId.Text = "Change ID";
      this.btnChangeId.UseVisualStyleBackColor = true;
      this.btnChangeId.Click += new System.EventHandler(this.btnChangeId_Click);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(12, 58);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(56, 23);
      this.label4.TabIndex = 3;
      this.label4.Text = "New ID:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(12, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 23);
      this.label3.TabIndex = 2;
      this.label3.Text = "Old ID;";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbNewId
      // 
      this.cbNewId.FormattingEnabled = true;
      this.cbNewId.Location = new System.Drawing.Point(74, 58);
      this.cbNewId.Name = "cbNewId";
      this.cbNewId.Size = new System.Drawing.Size(121, 21);
      this.cbNewId.TabIndex = 1;
      // 
      // cbOrginalId
      // 
      this.cbOrginalId.FormattingEnabled = true;
      this.cbOrginalId.Location = new System.Drawing.Point(74, 19);
      this.cbOrginalId.Name = "cbOrginalId";
      this.cbOrginalId.Size = new System.Drawing.Size(121, 21);
      this.cbOrginalId.TabIndex = 0;
      // 
      // ucUseComPort
      // 
      this.ucUseComPort.Controls.Add(this.cbComPort);
      this.ucUseComPort.Controls.Add(this.label5);
      this.ucUseComPort.Dock = System.Windows.Forms.DockStyle.Left;
      this.ucUseComPort.Location = new System.Drawing.Point(466, 16);
      this.ucUseComPort.Name = "ucUseComPort";
      this.ucUseComPort.Size = new System.Drawing.Size(244, 68);
      this.ucUseComPort.TabIndex = 3;
      this.ucUseComPort.TabStop = false;
      this.ucUseComPort.Text = "Use COM Port";
      // 
      // cbComPort
      // 
      this.cbComPort.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbComPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbComPort.FormattingEnabled = true;
      this.cbComPort.Location = new System.Drawing.Point(59, 16);
      this.cbComPort.Name = "cbComPort";
      this.cbComPort.Size = new System.Drawing.Size(182, 21);
      this.cbComPort.TabIndex = 1;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Dock = System.Windows.Forms.DockStyle.Left;
      this.label5.Location = new System.Drawing.Point(3, 16);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "COM Port:";
      // 
      // FormConfig
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSize = true;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(1001, 646);
      this.Controls.Add(this.ucTabControl1);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormConfig";
      this.Text = "Configuration";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
      this.groupBox5.ResumeLayout(false);
      this.ucUseSoftwareUart.ResumeLayout(false);
      this.ucUseSoftwareUart.PerformLayout();
      this.ucUseHardwareUART.ResumeLayout(false);
      this.ucUseHardwareUART.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ucTabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.ucUseComPort.ResumeLayout(false);
      this.ucUseComPort.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel panel1;
    private EZ_Builder.UCForms.UC.UCCheckGroupBox ucUseHardwareUART;
    private System.Windows.Forms.ComboBox cbHardwareUArt;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox clbPorts;
    private EZ_Builder.UCForms.UC.UCCheckGroupBox ucUseSoftwareUart;
    private System.Windows.Forms.ComboBox cbSoftwareUart;
    private System.Windows.Forms.Label label2;
    private UCTabControl ucTabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnChangeId;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbNewId;
    private System.Windows.Forms.ComboBox cbOrginalId;
    private EZ_Builder.UCForms.UC.UCCheckGroupBox ucUseComPort;
    private System.Windows.Forms.ComboBox cbComPort;
    private System.Windows.Forms.Label label5;
  }
}