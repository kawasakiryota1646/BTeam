using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioClip normalBGM; // �ʏ��BGM
    public AudioClip gameClearBGM; // �Q�[���N���A��BGM
    public AudioClip gameOverBGM; // �Q�[���I�[�o�[��BGM
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM(normalBGM, true); // �ŏ��ɒʏ��BGM�����[�v�Đ�
    }

    public void PlayBGM(AudioClip bgm, bool loop)
    {
        if (audioSource.clip != bgm)
        {
            audioSource.clip = bgm;
            audioSource.loop = loop;
            audioSource.Play();
        }
    }

    public void PlayNormalBGM()
    {
        PlayBGM(normalBGM, true); // �ʏ��BGM�����[�v�Đ�
    }

    public void PlayGameClearBGM()
    {
        PlayBGM(gameClearBGM, false); // �Q�[���N���A��BGM�����[�v�Đ����Ȃ�
    }

    public void PlayGameOverBGM()
    {
        PlayBGM(gameOverBGM, true); // �Q�[���I�[�o�[��BGM�����[�v�Đ�
    }
}
