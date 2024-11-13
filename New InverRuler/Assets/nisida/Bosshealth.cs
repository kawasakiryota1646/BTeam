using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshealth : MonoBehaviour
{
    public float health = 50f;  // �G�̗̑�
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;

    public GameObject retryButton; // ���g���C�{�^��
    public GameObject nextButton; // ���փ{�^��
    public GameObject gameClearText; // GAME�N���A�̃e�L�X�g
    public AudioClip gameClearBGM; // �Q�[���N���A����BGM

    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // �{�^���ƃe�L�X�g���\���ɂ���
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        gameClearText.SetActive(false);

        // AudioSource�R���|�[�l���g��ǉ�
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
        Destroy(gameObject); // �G������

        // �{�^���ƃe�L�X�g��\������
        retryButton.SetActive(true);
        nextButton.SetActive(true);
        gameClearText.SetActive(true);

        // �Q�[���N���ABGM���Đ�����
        audioSource.clip = gameClearBGM;
        audioSource.Play();
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // �_�ŐF
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

