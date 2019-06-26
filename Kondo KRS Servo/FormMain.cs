using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EZ_B;
using EZ_Builder;
using System.Linq;
using System.IO.Ports;

namespace LewanSoul_Servos {

  public partial class FormMain : EZ_Builder.UCForms.FormPluginMaster {

    CustomConfig        _customConfig = new CustomConfig();
    LewanSoulController _controller   = new LewanSoulController();
    SerialPort          _serialPort   = new SerialPort();

    public FormMain() {

      InitializeComponent();

      // Bind to the events for moving a servo and changing connection state
      EZBManager.EZBs[0].OnConnectionChange += FormMain_OnConnectionChange;
      EZBManager.EZBs[0].Servo.OnServoMove += Servo_OnServoMove;
      EZBManager.EZBs[0].Servo.OnServoGetPosition += Servo_OnServoGetPosition;
      EZBManager.EZBs[0].Servo.OnServoRelease += Servo_OnServoRelease;

      Invokers.SetAppendText(tbLog, true, "Connected Events");
    }

    void FormMain_OnConnectionChange(bool isConnected) {

      // If the connection is established, send an initialization to the ez-b for the uart which we will be using
      if (isConnected)
        initUART();
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {

      EZBManager.EZBs[0].OnConnectionChange -= FormMain_OnConnectionChange;
      EZBManager.EZBs[0].Servo.OnServoMove -= Servo_OnServoMove;
      EZBManager.EZBs[0].Servo.OnServoGetPosition -= Servo_OnServoGetPosition;
      EZBManager.EZBs[0].Servo.OnServoRelease -= Servo_OnServoRelease;

      if (_serialPort.IsOpen)
        _serialPort.Close();

      _serialPort.Dispose();
    }

    public override void SetConfiguration(EZ_Builder.Config.Sub.PluginV1 cf) {

      cf.STORAGE.AddIfNotExist(ConfigTitles.HARDWARE_PORT, 0);
      cf.STORAGE.AddIfNotExist(ConfigTitles.SOFTWARE_PORT, Digital.DigitalPortEnum.D0);
      cf.STORAGE.AddIfNotExist(ConfigTitles.USE_HARDWARE_UART, true);
      cf.STORAGE.AddIfNotExist(ConfigTitles.USE_SOFTWARE_UART, false);
      cf.STORAGE.AddIfNotExist(ConfigTitles.USE_COM_PORT, false);
      cf.STORAGE.AddIfNotExist(ConfigTitles.COM_PORT, string.Empty);

      _customConfig = (CustomConfig)cf.GetCustomObjectV2(_customConfig.GetType());

      base.SetConfiguration(cf);

      initUART();
    }

    private void initUART() {

      if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_HARDWARE_UART])) {

        if (EZBManager.EZBs[0].IsConnected) {

          UInt32 baud = 115200;
          int uartPort = Convert.ToInt16(_cf.STORAGE[ConfigTitles.HARDWARE_PORT]);

          Invokers.SetAppendText(tbLog, true, "UART {0} @ {1}bps",
            uartPort,
            baud);

          EZBManager.EZBs[0].Uart.UARTExpansionInit(uartPort, baud);
        } else {

          Invokers.SetAppendText(tbLog, true, "Not connected to ez-b");
        }
      }

      if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_COM_PORT])) {

        if (_serialPort.IsOpen)
          _serialPort.Close();

        _serialPort.BaudRate = 115200;
        _serialPort.PortName = _cf.STORAGE[ConfigTitles.COM_PORT].ToString();

        _serialPort.Open();
      }
    }

    public override object[] GetSupportedControlCommands() {

      return new string[] {
        string.Format("{0}, [Servo Port], [0 to 1000]", ControlCommands.SET_POSITION_RAW),
        string.Format("{0}, [Servo Port], [-1000 to 1000]", ControlCommands.SET_CONTINUOUS_SPEED),
        string.Format("{0}, [Servo Port]", ControlCommands.SET_SERVO_MODE),
        string.Format("{0}, [Servo Port]", ControlCommands.SET_CONTINUOUS_MODE)
        };
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      if (windowCommand.Equals(ControlCommands.SET_POSITION_RAW, StringComparison.InvariantCultureIgnoreCase)) {

        if (values.Length != 2)
          throw new Exception("Expecting 2 parameters, which are the servo port and position");

        var port = (Servo.ServoPortEnum)Enum.Parse(typeof(Servo.ServoPortEnum), values[0], true);

        int position = Convert.ToInt32(values[1]);

        sendServoCommand(_controller.SetServoMove(port, position));
      } else if (windowCommand.Equals(ControlCommands.SET_CONTINUOUS_SPEED, StringComparison.InvariantCultureIgnoreCase)) {

        if (values.Length != 2)
          throw new Exception("Expecting 2 parameters, which are the servo port and speed between -1000 and 1000");

        var port = (Servo.ServoPortEnum)Enum.Parse(typeof(Servo.ServoPortEnum), values[0], true);

        int speed = Convert.ToInt32(values[1]);

        sendServoCommand(_controller.SetContinuousMode(port, speed));
      } else if (windowCommand.Equals(ControlCommands.SET_SERVO_MODE, StringComparison.InvariantCultureIgnoreCase)) {

        if (values.Length != 1)
          throw new Exception("Expecting 1 parameter, which is the servo port");

        var port = (Servo.ServoPortEnum)Enum.Parse(typeof(Servo.ServoPortEnum), values[0], true);

        _controller.SetServoInServoMode(port);

        sendServoCommand(_controller.SetModeServo(port));

        //        sendServoCommand(_controller.SetPositionLimits(port, 0, 1000));
      } else if (windowCommand.Equals(ControlCommands.SET_CONTINUOUS_MODE, StringComparison.InvariantCultureIgnoreCase)) {

        if (values.Length != 1)
          throw new Exception("Expecting 1 parameter, which is the servo port");

        var port = (Servo.ServoPortEnum)Enum.Parse(typeof(Servo.ServoPortEnum), values[0], true);

        _controller.SetServoInContinuousMode(port);
      } else {

        base.SendCommand(windowCommand, values);
      }
    }

    void Servo_OnServoMove(EZ_B.Classes.ServoPositionItem[] servos) {

      List<byte> cmdData = new List<byte>();

      foreach (var servo in servos) {

        if (servo.Port < EZ_B.Servo.ServoPortEnum.V0 || servo.Port > EZ_B.Servo.ServoPortEnum.V99)
          continue;

        if (_customConfig.VirtualPorts.Contains(servo.Port)) {

          if (_controller.IsServoInServoMode(servo.Port))
            cmdData.AddRange(_controller.SetServoMove(servo.Port, (int)Functions.RemapScalar(servo.Position, Servo.SERVO_MIN, Servo.SERVO_MAX, 1, 1000)));
          else
            cmdData.AddRange(_controller.SetContinuousMode(servo.Port, (int)Functions.RemapScalar(servo.Position, Servo.SERVO_MIN, Servo.SERVO_MAX, -1000, 1000)));
        }
      }

      sendServoCommand(cmdData.ToArray());
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
        _serialPort.Write(cmdData, 0, cmdData.Length);
    }

    private void ucConfigurationButton1_Click(object sender, EventArgs e) {

      using (FormConfig form = new FormConfig()) {

        if (_serialPort.IsOpen)
          _serialPort.Close();

        form.SetConfiguration(_cf);

        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          SetConfiguration(form.GetConfiguration());
      }
    }

    private void Servo_OnServoRelease(Servo.ServoPortEnum[] servos) {

      List<byte> cmdData = new List<byte>();

      foreach (var servo in servos) {

        if (servo < EZ_B.Servo.ServoPortEnum.V0 || servo > EZ_B.Servo.ServoPortEnum.V99)
          continue;

        if (_customConfig.VirtualPorts.Contains(servo)) {

          if (_controller.IsServoInServoMode(servo))
            cmdData.AddRange(_controller.SetMotorOn(servo, false));
          else
            cmdData.AddRange(_controller.SetContinuousMode(servo, 0));
        }
      }

      sendServoCommand(cmdData.ToArray());
    }

    private void Servo_OnServoGetPosition(Servo.ServoPortEnum servoPort, EZ_B.Classes.GetServoValueResponse getServoResponse) {

      if (getServoResponse.Success)
        return;

      if (!_customConfig.VirtualPorts.Contains(servoPort)) {

        getServoResponse.ErrorStr = "No matching lewansoul servo specified";
        getServoResponse.Success = false;

        return;
      }

      Invokers.SetAppendText(tbLog, true, "Reading position from {0}", servoPort);

      if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.COM_PORT]))
        getServoPositionComSerial(servoPort, getServoResponse);

      if (!getServoResponse.Success && Convert.ToBoolean(_cf.STORAGE[ConfigTitles.COM_PORT]))
        getServoPositionEZBUART(servoPort, getServoResponse);
    }

    private void getServoPositionComSerial(Servo.ServoPortEnum servoPort, EZ_B.Classes.GetServoValueResponse getServoResponse) {

      if (!_serialPort.IsOpen) {

        getServoResponse.Success = false;
        getServoResponse.ErrorStr = "Not connected to COM Port";

        return;
      }


      initUART();

      sendServoCommand(_controller.GetServoPosition(servoPort));

      System.Threading.Thread.Sleep(100);

      var ret = new byte[_serialPort.BytesToRead];

      _serialPort.Read(ret, 0, ret.Length);

      if (ret.Length != 14) {

        getServoResponse.ErrorStr = "Servo did not respond";
        getServoResponse.Success = false;

        return;
      }

      getServoResponse.Position = (int)EZ_B.Functions.RemapScalar(BitConverter.ToInt16(ret.Reverse().ToArray(), 0), 1, 1000, Servo.SERVO_MIN, Servo.SERVO_MAX);
      getServoResponse.Success = true;
    }

    private void getServoPositionEZBUART(Servo.ServoPortEnum servoPort, EZ_B.Classes.GetServoValueResponse getServoResponse) {

      if (!EZBManager.EZBs[0].IsConnected) {

        getServoResponse.Success = false;
        getServoResponse.ErrorStr = "Not connected to EZ-B 0";

        return;
      }

      if (!Convert.ToBoolean(_cf.STORAGE[ConfigTitles.USE_HARDWARE_UART])) {

        getServoResponse.ErrorStr = "This feature is only available when using the hardware uart";
        getServoResponse.Success = false;

        return;
      }

      initUART();

      sendServoCommand(_controller.GetServoPosition(servoPort));

      System.Threading.Thread.Sleep(100);

      var ret = EZBManager.EZBs[0].Uart.UARTExpansionReadAvailable(Convert.ToInt16(_cf.STORAGE[ConfigTitles.HARDWARE_PORT]));

      if (ret.Length != 14) {

        getServoResponse.ErrorStr = "Servo did not respond";
        getServoResponse.Success = false;

        return;
      }

      getServoResponse.Position = (int)EZ_B.Functions.RemapScalar(BitConverter.ToInt16(ret.Reverse().ToArray(), 0), 1, 1000, Servo.SERVO_MIN, Servo.SERVO_MAX);
      getServoResponse.Success = true;
    }
  }
}
