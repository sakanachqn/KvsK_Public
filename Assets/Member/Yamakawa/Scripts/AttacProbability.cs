using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacProbability : MonoBehaviour
{
    /////////////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField, Header("クトゥルフ本体の場合つける")]
    private bool Cthulhu = false;

    //[SerializeField, Header("攻撃頻度の設定0 ~ 100%まで")]
    private int runtime = 50;

    //[SerializeField, Header("攻撃のディレイタイム")]
    private int attackdelay = 1;

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

    //[SerializeField]
    //private lasercontroller Lasercontroller;

    [SerializeField]
    private SceneStartDelay CSD;

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
        if (!CSD.IsDelay || CthulhuManager.IsDead || CthulhuManager.StanFlag) return;


        timer += Time.deltaTime;

        if (timer > attackdelay)
        {
            attackrnd = Random.Range(1, 100);

            timer = 0;
        }


        if (attackrnd > runtime)
        {
            attackprobability = Random.Range(1, 100);
            if (Cthulhu == true)
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

                else if (31 < attackprobability && attackprobability < 50)
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
                else if (51 < attackprobability && attackprobability < 80)
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
                else if(81 < attackprobability && attackprobability < 100)
                {
                    //if (attackpattern == Attackpattern.laser)
                    //{
                        attackprobability = Random.Range(1, 100);
                    //}
                    //else
                    //{
                    //    attackpattern = Attackpattern.laser;

                    //    Lasercontroller.Dolaser();
                    //    attackrnd = 0;
                    //}
                }
            }
            else
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
                else if (71 < attackprobability && attackprobability < 100)
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

/*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(timer);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(attackrnd);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(attackprobability);
        }
*/
    }
}
