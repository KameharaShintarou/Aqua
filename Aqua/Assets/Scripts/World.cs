using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Position
{
    AboveGround,
    UnderWater,
}

public class World : MonoBehaviour
{
    [SerializeField]
    Camera SideCamera;

    [SerializeField]
    Camera UpCamera;

    [SerializeField]
    Player Player;

    [SerializeField]
    Position Position;

    [SerializeField]
    ViewPoint ViewPoint;

    // Start is called before the first frame update
    void Start()
    {
        Player.SetPosition(Position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition()
    {
        Player.ChangePosition();

        switch (ViewPoint)
        {
            case ViewPoint.Side:
                SideCamera.depth = (SideCamera.depth == 1 ? -1 : 1);
                break;
            case ViewPoint.Up:
                UpCamera.depth = (UpCamera.depth == 1 ? -1 : 1);
                break;
        }
    }

    public void SetViewPoint(ViewPoint viewPoint, Position playingPosition)
    {
        ViewPoint = viewPoint;

        if (Position == playingPosition)
        {
            switch (ViewPoint)
            {
                case ViewPoint.Side:
                    SideCamera.depth = 1;
                    UpCamera.depth = -1;
                    break;

                case ViewPoint.Up:
                    SideCamera.depth = -1;
                    UpCamera.depth = 1;
                    break;
            }
        }
    }
}
