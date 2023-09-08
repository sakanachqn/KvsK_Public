using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologButtonGeneration : MonoBehaviour
{
    //生成用ボタン取得用
    [SerializeField]
    private GameObject prologButton;
    //ボタン生成ディレイタイム設定用変数
    [SerializeField]
    private float createTime = 1f;
    //経過時間計測用変数
    private float elapsedTime = 0;
    //ボタン生成フラグ
    private bool isButtonCreate = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isButtonCreate) elapsedTime += Time.deltaTime;
        if (elapsedTime > createTime)
        {
            Instantiate(prologButton, this.transform);
            isButtonCreate = true;
            elapsedTime = 0;
        }

    }
}
