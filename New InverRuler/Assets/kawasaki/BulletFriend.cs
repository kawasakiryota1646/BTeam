using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriend : MonoBehaviour
{
    public float speed = 20f;     // 弾の速度
    public float lifeTime = 2f;   // 弾の寿命

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);  // 一定時間後に弾を削除
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // `Enemy`タグを持つオブジェクトに当たった場合
        if (other.CompareTag("Enemy"))
        {
            // 弾を消滅させる
            Destroy(gameObject);
        }
    }
}
