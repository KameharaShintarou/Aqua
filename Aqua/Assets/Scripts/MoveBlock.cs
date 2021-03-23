using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField]
    GameObject LinkBlock;

    bool isWall;

    Vector3 beforePosition;

    BoxCollider Collider;

    void Start()
    {
        Collider = gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (beforePosition != transform.position)
        {
            Vector3 position = new Vector3(
                -transform.position.x,
                -transform.position.y,
                 transform.position.z);

            LinkBlock.transform.position = position;
        }
    }

    public void SetLinkBlock(GameObject gameObject)
    {
        LinkBlock = gameObject;
        beforePosition = transform.position;
    }

    public void SetIsWall(bool f)
    {
        isWall = f;
    }

    public BoxCollider GetCollider()
    {
        return Collider;
    }
}
