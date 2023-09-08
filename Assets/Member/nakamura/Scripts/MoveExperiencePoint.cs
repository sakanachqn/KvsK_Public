using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveExperiencePoint : MonoBehaviour
{
    [SerializeField]
    private int _expRange;//取得範囲

    public int Score;//スコア

    void Update()
    {
        //プレイヤーと敵の位置を把握する      
        //var posPlayer = GameObject.Find("Fisher").transform.localPosition;
        var posEnemy = this.transform.localPosition;

        //距離　＝　プレイヤー　ー　経験値オブジェクト
        float dis = (PlayerController.PlayerGameObject.transform.position - posEnemy).sqrMagnitude;
        if (dis <= _expRange)
        { 
            //経験値を加算
            Score++;
            UIManager.uiManager.ScoreUpdate();
            //オブジェクトがプレイヤーの取得範囲以内になったら、オブジェクトを削除
            Destroy(this.gameObject);
        }
    }
}
