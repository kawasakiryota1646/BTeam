using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブを参照

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            StartCoroutine(HandleExplosion()); // コルーチンを開始
            Destroy(gameObject); // 味方機体を消滅させる
        }
    }

    private IEnumerator HandleExplosion()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation); // 爆発エフェクトをインスタンス化
        Debug.Log("Explosion instantiated"); // デバッグログ
        yield return new WaitForSeconds(0.5f); // 0.5秒待機
        Destroy(explosion); // 爆発エフェクトを消滅させる
        Debug.Log("Explosion destroyed"); // デバッグログ
    }
}







