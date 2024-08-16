using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @brief 	敵の基本移動処理
*/
public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;         // 敵の移動速度

    private float direction = 1;    // 敵の移動する向き
    Rigidbody2D rb = null;          // 敵のRigidbody2D
    TenpState enemyState = null;    // 敵の状態

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        enemyState = GetComponent<TenpState>();
    }

    private void FixedUpdate()
    {
        // 状態毎に動きを変える
        switch (enemyState.state)
        {
            case TenpState.State.Normal:
                // 簡単な左右移動
                rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
                break;

            case TenpState.State.Dead:
                // 死んだ
                break;

            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁に当たったら移動する向きを逆転する
        if(collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}