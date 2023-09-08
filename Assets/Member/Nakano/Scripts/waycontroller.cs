using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class waycontroller : MonoBehaviour
{
    //3wei弾の処理
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
        //Dobullet();
    }


    void Update()
    {

            intervalTime += Time.deltaTime;
            if (intervalTime >= 0.25f)
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
                    intervalTime -= 0.25f;
                    //プレイヤーの球を基準に角度をつける処理
              　     var direction2 = Quaternion.AngleAxis(30, Vector3.up) * direction;
                    var direction3 = Quaternion.AngleAxis(-30, Vector3.up) * direction;
                  　 Instantiate(Prefab, transform.position, direction);
                   　Instantiate(Prefab, transform.position, direction2);
                   　Instantiate(Prefab, transform.position, direction3);
            }
                return;
        }
            
        
     
    }

    //球を打つたびにカウントして一定回数をカウントする処理
    public void Dobullet(int maxbullet = 1)
    {
        this.bulletcount = 0;
        this.maxbullet = maxbullet;
    }

}