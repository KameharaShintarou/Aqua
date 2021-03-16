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

    [SerializeField]
    Rigidbody Rigidbody;

    Position PlayingPosition;
    bool isPlaying;
    bool isUp;

    bool isGrab;
    MoveBlock GrabBlock;

    bool isGrounded;

    float moveSpeed = 10;

    Vector3 velocity;

    void Start()
    {
        isUp = false;
    }

    void Update()
    {
        isGrounded = IsGrounded();

        velocity = Vector3.zero;

        velocity = new Vector3(
            Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * (isPlaying ? 1 : -1),
            0,
            isUp ? Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * (PlayingPosition == Position.UnderWater ? 1 : -1) : 0);

        transform.position += velocity;

        if (isGrab &&
            PlayingPosition == Position &&
            Input.GetKey("joystick button 1"))
        {
            GrabBlock.transform.position += velocity;
        }
        if (Input.GetKeyDown("joystick button 0"))
        {
            Jump();
        }

        if (!isGrounded)
        {
            AddGravityForce();
        }
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

    void AddGravityForce()
    {
        Rigidbody.AddForce((Position == Position.AboveGround ? Vector3.down : Vector3.up) * 5, ForceMode.Force);
        //velocity += new Vector3(0, 9.81f * Time.deltaTime * (Position == Position.AboveGround ? -1 : 1), 0);
    }

    void Jump()
    {
        if (isGrounded)
        {
            Rigidbody.AddForce((Position == Position.AboveGround ? Vector3.up : Vector3.down) * 5, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray ray = new Ray(
            gameObject.transform.position + (Position == Position.AboveGround ? Vector3.up * 0.05f : Vector3.down * 0.05f), 
            (Position == Position.AboveGround ? Vector3.down : Vector3.up));

        Debug.DrawRay(ray.origin, ray.direction * 0.1f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.1f))
        {
            if ((!hit.collider.CompareTag("Player")) &&
                hit.distance <= 0.1f)
            {
                Debug.Log("Ground");
                return true;
            }
        }

        return false;
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

    public void SetIsGrab(bool f)
    {
        isGrab = f;
    }

    public void SetGrabBlock(MoveBlock moveBlock)
    {
        GrabBlock = moveBlock;
    }

    public bool GetIsPlaying()
    {
        return isPlaying;
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
