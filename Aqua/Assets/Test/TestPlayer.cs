using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    // 移動速度を指定します。
    [SerializeField]
    private float moveSpeed = 5;

    // プレイヤーのAnimatorコンポーネントを指定します。
    [SerializeField]
    private Animator animator = null;

    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ユーザー入力を取得
        var vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = transform.forward * moveSpeed * vertical;

        // AnimatorのSpeedパラメーターを設定
        animator.SetFloat("Speed", Mathf.Abs(vertical));
    }
}
