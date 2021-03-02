using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Position Position;

    [SerializeField]
    Camera SideCamera;

    [SerializeField]
    Camera UpCamera;

    [SerializeField]
    Player another;

    Position PlayingPosition;
    bool isPlaying;
    bool isUp;

    float moveSpeed = 10;

    //[SerializeField]
    //MeshRenderer MeshRenderer;

    [SerializeField]
    SkinnedMeshRenderer[] Renderers;

    void Start()
    {
        isUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(
            Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * (isPlaying ? 1 : -1),
            0,
            isUp ? Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * (PlayingPosition == Position.UnderWater ? -1 : 1) : 0);

        transform.position += move;
    }

    void LateUpdate()
    {
        SideCamera.transform.position = new Vector3(
            transform.position.x,
            SideCamera.transform.position.y,
            SideCamera.transform.position.z);

        UpCamera.transform.position = new Vector3(
            transform.position.x,
            UpCamera.transform.position.y,
            transform.position.z);
    }

    public void SetPosition(Position position)
    {
        Position = position;

        switch (position)
        {
            case Position.AboveGround:
                SetIsPlaying(true);

                another.transform.position = new Vector3(
                    -transform.position.x,
                    another.transform.position.y,
                    -transform.position.z);
                break;

            case Position.UnderWater:
                SetIsPlaying(false);
                break;
        }
    }

    public void ChangePosition(Position position)
    {
        PlayingPosition = position;

        if (isPlaying)
        {
            SetIsPlaying(false);
        }
        else
        {
            SetIsPlaying(true);
        }
    }

    public void SetIsUp(bool f)
    {
        isUp = f;
    }

    void SetIsPlaying(bool f)
    {
        isPlaying = f;
    }

    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            another.transform.position = new Vector3(
                -transform.position.x,
                another.transform.position.y,
                transform.position.z);
        }
    }
}
