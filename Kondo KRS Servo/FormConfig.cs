﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EZ_B;
using EZ_Builder;
using EZ_Builder.Config.Sub;

namespace LewanSoul_Servos {

  public partial class FormConfig : Form {

    PluginV1 _cf = new PluginV1();

    public FormConfig() {

      InitializeComponent();

      cbNewId.Items.Clear();
      cbOrginalId.Items.Clear();

      for (int p = (int)Servo.ServoPortEnum.V1; p < Enum.GetValues(typeof(Servo.ServoPortEnum)).Length; p++) {

        cbNewId.Items.Add((Servo.ServoPortEnum)p);
        cbOrginalId.Items.Add((Servo.ServoPortEnum)p);
      }
    }

    private void Form_FormClosing(object sender, FormClosingEventArgs e) {

    }

    public void SetConfiguration(PluginV1 cf) {

      _cf = cf;

      CustomConfig customConfig = (CustomConfig)cf.GetCustomObjectV2(typeof(CustomConfig));

      foreach (Servo.ServoPortEnum port in Enum.GetValues(typeof(Servo.ServoPortEnum)))
        if (port >= Servo.ServoPortEnum.V1 && port <= Servo.ServoPortEnum.V99)
          clbPorts.Items.Add(port, customConfig.VirtualPorts.Contains(port));

      ucUseHardwareUART.Checked = Convert.ToBoolean(cf.STORAGE[ConfigTitles.USE_HARDWARE_UART]);
      cbHardwareUArt.Items.Add(0);
      cbHardwareUArt.Items.Add(1);
      cbHardwareUArt.Items.Add(2);

      cbHardwareUArt.SelectedItem = cf.STORAGE[ConfigTitles.HARDWARE_PORT];

      ucUseSoftwareUart.Checked = Convert.ToBoolean(cf.STORAGE[ConfigTitles.USE_SOFTWARE_UART]);
      foreach (Digital.DigitalPortEnum port in Enum.GetValues(typeof(Digital.DigitalPortEnum)))
        cbSoftwareUart.Items.Add(port);

      cbSoftwareUart.SelectedItem = (Digital.DigitalPortEnum)cf.STORAGE[ConfigTitles.SOFTWARE_PORT];

      ucUseComPort.Checked = Convert.ToBoolean(cf.STORAGE[ConfigTitles.USE_COM_PORT]);
      foreach (var port in System.IO.Ports.SerialPort.GetPortNames())
        cbComPort.Items.Add(port);

      cbComPort.SelectedItem = cf.STORAGE[ConfigTitles.COM_PORT].ToString();

      if (cbComPort.Items.Count == 0)
        ucUseComPort.Enabled = false;
    }

    public PluginV1 GetConfiguration() {

      return _cf;
    }

    void setConfigurationValuesFromUser() {

      List<Servo.ServoPortEnum> virtualPorts = new List<Servo.ServoPortEnum>();

      foreach (var selected in clbPorts.CheckedItems)
        virtualPorts.Add((Servo.ServoPortEnum)selected);

      _cf.SetCustomObjectV2(
        new CustomConfig() {
          VirtualPorts = virtualPorts.ToArray()
        });

      _cf.STORAGE[ConfigTitles.USE_HARDWARE_UART] = ucUseHardwareUART.Checked;
      _cf.STORAGE[ConfigTitles.HARDWARE_PORT] = (int)cbHardwareUArt.SelectedItem;

      _cf.STORAGE[ConfigTitles.USE_SOFTWARE_UART] = ucUseSoftwareUart.Checked;
      _cf.STORAGE[ConfigTitles.SOFTWARE_PORT] = (Digital.DigitalPortEnum)cbSoftwareUart.SelectedItem;

      _cf.STORAGE[ConfigTitles.USE_COM_PORT] = ucUseComPort.Checked;
      _cf.STORAGE[ConfigTitles.COM_PORT] = cbComPort.SelectedItem.ToString();
    }

    private void btnSave_Click(object sender, EventArgs e) {

      setConfigurationValuesFromUser();

      DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e) {

      DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    private void initUART() {

      if (!Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_HARDWARE_UART]))
        return;

      if (EZBManager.EZBs[0].IsConnected) {

        UInt32 baud = 115200;
        int uartPort = Convert.ToInt16(_cf.STORAGE[ConfigTitles.HARDWARE_PORT]);

        EZBManager.EZBs[0].Uart.UARTExpansionInit(uartPort, baud);
      }
    }

    private void sendServoCommand(byte[] cmdData) {

      if (cmdData.Length == 0)
        return;

      if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_HARDWARE_UART]))
        EZBManager.EZBs[0].Uart.UARTExpansionWrite(
          Convert.ToInt16(_cf.STORAGE[ConfigTitles.HARDWARE_PORT]),
          cmdData);

      if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_SOFTWARE_UART]))
        EZBManager.EZBs[0].Uart.SendSerial(
          (Digital.DigitalPortEnum)_cf.STORAGE[ConfigTitles.SOFTWARE_PORT],
           Uart.BAUD_RATE_ENUM.Baud_115200,
           cmdData);

      if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_COM_PORT]))
        using (System.IO.Ports.SerialPort sb = new System.IO.Ports.SerialPort(_cf.STORAGE[ConfigTitles.COM_PORT].ToString(), 115200))
          sb.Write(cmdData, 0, cmdData.Length);
    }

    private void btnChangeId_Click(object sender, EventArgs e) {

      try {

        var origId = (Servo.ServoPortEnum)cbOrginalId.SelectedItem;
        var newId = (Servo.ServoPortEnum)cbNewId.SelectedItem;

        if (origId == newId)
          throw new Exception("The new and original ID cannot be the same");

        setConfigurationValuesFromUser();

        sendServoCommand(new LewanSoulController().SetServoId(origId, newId));

        MessageBox.Show(string.Format("The servo {0} ID has been changed to {1}", origId, newId));
      } catch (Exception ex) {

        MessageBox.Show(ex.Message);
      }
    }
  }
}
