using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool JoystickButtonTrigger;
    float beforeTriggerAxis;

    void Update()
    {
        JoystickButtonTrigger = (
            Input.GetAxis("joystick button trigger") != 0 &&
            beforeTriggerAxis == 0);

        beforeTriggerAxis = Input.GetAxis("joystick button trigger");
    }

    public bool GetJoystickButtonTrigger()
    {
        return JoystickButtonTrigger;
    }
}
