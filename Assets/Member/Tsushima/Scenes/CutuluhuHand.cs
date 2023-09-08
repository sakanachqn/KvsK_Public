using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutuluhuHand : MonoBehaviour
{
    private WaitForSeconds AIntWait;
    private WaitForSeconds SpWait;
    private WaitForSeconds WayWait;
    private WaitForSeconds LazerWait;
    private GameObject player;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private GameObject lightningR;
    [SerializeField]
    private GameObject lightningP;
    [SerializeField]
    private GameObject lazerObj;
    [SerializeField]
    private GameObject hnd;
    [SerializeField]
    private List<GameObject> pos = new List<GameObject>();
    
    [SerializeField]
    private List<int> MaxBulletCount = new List<int>();
    private List<int> BulletCount = new List<int>();

    public enum NTable
    {
        Sp,
        Way,
        B140,
        LightRp,
        LightPw,
        Lz
    }

    public void InitNTable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.PlayerGameObject;

        AIntWait = new WaitForSeconds(3f);  // 攻撃wait時間

        SpWait = new WaitForSeconds(1/8);
        WayWait = new WaitForSeconds(1/4);
        LazerWait = new WaitForSeconds(7f);
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        while(true)
        {
            yield return AIntWait;

        }
    }

    IEnumerator BulletSpred()
    {
        while(true)
        {
            if (BulletCount[0] < MaxBulletCount[0])
            {
                yield return SpWait;
                BulletCount[0]++;
                Quaternion direction = Quaternion.identity;
                Vector3 anglefoword = Vector3.zero;
                var vectUp = new Vector3(0, 0.05f, 0);
                if (player != null) 
                {
                    //プレイヤーに飛んでいく弾の向きの処理
                    anglefoword = (player.transform.position - this.transform.position).normalized;
                    direction = Quaternion.LookRotation(anglefoword + vectUp, Vector3.up);
                }
                //プレイヤーの球を基準に角度とランダムの処理をつける
                var direction2 = Quaternion.AngleAxis(UnityEngine.Random.Range(-9.0f,9.0f), Vector3.up) * direction;
                Instantiate(Bullet, transform.position, direction2);
                yield return null;
            }
            else
            {
                BulletCount[1] = 0;
                yield break;
            }
        }

    }

    IEnumerator Bullet3Way()
    {
        while(true)
        {
            if (BulletCount[1] < MaxBulletCount[1])
            {
                yield return WayWait;
                BulletCount[1]++;
                Quaternion direction = Quaternion.identity;
                Vector3 anglefoword = Vector3.zero;

                var vectUp = new Vector3(0, 0.05f, 0);
                if (player != null)
                {
                //プレイヤーに飛んでいく弾の向きの処理
                    anglefoword = (player.transform.position - this.transform.position).normalized;
                    direction = Quaternion.LookRotation(anglefoword + vectUp, Vector3.up);
                }
                //プレイヤーの球を基準に角度をつける処理
                var direction2 = Quaternion.AngleAxis(30, Vector3.up) * direction;
                var direction3 = Quaternion.AngleAxis(-30, Vector3.up) * direction;
                Instantiate(Bullet, transform.position, direction);
                Instantiate(Bullet, transform.position, direction2);
                Instantiate(Bullet, transform.position, direction3);
                yield return null;
            }
            else
            {
                BulletCount[1] = 0;
                yield break;
            }
        }
    }
    IEnumerator Bullet140()
    {
        Quaternion direction = Quaternion.identity;
        Vector3 anglefoword = Vector3.zero;
        var vectUp = new Vector3(0, 0.05f, 0);
        if (player != null)
        {
            //プレイヤーに飛んでいく弾の向きの処理
            anglefoword = (player.transform.position - this.transform.position).normalized;
            direction = Quaternion.LookRotation(anglefoword + vectUp, Vector3.up);
        }
        Instantiate(Bullet, transform.position, direction);
        int j = 60;
        for(int i = 0; i < MaxBulletCount[2]; i++)
        {
            var direction2 = Quaternion.AngleAxis(j, Vector3.up) * direction;
            Instantiate(Bullet, transform.position, direction2);
            j -= 10;
        }
        yield return null;
    }

    IEnumerator LightningRp()
    {
        while(true)
        {
            if (BulletCount[2] < MaxBulletCount[3])
            {
                BulletCount[2]++;
                Instantiate(lightningR, new Vector3(player.transform.position.x + 2f,player.transform.position.y,player.transform.position.z + 2f), Quaternion.Euler(0f,Random.Range(0.0f,360.1f),0f));
            }
            else
            {
                BulletCount[2] = 0;
                yield break;
            }
        }
    }

    IEnumerator LightningPw()
    {
        Instantiate(lightningP, pos[0].transform.position, Quaternion.identity);
        yield break;
    }
    IEnumerator Lazer()
    {
        var obj = Instantiate(lazerObj, hnd.transform.position, Quaternion.identity);
        while(true)
        {
            int i = Random.Range(1,5);
            if(i != BulletCount[3])
            {
                obj.transform.LookAt(pos[i].transform, Vector3.up);
                BulletCount[3] = i;
                yield return LazerWait;
                Destroy(obj);
                yield break;
            }
        }
    }
}
