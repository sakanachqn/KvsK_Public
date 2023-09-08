using UnityEngine;



public class allrange : MonoBehaviour
{
    //オールレンジ弾の処理
    public GameObject Prefab;
    float intervalTime;
    int bulletcount = 0;
    int maxbullet = 0;
    private GameObject player;

    [SerializeField]
    private int angleValue = 14;


    void Start()
    {
        intervalTime = 0;
        player = GameObject.FindWithTag("Player");

        // test呼び　外部から、このメソッドをたたけば、弾が出ます
        //Dobullet3();
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
                intervalTime = 0f;
                //プレイヤーの球を基準に角度をつける処理
                //for (int i = 0; i < angleValue; i++)
                //{
                //    //基準値 中心点から-65度 これは140度を14回分割した結果です
                //    int dic = 0;
                //    if(angleValue % 2 == 0)
                //    {
                //        dic = -angleValue / 2 * 10 - 5;
                //    }
                //    else
                //    {
                //        dic = -angleValue / 2 * 10;
                //    }
                //    var _direction = Quaternion.AngleAxis(dic, Vector3.up) * direction;
                //    Instantiate(Prefab, transform.position, Quaternion.AngleAxis(i * 10, Vector3.up)* _direction );
                //}


                var direction2 = Quaternion.AngleAxis(60, Vector3.up) * direction;
                var direction3 = Quaternion.AngleAxis(50, Vector3.up) * direction;
                var direction4 = Quaternion.AngleAxis(40, Vector3.up) * direction;
                var direction5 = Quaternion.AngleAxis(30, Vector3.up) * direction;
                var direction6 = Quaternion.AngleAxis(20, Vector3.up) * direction;
                var direction7 = Quaternion.AngleAxis(10, Vector3.up) * direction;
                var direction8 = Quaternion.AngleAxis(-70, Vector3.up) * direction;
                var direction9 = Quaternion.AngleAxis(-60, Vector3.up) * direction;
                var direction10 = Quaternion.AngleAxis(-50, Vector3.up) * direction;
                var direction11 = Quaternion.AngleAxis(-40, Vector3.up) * direction;
                var direction12 = Quaternion.AngleAxis(-30, Vector3.up) * direction;
                var direction13 = Quaternion.AngleAxis(-20, Vector3.up) * direction;
                var direction14 = Quaternion.AngleAxis(-10, Vector3.up) * direction;
                Instantiate(Prefab, transform.position, direction);
                Instantiate(Prefab, transform.position, direction2);
                Instantiate(Prefab, transform.position, direction3);
                Instantiate(Prefab, transform.position, direction4);
                Instantiate(Prefab, transform.position, direction5);
                Instantiate(Prefab, transform.position, direction6);
                Instantiate(Prefab, transform.position, direction7);
                Instantiate(Prefab, transform.position, direction8);
                Instantiate(Prefab, transform.position, direction9);
                Instantiate(Prefab, transform.position, direction10);
                Instantiate(Prefab, transform.position, direction11);
                Instantiate(Prefab, transform.position, direction12);
                Instantiate(Prefab, transform.position, direction13);
                Instantiate(Prefab, transform.position, direction14);
            }
            return;
        }
    }
    //球を打つたびにカウントして一定回数をカウントする処理
    public void Dobullet3(int maxbullet = 1)
    {
        this.bulletcount = 0;
        this.maxbullet = maxbullet;
    }
}
