using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshealth : MonoBehaviour
{
    public float health = 50f;  // �G�̗̑�
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;
    public GameObject[] deathEffects; // ���S���̃G�t�F�N�g�i3�i�K�j
    public GameObject retryButton; // ���g���C�{�^��
    public GameObject nextButton; // ���փ{�^��
    public GameObject gameClearText; // GAME�N���A�̃e�L�X�g
    public BGMController bgmController; // BGM�R���g���[���[
    public GameObject coinPrefab; // �R�C���̃v���n�u
    public int coinCount = 10; // ��������R�C���̐�
    public int coinsToAdd = 10; // �ǉ�����R�C���̐�

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // �{�^���ƃe�L�X�g���\���ɂ���
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        gameClearText.SetActive(false);
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

    IEnumerator Die()
    {
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f); // 0.5�b��ɃG�t�F�N�g������
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(gameObject); // �G������

        // �{�^���ƃe�L�X�g��\������
        retryButton.SetActive(true);
        nextButton.SetActive(true);
        gameClearText.SetActive(true);

        // �Q�[���N���ABGM���Đ�����
        if (bgmController != null)
        {
            bgmController.PlayGameClearBGM();
        }

        // �R�C���𐶐�����
        SpawnCoins();

        // �R�C����ǉ�����
        CoinManager.instance.AddCoins(coinsToAdd);

        // �Q�[�����~����
        Time.timeScale = 0f;
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // �_�ŐF
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            StartCoroutine(HideCoinAfterDelay(coin, 2f)); // 2�b��ɃR�C�����\���ɂ���
        }
    }

    private IEnumerator HideCoinAfterDelay(GameObject coin, float delay)
    {
        yield return new WaitForSeconds(delay);
        coin.SetActive(false); // �R�C�����\���ɂ���
    }
}










