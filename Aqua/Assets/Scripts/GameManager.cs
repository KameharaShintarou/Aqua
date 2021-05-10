using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewPoint
{
    Side,
    Up,
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    InputManager InputManager;

    [SerializeField]
    World AboveGround;

    [SerializeField]
    World UnderWater;

    [SerializeField]
    Position PlayingPosition;

    [SerializeField]
    ViewPoint ViewPoint;

    void Update()
    {
        if (InputManager.GetJoystickButtonTrigger() ||
            Input.GetKeyDown(KeyCode.Return))
        {
            switch (PlayingPosition)
            {
                case Position.AboveGround:
                    PlayingPosition = Position.UnderWater;
                    break;
                case Position.UnderWater:
                    PlayingPosition = Position.AboveGround;
                    break;
            }

            AboveGround.ChangePosition(PlayingPosition);
            UnderWater.ChangePosition(PlayingPosition);
        }
        else if (Input.GetKeyDown("joystick button 4") ||
                 Input.GetKeyDown("joystick button 5") ||
                 Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeViewPoint();
        }
    }

    void ChangeViewPoint()
    {
        switch (ViewPoint)
        {
            case ViewPoint.Side:
                ViewPoint = ViewPoint.Up;

                break;

            case ViewPoint.Up:
                ViewPoint = ViewPoint.Side;

                break;
        }

        AboveGround.SetViewPoint(ViewPoint, PlayingPosition);
        UnderWater.SetViewPoint(ViewPoint, PlayingPosition);
    }
}
