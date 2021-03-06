﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 
    [SerializeField]
    Position Position;

    [SerializeField]
    Camera sideCamera;

    [SerializeField]
    Camera upCamera;

    [SerializeField]
    Player another;

    [SerializeField]
    Rigidbody Rigidbody;

    [SerializeField]
    private Animator animator = null;

    Position PlayingPosition;
    bool isPlaying;
    bool isUp;

    // 物を掴めるかどうか
    bool isGrab;
    // 物を掴んでいるかどうか
    bool isGrabing;
    // 掴んでいるブロック
    MoveBlock GrabBlock;
    [SerializeField]
    BoxCollider MoveBlockCollider;
    Vector3 difference;


    bool isGrounded;

    float moveSpeed = 7.5f;

    Vector3 velocity;

    [SerializeField]
    StageController StageController;

    int stageLength;

    // 事前参照用の変数
    private new Rigidbody rigidbody = null;
    // アニメーションのパラメーターID
    static readonly int speedId = Animator.StringToHash("Speed");

    // プレイヤーの状態を表します。
    enum PlayerState
    {
        Idle,
        Walk,
    }

    // 現在のプレイヤー状態
    [SerializeField]
    PlayerState currentState = PlayerState.Idle;

    void Start()
    {
        isUp = false;
        isGrabing = false;
        MoveBlockCollider.enabled = false;

        stageLength = StageController.GetStageLength();

        // コンポーネントを事前に参照
        rigidbody = GetComponent<Rigidbody>();
        currentState = PlayerState.Idle;
    }

    void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:

            case PlayerState.Walk:
                // 移動操作[-1, 1]
                var horizontal = Input.GetAxis("Horizontal");
                var vertical   = Input.GetAxis("Vertical");

                animator.SetFloat(speedId, Mathf.Abs(horizontal));

                isGrounded = IsGrounded();

                if (isGrab &&
                    isGrounded &&
                    PlayingPosition == Position &&
                    Input.GetButtonDown("Fire2"))
                {
                    MoveBlockCollider.enabled = true;
                    MoveBlockCollider.size = GrabBlock.GetCollider().size;

                    difference = new Vector3(GrabBlock.transform.position.x - transform.position.x,
                                             MoveBlockCollider.size.y / 2f,
                                            (GrabBlock.transform.position.z - transform.position.z) * (Position == Position.AboveGround ? 1 : -1));

                    MoveBlockCollider.center = difference;
                    GrabBlock.GetCollider().enabled = false;

                    difference = new Vector3(difference.x,
                                             GrabBlock.transform.position.y - transform.position.y,
                                            -difference.z);

                    isGrabing = true;
                }
                if (isGrabing &&
                    PlayingPosition == Position)
                {
                    GrabBlock.transform.position = transform.position + difference;
                }
                if (isGrab &&
                    PlayingPosition == Position &&
                    Input.GetButtonUp("Fire2"))
                {
                    MoveBlockCollider.enabled = false;
                    GrabBlock.GetCollider().enabled = true;

                    isGrabing = false;
                }


                velocity = Vector3.zero;

                velocity = new Vector3(
                    horizontal * moveSpeed * Time.deltaTime * (isPlaying ? 1 : -1) * (isGrounded ? 1 : 0.75f),
                    0,
                    isUp ? vertical * moveSpeed * Time.deltaTime * (PlayingPosition == Position.UnderWater ? 1 : -1) : 0) * (isGrounded ? 1 : 0.75f);

                if (horizontal != 0 ||
                    vertical != 0)
                {
                    float rotate;

                    if (isPlaying &&
                        PlayingPosition == Position.AboveGround)
                    {
                        rotate = Mathf.Atan2( vertical, horizontal) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(new Vector3(0, rotate, 0));
                    }
                    else if (
                        isPlaying &&
                        PlayingPosition == Position.UnderWater)
                    {
                        rotate = Mathf.Atan2(-vertical, horizontal) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(new Vector3(180, rotate - 180, 0));
                    }
                }

                //if (isPlaying)
                //{
                //    velocity = new Vector3(
                //        horizontal * moveSpeed * Time.deltaTime,
                //        0,
                //        Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
                //}

                transform.position += velocity;

                if (isGrabing == false &&
                    Input.GetButtonDown("Fire1"))
                {
                    Jump();
                }

                if (isGrounded == false)
                {
                    AddGravityForce();
                }
                break;
            default:
                break;
        }


    }

    void LateUpdate()
    {
        float LimitRange = stageLength * 3.5f - 8.9f;

        if (transform.position.x <= -LimitRange ||
            transform.position.x >= LimitRange)
        {
            return;
        }

        sideCamera.transform.position = new Vector3(
            transform.position.x,
            sideCamera.transform.position.y,
            sideCamera.transform.position.z);

        upCamera.transform.position = new Vector3(
            transform.position.x,
            upCamera.transform.position.y,
            upCamera.transform.position.z);
    }

    void AddGravityForce()
    {
        Rigidbody.AddForce((Position == Position.AboveGround ? Vector3.down : Vector3.up) * 600 * Time.deltaTime, ForceMode.Force);
        //velocity += new Vector3(0, 9.81f * Time.deltaTime * (Position == Position.AboveGround ? -1 : 1), 0);
    }

    void Jump()
    {
        if (isGrounded)
        {
            Rigidbody.AddForce((Position == Position.AboveGround ? Vector3.up : Vector3.down) * 5, ForceMode.Impulse);
        }
    }
    // 接地判定
    bool IsGrounded()
    {
        Ray ray = new Ray(
            gameObject.transform.position + (Position == Position.AboveGround ? Vector3.up * 0.05f : Vector3.down * 0.05f), 
            (Position == Position.AboveGround ? Vector3.down : Vector3.up));

        //Debug.DrawRay(ray.origin, ray.direction * 0.1f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.1f))
        {
            if ((!hit.collider.CompareTag("Player")) &&
                hit.distance <= 0.1f)
            {
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

    public bool GetIsGrounded()
    {
        return isGrounded;
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
