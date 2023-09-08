using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneStartDelay : MonoBehaviour
{
    [SerializeField][Header("DelayTime")]
    private float delay = 3f;
    //開始時のwaittime
    [HideInInspector]
    public bool IsDelay = false;

    private async void Awake()
    {
        var token = this.GetCancellationTokenOnDestroy();
        await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: token);
        IsDelay = true;
        Debug.Log(IsDelay);
    }


    
}
