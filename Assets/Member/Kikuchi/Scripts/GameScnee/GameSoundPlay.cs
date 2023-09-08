using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSoundPlay : MonoBehaviour
{

    [SerializeField]
    [Header("カウントダウン開始までの待機時間(ミリ秒)")]
    private float waitTime = 0;

    private int CountDownTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        GameStartSound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void GameStartSound()
    {
        GameManager.GameManagerClass.soundManager.BGMsource.Stop();
        await UniTask.Delay(TimeSpan.FromMilliseconds(waitTime));
        //GameManager.GameManagerClass.soundManager.Play("SE1");
        await UniTask.Delay(TimeSpan.FromSeconds(CountDownTime));
        GameManager.GameManagerClass.IsEndCountDown = true;
        //GameManager.GameManagerClass.soundManager.Play("SE2");
        GameManager.GameManagerClass.soundManager.ChangeBGM("BGM3");
    }
}
