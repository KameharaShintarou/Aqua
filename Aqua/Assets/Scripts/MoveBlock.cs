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

    GameObject Effect;

    float moveTime;

    void Start()
    {
        Collider = gameObject.GetComponent<BoxCollider>();
        Effect = (GameObject)Resources.Load("Prefabs/DustParticle");
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

            if (moveTime > 0.1f)
            {
                moveTime = 0;
                Instantiate(Effect, transform.position - Vector3.up * 2.1f, Quaternion.Euler(-90, 0, 0));
            }

            moveTime += Time.deltaTime;
        }

        beforePosition = transform.position;
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
