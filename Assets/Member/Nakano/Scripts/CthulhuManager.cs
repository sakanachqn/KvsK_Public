using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CthulhuManager : MonoBehaviour
{
    public static CthulhuManager cthulhuManager;
    //�N�g�D���t��HP�ݒ�Ȃǂ̊Ǘ�����}�l�[�W���[
    public float maxHealth = 10000;
    public float health;
    public float maxStan;
    public float Stan;
    public Slider stanSlider;

    public static bool StanFlag;
    [SerializeField]
    public HpSlider hpSlider;

    public static bool IsDead = false;
    private bool isClear = false;

    [SerializeField]
    private PlayerAnim pa;

    [SerializeField]
    private float timeDelay = 3f;
    


    void Start()
    {
        cthulhuManager = this.gameObject.GetComponent<CthulhuManager>();
        health = maxHealth;
        hpSlider._slider.maxValue = maxHealth;
        hpSlider._slider.value = health;
        stanSlider.maxValue = maxStan;
        stanSlider.value = 0;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            StanStack(400);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            health *= 0.5f;
            hpSlider._slider.value = health;
            hpSlider.HpDown(health);
        }

        if(health <= 0 && !isClear)
        {
            isClear = true;
            KillDelay();

        }
        //if (health < 0 && desflag == true)
        //{
            
           // desflag = false;
          //  Debug.Log("���񂾂�");
            //���񂾂Ƃ��̃C�x���g����Ƃ���(*�L�ցM*)
        //}
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.K))
        {
            //health = 0;
            //Debug.Log("Dbug:CutuluDead");
        }
#endif
    }

    //pl動作停止
    //plHP減少停止
    //coc攻撃停止
    //フラッシュ->UI除去->coc死亡anim

    public void CutuluhuUpdate(GameObject obj)
    {        
        if (obj.CompareTag("Mackrel"))
        {
            health -= 10;
            StanStack(1);
            UIManager.uiManager.CutuluhuScore(UnityEngine.Random.Range(1,6));
            Destroy(obj.gameObject);
            Debug.Log("hit");
        }
        else if (obj.CompareTag("SwordFish"))
        {
            health -= 1000;
            StanStack(300);
            UIManager.uiManager.CutuluhuScore(100);
            Destroy(obj.gameObject);
            Debug.Log("hit");
        }
        hpSlider.HpDown(health);
    }

    public void StanStack(float f)
    {
        Stan += f;
        stanSlider.value = Stan;
        if(Stan >= maxStan)
        {
            StanFlag = true;
            StartCoroutine(StanTimer());
        }
    }

    IEnumerator StanTimer()
    {
        yield return new WaitForSeconds(10f);
        Stan = 0f;
        StanFlag = false;
        stanSlider.value = Stan;
    }
    
    private async void KillDelay()
    {
        var token = this.GetCancellationTokenOnDestroy();

        IsDead = true;
        GameManager.GameManagerClass.soundManager.BGMsource.Stop();
        GameManager.GameManagerClass.soundManager.Play("SEWIN");
        pa.AnimRes();
        await UniTask.Delay(TimeSpan.FromSeconds(timeDelay), cancellationToken: token);
        GameManager.GameManagerClass.TransitionToResultScene();
        
    }
    private void OnDestroy()
    {
        IsDead = false;
    }

}
