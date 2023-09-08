using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//クトゥルフからplayerまでを飛んでいくレーザーを創るやつ

public class Rightlaserbeam : MonoBehaviour
{
    
    //レーザーの発射点
    [SerializeField]
    private GameObject head;
    //レーザーの終着点
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject right;
    [SerializeField]
    private GameObject left;
    //レーザー本体
    [SerializeField]
    private GameObject plain;
    //playerを獲得する
    private Vector3 lastPlayersPoint;
    public void Doer(Vector3 start ,Vector3 end)
    {
      
            //レーザーの中心点を獲得する
            plain.transform.position = (end + start) / 2.0f;
            //レーザーの方向を調整する
            plain.transform.rotation = Quaternion.LookRotation(end - start, Vector3.up);
            //レーザーの中心点から引き延ばす
            plain.transform.localScale = new Vector3(0.1f, 0.1f, (end - start).magnitude);
            //playerの移動を保存する
            lastPlayersPoint = right.transform.position;

             Destroy(plain, 5);


    }
    
    void Start()
    {

        //レーザーの発射点からレーザーの終着点に向かう
        Doer(head.transform.position, right.transform.position - Vector3.up*0.5f);
        
    }

    private void Update()
    {
        if (plain == null)
        {

            return;
        }

        //保存したplayerの座標に追従する
        Doer(head.transform.position, left.transform.position * 0.01f + lastPlayersPoint * 0.99f);
    }
        

}
    



