using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePointController : MonoBehaviour
{
    private static ExperiencePointController expPointControllerInstance;

    public static ExperiencePointController ExpPointControllerInstance
    {
        get
        {
            if (expPointControllerInstance == null)
            {
                expPointControllerInstance
                    = FindObjectOfType<ExperiencePointController>();
            }
            return expPointControllerInstance;
        }
    }

    [SerializeField]
    private GameObject experiencePointObj;

    public bool EnemyDead = false;

    public int Combo;//敵を連続で倒した数

    private int drop = 0;

    void Update()
    {
        //敵から攻撃を受けたら、コンボを0にする
        if (HpInvinciblyManager.EnemyAt)
        {
            Combo = 0;
            HpInvinciblyManager.EnemyAt = false;
        }

        //敵が死んだか判断する
        // if (EnemyDead)
        // {
        //     Combo++;//コンボを加算
        //     ExpDrops();       
        //     EnemyDead = false;
        // }        
    }

    void SpawnExperiencePoint(int drops, Vector3 vec)
    {
        //ドロップ数分を回す
        for(int i = 0;i < drops;i++)
        {
            //死んだ敵の位置に生成する
            // Instantiate(experiencePointObj, new Vector3(this.transform.position.x
            //                                             , this.transform.position.y 
            //                                             , this.transform.position.z)
            //                                             , Quaternion.identity);
            Instantiate(experiencePointObj, vec,Quaternion.identity);

        }
    }

    void ExpDrops(Vector3 vec)
    {
        Debug.Log("ExpDrops");
        //コンボが10より下なら
        if (Combo < 10)
        {
            drop = 1;
        }
        else
        {
            //ここから二桁になる
            string strCombo = Combo.ToString();
            int combo = int.Parse(strCombo[0].ToString());

            //先頭の数字分ドロップ数が増える
            for (int i = 0;i < combo;i++)
            {
                drop++;
            }
        }

        //経験値オブジェクトをスポーンする
        SpawnExperiencePoint(drop,vec);

        drop = 1;//戻す
    }

    public void SetEnemyDead(Vector3 vec)
    {
        Combo++;//コンボを加算
        ExpDrops(vec);       
        EnemyDead = false;

//        EnemyDead = enemyDead;
    }
}
