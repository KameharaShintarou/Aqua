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
    World AboveGround;

    [SerializeField]
    World UnderWater;

    [SerializeField]
    Position PlayingPosition;

    [SerializeField]
    ViewPoint ViewPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AboveGround.ChangePosition();
            UnderWater.ChangePosition();

            switch (PlayingPosition)
            {
                case Position.AboveGround:
                    PlayingPosition = Position.UnderWater;
                    break;
                case Position.UnderWater:
                    PlayingPosition = Position.AboveGround;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
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
