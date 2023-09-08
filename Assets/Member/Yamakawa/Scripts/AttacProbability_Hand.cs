using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacProbability_Hand : MonoBehaviour
{
    /////////////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField, Header("クトゥルフ本体の場合つける")]
    private bool Cthulhu = false;

    [SerializeField, Header("攻撃頻度の設定0 ~ 100%まで")]
    private int runtime = 15;

    [SerializeField, Header("攻撃のディレイタイム")]
    private int attackdelay = 5;

    private float timer = 0;

    private int attackrnd = 0;

    private int attackprobability = 0;

    Attackpattern attackpattern;

    [SerializeField]
    private Randobuleet randobuleet;

    [SerializeField]
    private waycontroller controller;

    [SerializeField]
    private allrange all;

    enum Attackpattern
    {
        nulll,

        threeway,

        laser,

        allrange,

        random
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////

    private void Start()
    {
        attackpattern = Attackpattern.nulll;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > attackdelay)
        {
            attackrnd = Random.Range(1, 100);

            timer = 0;
        }


        if (attackrnd < runtime)
        {
            if (1 < attackprobability && attackprobability < 30)
            {
                if (attackpattern == Attackpattern.random)
                {
                    attackprobability = Random.Range(1, 100);
                }
                else
                {
                    attackpattern = Attackpattern.random;
                    randobuleet.Dobullet2();
                    attackrnd = 0;
                }
            }
            else if (31 < attackprobability && attackprobability < 70)
            {
                if (attackpattern == Attackpattern.threeway)
                {
                    attackprobability = Random.Range(1, 100);
                }
                else
                {
                    attackpattern = Attackpattern.threeway;
                    controller.Dobullet();
                    attackrnd = 0;
                }
            }
            else
            {
                if (attackpattern == Attackpattern.allrange)
                {
                    attackprobability = Random.Range(1, 100);
                }
                else
                {
                    attackpattern = Attackpattern.allrange;
                    all.Dobullet3();
                    attackrnd = 0;
                }
            }
        }
    }
}
