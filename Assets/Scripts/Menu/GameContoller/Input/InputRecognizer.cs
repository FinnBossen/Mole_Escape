using System;
using System.Collections.Generic;
using System.Linq;

public class InputRecognizer
{
    readonly UnityInput unityInput;

    public InputRecognizer(UnityInput unityInput)
    {
        this.unityInput = unityInput;
    }

    public IEnumerable<Joystick> GetJoystickWichPress(params JoystickButton[] buttons)
    {
        for (var joyIndex = 1; joyIndex <= 6; joyIndex++)
        {

            if (!buttons.Any())
                buttons = Enum.GetValues(typeof(JoystickButton)).Cast<JoystickButton>().ToArray();

            var pressed =
                buttons
                    .Select(button => button.GetInputName(joyIndex))
                    .Any(unityInput.GetButton);

            if (pressed)
                yield return (Joystick)Enum.Parse(typeof(Joystick), $"_{joyIndex}");

        }

    }


}
