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

    // 事前参照用の変数
    private new Rigidbody rigidbody = null;

    //[SerializeField]
    //MeshRenderer MeshRenderer;

    [SerializeField]
    SkinnedMeshRenderer[] Renderers;

    [SerializeField]
    private Animator animator = null;

    // プレイヤーの状態を表します。
    enum PlayerState
    {
        Idle,
        Walk,
    }
    // 現在のプレイヤー状態
    [SerializeField]
    PlayerState currentState = PlayerState.Idle;

    static readonly int speedId = Animator.StringToHash("Speed");

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
            case PlayerState.Walk:
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

                var horizontal = Input.GetAxis("Horizontal");

                transform.position += move * (isPlaying ? 1: -1);

                animator.SetFloat(speedId, Mathf.Abs(horizontal));
                break;
            default:
                break;
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
