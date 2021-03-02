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

    bool isPlaying;

    float moveSpeed = 10;

    //[SerializeField]
    //MeshRenderer MeshRenderer;

    [SerializeField]
    SkinnedMeshRenderer[] Renderers;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        transform.position += move * (isPlaying ? 1: -1);
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
            UpCamera.transform.position.z);
    }

    public void SetPosition(Position position)
    {
        Position = position;

        switch (position)
        {
            case Position.AboveGround:
                SetIsPlaying(true);
                break;

            case Position.UnderWater:
                SetIsPlaying(false);
                break;
        }
    }

    void SetIsPlaying(bool f)
    {
        isPlaying = f;
    }

    public void ChangePosition()
    {
        if (isPlaying)
        {
            SetIsPlaying(false);
        }
        else
        {
            SetIsPlaying(true);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            another.transform.position = new Vector3(
                -transform.position.x,
                another.transform.position.y,
                -transform.position.z);
        }
    }
}
