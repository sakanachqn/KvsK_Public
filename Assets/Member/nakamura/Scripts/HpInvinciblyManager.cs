using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpInvinciblyManager : MonoBehaviour
{
    [SerializeField]
    private int playerHp;//プレイヤーのHP
    public static int PlayerHp;//プレイヤーのHP

    [SerializeField]
    private GameObject player;
    public static GameObject Player;

    [SerializeField]
    public static float InvincibleTime;//無敵時間
    public static bool IsInvincible;//無敵かじゃないか
    private float comparisonTime = 0;//比較時間

    public static bool IsDeceleration;//減速しているかしていないか

    public static bool EnemyAt;//敵から攻撃を受けたか

    private bool changeScene = false;

    [SerializeField]
    private List<Material> material = new List<Material>();
    private static bool hitFlag;
    private float alpha;
    private bool sw;

    public void OnEnable()
    {
        InvincibleTime = 1.5f;
        alpha = 0f;
        ShaderSet();
        IsInvincible = false;
        IsDeceleration = false;
        PlayerHp = playerHp;
        Player = player;
        EnemyAt = false;
        //AlphaTestUI.PlayerTextUpdate();
    }

    //下の関数に変更(後で消す)
    public static void PlayerHpInvincibly()
    {
        IsInvincible = true;//無敵
        IsDeceleration = true;//減速

        PlayerHp--;//HP減少
        EnemyAt = true;
        //Debug.Log(PlayerHp);
        //AlphaTestUI.PlayerTextUpdate();
    }

    //ダメージを受けたら、無敵と減速を始める、コルーチン
    public static IEnumerator Invincible()
    {
        if(CthulhuManager.IsDead)yield break;
        if (!IsInvincible)
        {
            hitFlag = true;
            PlayerHp--;//HP減少
            IsInvincible = true;//無敵になる
            Debug.Log(PlayerHp);
            UIManager.uiManager.PlayerHpUpdate();
            IsDeceleration = true;//減速
             //this.GetComponent<Collider>().isTrigger = true;
            //yield return new WaitForSeconds(InvincibleTime);//無敵時間待つ
            // IsInvincible = false;//無敵終了
            // IsDeceleration = false;
             //this.GetComponent<Collider>().isTrigger = false;
            yield return null;
        }
    }

    private void Update()
    {

        if(IsInvincible)
        {
            if(hitFlag)
                ShaderSet();
            comparisonTime += Time.deltaTime;


            if(comparisonTime >= InvincibleTime)
            {
                IsDeceleration = false;
                IsInvincible = false;
                comparisonTime = 0.0f;
                
            }
        }
        if(sw && IsInvincible)
        {
            alpha += Time.deltaTime * 2.5f;
            if(alpha >= 0f)
            {
                alpha = 0f;
                sw = false;
            }
            AlphaSet();
        }
        else if(!sw && IsInvincible)
        {
            alpha -= Time.deltaTime * 2.5f;
            if(alpha <= -1f)
            {
                alpha = -1f;
                sw = true;
            }
            AlphaSet();
        }
        else if(!IsInvincible && alpha != 0)
        {
            alpha += Time.deltaTime * 2.5f;
            if(alpha >= 0f)
            {
                alpha = 0f;
                sw = false;
            }
            AlphaSet();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerHp = 0;
            Debug.Log("Debug:Dead");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameManager.GameManagerClass.sceneController.ChangeScene(SceneController.SceneType.toCutuluhu);
            GameManager.GameManagerClass.soundManager.BGMsource.Stop();
            Debug.Log("Debug:Clear");
        }
#endif

        if(PlayerHp <= 0 && changeScene == false)
        {
            changeScene = true;
            GameManager.GameManagerClass.sceneController.ChangeScene(SceneController.SceneType.toGameOver);
            GameManager.GameManagerClass.soundManager.BGMsource.Stop();
        }
    }

    private void ShaderSet()
    {
        if(hitFlag)
        {
            for(int i = 0; i < material.Count;i++)
            {
                material[i].SetInt("_TransparentEnabled", 1);
                material[i].SetInt("_ClippingMode", 2);
                material[i].SetFloat("_Tweak_transparency", alpha);
            }
            /*
            material[1].SetInt("_TransparentEnabled", 1);
            material[2].SetInt("_TransparentEnabled", 1);
            material[1].SetInt("_ClippingMode", 2);
            material[2].SetInt("_ClippingMode", 2);
            material[1].SetFloat("_Tweak_transparency", alpha);
            material[2].SetFloat("_Tweak_transparency", alpha);
            */
            hitFlag = false;
        }
        else
        {
            for(int i = 0; i < material.Count;i++)
            {
                material[i].SetInt("_TransparentEnabled", 0);
                material[i].SetInt("_ClippingMode", 0);
                material[i].SetFloat("_Tweak_transparency", alpha);
            }
/*
            material[0].SetInt("_TransparentEnabled", 0);
            material[1].SetInt("_TransparentEnabled", 0);
            material[2].SetInt("_TransparentEnabled", 0);
            material[0].SetInt("_ClippingMode", 0);
            material[1].SetInt("_ClippingMode", 0);
            material[2].SetInt("_ClippingMode", 0);
            material[0].SetFloat("_Tweak_transparency", alpha);
            material[1].SetFloat("_Tweak_transparency", alpha);
            material[2].SetFloat("_Tweak_transparency", alpha);
*/
        }

    }
    void AlphaSet()
    {
        for(int i = 0; i < material.Count;i++)
        {
            material[i].SetFloat("_Tweak_transparency", alpha);
        }
    }
}
