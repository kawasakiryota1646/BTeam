using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriend : MonoBehaviour
{
    public float speed = 20f;     // 弾の速度
    public float lifeTime = 2f;   // 弾の寿命
    public int damage = 1;        //弾のダメージ

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);  // 一定時間後に弾を削除
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵に当たったかどうかをチェック
        TEKIHP enemy = collision.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            // 敵にダメージを与える
            enemy.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }
    }
}
