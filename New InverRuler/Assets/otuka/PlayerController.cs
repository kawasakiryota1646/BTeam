using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float speed = 3.0f; //移動スピード
    float axisH; //横軸
    float axisV; //縦軸
    Rigidbody2D rbody; //Rigidbody2D
    //ダメージ対応
    public static int hp = 3; //プレイヤーのHP
    public static string gameState; //ゲームの状態
    bool inDamage = false; //ダメージ中フラグ
   

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60; // FPSを60に固定

        rbody = GetComponent<Rigidbody2D>();//Rigidbody2を得る
       //ゲームの状態をプレイ中にする
        gameState = "playing";

    }

    // Update is called once per frame
    void Update()
    {
        
        axisH = Input.GetAxisRaw("Horizontal"); //左右キー入力
        axisV = Input.GetAxisRaw("Vertical"); //上下キー入力

        if(hp == 0)
        {
            GameOver();
        }
    }

    void FixedUpdate()
    {
       
        //移動速度を更新する
        rbody.velocity = new Vector2(axisH, axisV).normalized * speed;
    }

    //接触
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage1(collision.gameObject);
        }
    }

    //ダメージ
    void GetDamage(GameObject enemy)
    {

        if(gameState == "playing")
        {
            hp--; //を減らす
            if(hp > 0)
            {
                //ダメージフラグON
                inDamage = true;
                Invoke("DamageEnd",0.25f);
            }
        }
        
    }
    void GetDamage1(GameObject enemy)
    {

        if (gameState == "playing")
        {
            hp--; //を減らす
            if (hp > 0)
            {
                //ダメージフラグON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
        }

    }

    public void Clear()
    {

    }
    //ゲームオーバー
    void GameOver()
    {
        gameState = "gameover";
        //ゲームオーバー演出
        GetComponent<BoxCollider2D>().enabled = false; //プレイヤーあたりを消す
        Destroy(player, 0.1f); //1秒後にプレイヤーを消す
    }

   
}
