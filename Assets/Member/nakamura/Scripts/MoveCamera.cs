using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget;//カメラが追従するもの
    private Vector3 offset;//距離の取得用

    void Start()
    {
        //開始時点のカメラとターゲットの距離の取得
        offset = gameObject.transform.position - followTarget.transform.position;
    }

    //プレイヤーが移動した後にカメラが移動するようにLateUpdateとする
    void LateUpdate()
    {
        //カメラの位置をターゲットの位置にオフセットを足した場所にする
        gameObject.transform.position = followTarget.transform.position + offset;
    }
}
