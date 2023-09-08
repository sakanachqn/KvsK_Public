using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Rasermove : MonoBehaviour
{
    private GameObject player;
    public int move = 0;
    [SerializeField]
    [Tooltip("対象物(向く方向)")]
    private GameObject target;
    


    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
    }
  

    // Update is called once per frame
    void Update()
    {
        if (move >= 1)
        {
            // 対象物と自分自身の座標からベクトルを算出
            // Vector3 vector3 = target.transform.position - this.transform.position;


            // Quaternion(回転値)を取得
            //  Quaternion quaternion = Quaternion.LookRotation(vector3);
            // 算出した回転値をこのゲームオブジェクトのrotationに代入
            /// this.transform.rotation = quaternion;
            //プレイヤーの方向
            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

            lookRotation.z = 0;
            lookRotation.x = 0;

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
            //移動速度
            Vector3 p = new Vector3(0f, 0f, 0.1f);

            transform.Translate(p);
            Destroy(this.gameObject,5);
           


        }
       
    }

    private void  OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            move +=1;
        }
    }
}