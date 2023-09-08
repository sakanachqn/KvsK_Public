using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SabaBullet : StateMachineBehaviour
{

    public Transform player;
    bool attackable = true;

    public Text text_2;

    private static int bullets; 
    void Start()
    {
        bullets = SabaStats.SabaMaxBullet;
    }

    public void TextUpdt()
    {
        text_2.text = bullets.ToString();
    }
/*
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsTag("Attackable"))
        {
            attackable = true;
        }
    }
    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        text_2.text = bullets + "";

        if (Input.GetMouseButton(0) && attackable && bullets > 0)
        {
            animator.SetTrigger("Attack");
            attackable = false;
            if (animator.GetInteger("Weapon") == 5)
            {
                var b = Instantiate(bullet, player.position + player.forward, player.rotation); 
                Rigidbody r = b.GetComponent<Rigidbody>();
                r.AddForce(Vector3.Lerp(player.forward, player.up, 0.02f) * 38f, ForceMode.Impulse); 

                bullets--;

                // 弾が0以下のとき
                if (bullets <= 0)
                {
                    animator.SetBool("NoAmo", true);

                }
            }
        }

        // リロードする
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullets = 20;
            animator.SetBool("NoAmo", false);

        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 攻撃可能なステートを出たら攻撃不可能にする
        if (stateInfo.IsTag("Attackable"))
        {
            attackable = false;
        }
    }
 */
}