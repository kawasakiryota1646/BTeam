using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioClip normalBGM; // 通常のBGM
    public AudioClip gameClearBGM; // ゲームクリアのBGM
    public AudioClip gameOverBGM; // ゲームオーバーのBGM
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM(normalBGM, true); // 最初に通常のBGMをループ再生
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
        PlayBGM(normalBGM, true); // 通常のBGMをループ再生
    }

    public void PlayGameClearBGM()
    {
        PlayBGM(gameClearBGM, false); // ゲームクリアのBGMをループ再生しない
    }

    public void PlayGameOverBGM()
    {
        PlayBGM(gameOverBGM, true); // ゲームオーバーのBGMをループ再生
    }
}
