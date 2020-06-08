public enum JoystickButton { A, B, X, Y, Start }
public enum Joystick { _1, _2, _3, _4, _5, _6 }

public static class JoystickExtensions
{
    public static string ToNumber(this Joystick joystick) => joystick.ToString().Substring(1);

    public static string GetInputName(this JoystickButton button, int joystick) =>
        $"J{joystick}.{button}";

    public static string GetInputName(this JoystickButton button, Joystick joystick) =>
        $"J{joystick.ToNumber()}.{button}";

    public static string GetVerticalAxisName(this Joystick joystick) =>
        $"J{joystick.ToNumber()}.Vertical";
    public static string GetHorizontalAxisName(this Joystick joystick) =>
        $"J{joystick.ToNumber()}.Horizontal";

}

