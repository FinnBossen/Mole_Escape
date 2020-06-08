using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] Joystick JoystickNumber;
    UnityInput input;

    [Inject]
    public void Construct(UnityInput input)
    {
        this.input = input;
    }

    public float Horizontal => input.GetAxis(JoystickNumber.GetHorizontalAxisName());
    public float Vertical => input.GetAxis(JoystickNumber.GetVerticalAxisName());

    public void AssignJoystick(Joystick joystick) => JoystickNumber = joystick;

    public bool ButtonIsDown(JoystickButton button) =>
          input.GetButton(button.GetInputName(JoystickNumber));
}
