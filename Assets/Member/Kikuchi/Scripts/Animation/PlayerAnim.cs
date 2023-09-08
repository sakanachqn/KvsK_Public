using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    /// <summary>
    /// Playerの移動方角設定用
    /// </summary>
    public enum MoveDirection
    {
        Forward,
        Back,
        Left,
        Right
    }

    private Animator animator;  //アニメーター格納用

    private Vector3 currentPos; //現在座標格納用

    private Transform player;

    public bool IsNowThrowAnim = false; //カジキを投げているかどうかのフラグ

    private GameObject Gun; //銃のオブジェクト

    [SerializeField]
    [Header("カジキを投げるまでの時間")]
    private float throwTime = 0;


    private void Awake()
    {
        //アニメーターをセット
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if(player == null)
        {
            player = GetComponent<Transform>();
        }
        if(Gun == null)
        {
            Gun = this.transform.Find("fisher/Md_Launcher_Md_Launcher").gameObject;
        }
    }

    /// <summary>
    /// 移動アニメーションのbool値をセット
    /// </summary>
    /// <param name="md">方角</param>
    /// <param name="nowMove">移動しているかどうか</param>
    private void MoveDirecAnim(MoveDirection md, bool nowMove = false)
    {
        switch (md)
        {
            case MoveDirection.Forward: animator.SetBool("isMoveF", nowMove); break;
            case MoveDirection.Back: animator.SetBool("isMoveB", nowMove); break;
            case MoveDirection.Left: animator.SetBool("isMoveL", nowMove); break;
            case MoveDirection.Right: animator.SetBool("isMoveR", nowMove); break;

        }

    }


    /// <summary>
    /// 死亡アニメーションのTriggerをセット
    /// </summary>
    public void DeadAnim()
    {
        animator.SetTrigger("isDead");
    }

    /// <summary>
    /// カジキ投擲時のアニメーションのTriggerをセット
    /// </summary>
    public void KazikiAnim()
    {
        animator.SetTrigger("isKaziki");
    }

    public  void AnimRes()
    {
        animator.SetTrigger("isIdle");
        animator.SetBool("isMoveF", false);
        animator.SetBool("isMoveB", false);
        animator.SetBool("isMoveL", false);
        animator.SetBool("isMoveR", false);
    }

    public void DisableGun()
    {
        Gun.SetActive(false);
    }

    public void EnableGun()
    {
        Gun.SetActive(true);
    }

    /// <summary>
    /// 移動アニメーション処理
    /// </summary>
    /// <param name="latestPos"></param>
    public void PosAnimCheck(Vector3 latestPos)
    {
        currentPos = transform.position; //移動後の座標

        var pos = currentPos - latestPos;　//直前の位置と比較してどこに動いたかを格納

        var forward = transform.forward; //正面方向を取得

        var num = 1 / Mathf.Sqrt(2); //ルート2/1を用意

        //sin/cosの45度を用意
        var sin = Mathf.Sin(num);
        var cos = Mathf.Cos(num);

        //各方向の45度ずつで正面を変更
        #region 移動アニメーション処理

        //右向き
        if (forward.x >= cos && forward.z < sin && forward.z >= -sin)
        {
            if (pos.x > 0) MoveDirecAnim(MoveDirection.Forward, true);
            else MoveDirecAnim(MoveDirection.Forward);

            if(pos.x < 0) MoveDirecAnim(MoveDirection.Back, true);
            else MoveDirecAnim(MoveDirection.Back);

            if(pos.z > 0) MoveDirecAnim(MoveDirection.Left, true);
            else MoveDirecAnim(MoveDirection.Left);

            if(pos.z < 0) MoveDirecAnim(MoveDirection.Right, true);
            else MoveDirecAnim(MoveDirection.Right);
        }
        //左向き
        if(forward.x <= -cos && forward.z < sin && forward.z >= -sin)
        {
            if (pos.x < 0) MoveDirecAnim(MoveDirection.Forward, true);
            else MoveDirecAnim(MoveDirection.Forward);

            if (pos.x > 0) MoveDirecAnim(MoveDirection.Back, true);
            else MoveDirecAnim(MoveDirection.Back);

            if (pos.z < 0) MoveDirecAnim(MoveDirection.Left, true);
            else MoveDirecAnim(MoveDirection.Left);

            if (pos.z > 0) MoveDirecAnim(MoveDirection.Right, true);
            else MoveDirecAnim(MoveDirection.Right);
        }
        //下向き
        if (forward.z >= sin && forward.x < cos && forward.x >= -cos)
        {
            if (pos.z > 0) MoveDirecAnim(MoveDirection.Forward, true);
            else MoveDirecAnim(MoveDirection.Forward);

            if (pos.z < 0) MoveDirecAnim(MoveDirection.Back, true);
            else MoveDirecAnim(MoveDirection.Back);

            if (pos.x < 0) MoveDirecAnim(MoveDirection.Left, true);
            else MoveDirecAnim(MoveDirection.Left);

            if (pos.x > 0) MoveDirecAnim(MoveDirection.Right, true);
            else MoveDirecAnim(MoveDirection.Right);
        }
        //上向き
        if (forward.z <= -sin && forward.x < cos && forward.x >= -cos)
        {
            if (pos.z < 0) MoveDirecAnim(MoveDirection.Forward, true);
            else MoveDirecAnim(MoveDirection.Forward);

            if (pos.z > 0) MoveDirecAnim(MoveDirection.Back, true);
            else MoveDirecAnim(MoveDirection.Back);

            if (pos.x > 0) MoveDirecAnim(MoveDirection.Left, true);
            else MoveDirecAnim(MoveDirection.Left);

            if (pos.x < 0) MoveDirecAnim(MoveDirection.Right, true);
            else MoveDirecAnim(MoveDirection.Right);
        }
        #endregion

    }


}
