using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRange : MonoBehaviour
{
    [SerializeField]
    Player Player;

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MoveBlock") &&
            Player.GetIsGrounded())
        {
            Player.SetIsGrab(true);
            Player.SetGrabBlock(other.gameObject.GetComponent<MoveBlock>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MoveBlock"))
        {
            Player.SetIsGrab(false);
            Player.SetGrabBlock(null);
        }
    }
}
