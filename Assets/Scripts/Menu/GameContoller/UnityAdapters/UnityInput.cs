using UnityEngine;

public class UnityInput
{
    public virtual bool GetButton(string buttonName) =>
            Input.GetButton(buttonName);

    public virtual float GetAxis(string axisName) =>
            Input.GetAxis(axisName);

}
