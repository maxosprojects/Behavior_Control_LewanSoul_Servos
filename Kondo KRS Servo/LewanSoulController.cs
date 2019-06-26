using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ_B;

namespace LewanSoul_Servos {

  public class LewanSoulController {

    readonly byte    SERVO_ID_ALL = 0xfe   ;
    readonly byte    SERVO_MOVE_TIME_WRITE = 1 ;
    readonly byte    SERVO_MOVE_TIME_READ = 2  ;
    readonly byte    SERVO_MOVE_TIME_WAIT_WRITE = 7  ;
    readonly byte    SERVO_MOVE_TIME_WAIT_READ = 8 ;
    readonly byte    SERVO_MOVE_START = 11 ;
    readonly byte    SERVO_MOVE_STOP = 12  ;
    readonly byte    SERVO_ID_WRITE = 13 ;
    readonly byte    SERVO_ID_READ = 14  ;
    readonly byte    SERVO_ANGLE_OFFSET_ADJUST = 17  ;
    readonly byte    SERVO_ANGLE_OFFSET_WRITE = 18 ;
    readonly byte    SERVO_ANGLE_OFFSET_READ = 19  ;
    readonly byte    SERVO_ANGLE_LIMIT_WRITE = 20  ;
    readonly byte    SERVO_ANGLE_LIMIT_READ = 21 ;
    readonly byte    SERVO_VIN_LIMIT_WRITE = 22  ;
    readonly byte    SERVO_VIN_LIMIT_READ = 23 ;
    readonly byte    SERVO_TEMP_MAX_LIMIT_WRITE = 24 ;
    readonly byte    SERVO_TEMP_MAX_LIMIT_READ = 25  ;
    readonly byte    SERVO_TEMP_READ = 26  ;
    readonly byte    SERVO_VIN_READ = 27 ;
    readonly byte    SERVO_POS_READ = 28 ;
    readonly byte    SERVO_OR_MOTOR_MODE_WRITE = 29  ;
    readonly byte    SERVO_OR_MOTOR_MODE_READ = 30 ;
    readonly byte    SERVO_LOAD_OR_UNLOAD_WRITE = 31 ;
    readonly byte    SERVO_LOAD_OR_UNLOAD_READ = 32  ;
    readonly byte    SERVO_LED_CTRL_WRITE = 33 ;
    readonly byte    SERVO_LED_CTRL_READ = 34  ;
    readonly byte    SERVO_LED_ERROR_WRITE = 35  ;
    readonly byte    SERVO_LED_ERROR_READ = 36 ;
    readonly byte    SERVO_ERROR_OVER_TEMPERATURE = 1  ;
    readonly byte    SERVO_ERROR_OVER_VOLTAGE = 2  ;
    readonly byte    SERVO_ERROR_LOCKED_ROTOR = 4  ;

    List<Servo.ServoPortEnum> _MOTOR_MODE_SERVOS = new List<Servo.ServoPortEnum>();

    byte[] getMasterCommand(Servo.ServoPortEnum servo, byte cmd, params byte[] payload) {

      List<byte> data = new List<byte>();
      data.Add(0x55);
      data.Add(0x55);
      data.Add((byte)(servo - Servo.ServoPortEnum.V0));
      data.Add((byte)(payload.Length + 3)); // length = this + cmd + payload + checksum
      data.Add(cmd);

      foreach (var b in payload)
        data.Add(b);

      int checksum = 0;

      for (int x = 2; x < data.Count; x++)
        checksum += data[x];

      checksum = ~checksum;

      data.Add((byte)(checksum & 0xff));

      return data.ToArray();
    }

    public byte[] SetModeServo(Servo.ServoPortEnum servo) {

      return getMasterCommand(
        servo,
        SERVO_OR_MOTOR_MODE_WRITE,
        0,
        0,
        0,
        0);
    }

    public bool IsServoInServoMode(Servo.ServoPortEnum servo) {

      return !_MOTOR_MODE_SERVOS.Contains(servo);
    }

    public void SetServoInContinuousMode(Servo.ServoPortEnum servo) {

      if (_MOTOR_MODE_SERVOS.Contains(servo))
        return;

      _MOTOR_MODE_SERVOS.Add(servo);
    }

    public void SetServoInServoMode(Servo.ServoPortEnum servo) {

      _MOTOR_MODE_SERVOS.Remove(servo);
    }

    public byte[] SetMotorOn(Servo.ServoPortEnum servo, bool status) {

      return getMasterCommand(
        servo,
        SERVO_LOAD_OR_UNLOAD_WRITE,
        status ? (byte)1 : (byte)0);
    }

    public byte[] SetPositionLimits(Servo.ServoPortEnum servo, int minPosition, int maxPosition) {

      minPosition = Functions.Clamp(minPosition, 0, 1000);
      maxPosition = Functions.Clamp(maxPosition, 0, 1000);

      byte[] minArray = BitConverter.GetBytes((Int16)minPosition);
      byte[] maxArray = BitConverter.GetBytes((Int16)maxPosition);

      return getMasterCommand(
        servo,
        SERVO_ANGLE_LIMIT_WRITE,
        minArray[0],
        minArray[1],
        maxArray[0],
        maxArray[1]);
    }

    public byte[] SetContinuousMode(Servo.ServoPortEnum servo, int speed) {

      byte[] speedArray = BitConverter.GetBytes((Int16)speed);

      return getMasterCommand(
        servo,
        SERVO_OR_MOTOR_MODE_WRITE,
        1,
        0,
        speedArray[0],
        speedArray[1]);
    }

    public byte[] SetServoId(Servo.ServoPortEnum servo, Servo.ServoPortEnum newId) {

      return getMasterCommand(
        servo,
        SERVO_ID_WRITE,
        (byte)(newId - Servo.ServoPortEnum.V0));
    }

    public byte[] SetServoMove(Servo.ServoPortEnum servo, int position) {

      byte[] positionArray = BitConverter.GetBytes((Int16)position);

      return getMasterCommand(
        servo,
        SERVO_MOVE_TIME_WRITE,
        positionArray[0], // 1 - lower 8 angle
        positionArray[1], // 2 - higher 8 angle
        0x00, // 3 - lower 8 of time
        0x00); // 4 - higher 8 of time
    }

    public byte[] GetServoPosition(Servo.ServoPortEnum servo) {

      return getMasterCommand(
        servo,
        SERVO_POS_READ);
    }
  }
}
