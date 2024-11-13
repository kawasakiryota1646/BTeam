using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshealth : MonoBehaviour
{
    public float health = 50f;  // 敵の体力
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;

    public GameObject retryButton; // リトライボタン
    public GameObject nextButton; // 次へボタン
    public GameObject gameClearText; // GAMEクリアのテキスト
    public AudioClip gameClearBGM; // ゲームクリア時のBGM

    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // ボタンとテキストを非表示にする
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        gameClearText.SetActive(false);

        // AudioSourceコンポーネントを追加
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Die();
        }
        StartCoroutine(Flash());
    }

    void Die()
    {
        Destroy(gameObject); // 敵を消す

        // ボタンとテキストを表示する
        retryButton.SetActive(true);
        nextButton.SetActive(true);
        gameClearText.SetActive(true);

        // ゲームクリアBGMを再生する
        audioSource.clip = gameClearBGM;
        audioSource.Play();
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // 点滅色
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

