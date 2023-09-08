using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Cysharp.Threading.Tasks;

public class Intaluct : MonoBehaviour
{
    [SerializeField]
    private GameObject intaluctUI;
    [SerializeField]
    private Transform target;
    private bool flag;
    private IEnumerator kazikiFind;

    [SerializeField]
    private int Num;

    [SerializeField]
    private Kaziki kaziki;
    [SerializeField]
    private TsuriPResp tsuriPResp;

    private string sceneName = null;

    [SerializeField]
    private float RepopTime = 20f;

    

    private void Start()
    {
        kazikiFind = KazikiFind();
        sceneName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if(flag)
            intaluctUI.transform.position = Camera.main.WorldToScreenPoint(new Vector3(target.position.x,target.position.y,target.position.z + 2f));
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(KazikiStats.KazikiNowBullet >= 1) return;
            intaluctUI.SetActive(true);
            flag = true;
            Debug.Log("弾薬数" + KazikiStats.KazikiMaxBullet);
            StartCoroutine(kazikiFind);
            Debug.Log("takoyaki");
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            intaluctUI.SetActive(false);
            flag = false;
            Debug.Log("弾薬数" + KazikiStats.KazikiMaxBullet);
            StopCoroutine(kazikiFind);
            kazikiFind = null;
            kazikiFind = KazikiFind();
        }

    }

    private IEnumerator KazikiFind()
    {
        if (KazikiStats.KazikiNowBullet >= 1)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            GameManager.GameManagerClass.soundManager.Play("KazikiFull");
            intaluctUI.SetActive(false);
            flag = false;
            yield break;
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        GameManager.GameManagerClass.soundManager.Play("GetKaziki");
        KazikiStats.KazikiNowBullet ++;
        kaziki.KazikiLight();
        UIManager.uiManager.KazikiUpdate();
        this.gameObject.SetActive(false);
        intaluctUI.SetActive(false);
        flag = false;
        if(sceneName == "CutuluhuScene") RePop();
        
    }

    private async void RePop()
    {
        var token = this.GetCancellationTokenOnDestroy();
        await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken: token);
        this.gameObject.SetActive(true);
    }
}
