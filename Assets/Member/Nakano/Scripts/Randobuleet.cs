using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Randobuleet : MonoBehaviour
{
    //ランダム弾の処理
    public GameObject Prefab;
    float intervalTime;
    int bulletcount = 0;
    int maxbullet = 0;
    private GameObject player;
    

    void Start()
    {
        intervalTime = 0;
        player = GameObject.FindWithTag("Player");

        // test呼び　外部から、このメソッドをたたけば、弾が出ます
        //Dobullet2();
    }


    void Update()
    {

        if(CthulhuManager.StanFlag) return;
        intervalTime += Time.deltaTime;
        if (intervalTime >= 1f)
        {
            if (bulletcount < maxbullet)
            {
               bulletcount++;
               Quaternion direction = Quaternion.identity;
               Vector3 anglefoword = Vector3.zero;
                var vectUp = new Vector3(0, 0.05f, 0);
                if (player != null) 
               {
                    //プレイヤーに飛んでいく弾の向きの処理
                    anglefoword = (player.transform.position - this.transform.position).normalized;
                    direction = Quaternion.LookRotation(anglefoword + vectUp, Vector3.up);
               }
               intervalTime = 0f;
                //プレイヤーの球を基準に角度とランダムの処理をつける
               var direction2 = Quaternion.AngleAxis(UnityEngine.Random.Range(-9.0f,9.0f), Vector3.up) * direction;
               Instantiate(Prefab, transform.position, direction2);
            }
            return;
        }

    }

    public void Dobullet2(int maxbullet = 8)
    {
        this.bulletcount = 0;
        this.maxbullet = maxbullet;
    }

}