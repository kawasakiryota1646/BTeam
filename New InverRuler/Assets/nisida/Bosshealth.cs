using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshealth : MonoBehaviour
{
    public float health = 50f;  // 敵の体力
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;
    public GameObject[] deathEffects; // 死亡時のエフェクト（3段階）
    public GameObject retryButton; // リトライボタン
    public GameObject nextButton; // 次へボタン
    public GameObject gameClearText; // GAMEクリアのテキスト
    public BGMController bgmController; // BGMコントローラー
    public GameObject coinPrefab; // コインのプレハブ
    public int coinCount = 10; // 生成するコインの数
    public int coinsToAdd = 10; // 追加するコインの数

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // ボタンとテキストを非表示にする
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        gameClearText.SetActive(false);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            StartCoroutine(Die());
        }
        StartCoroutine(Flash());
    }

    IEnumerator Die()
    {
        yield return StartCoroutine(HandleExplosion()); // コルーチンを開始
        Destroy(gameObject); // 敵を消す

      

        // ボタンとテキストを表示する
        retryButton.SetActive(true);
        nextButton.SetActive(true);
        gameClearText.SetActive(true);

        // ゲームクリアBGMを再生する
        if (bgmController != null)
        {
            bgmController.PlayGameClearBGM();
        }

        // コインを生成する
        SpawnCoins();

        // コインを追加する
        CoinManager.instance.AddCoins(coinsToAdd);
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // 点滅色
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            StartCoroutine(HideCoinAfterDelay(coin, 2f)); // 2秒後にコインを非表示にする
        }
    }

    IEnumerator HideCoinAfterDelay(GameObject coin, float delay)
    {
        yield return new WaitForSeconds(delay);
        coin.SetActive(false); // コインを非表示にする
    }

    IEnumerator HandleExplosion()
    {
        // 3段階のエフェクトを0.2秒ずつ表示
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); // 1秒後にエフェクトを消去
            yield return new WaitForSeconds(0.2f);
        }
    }
}











