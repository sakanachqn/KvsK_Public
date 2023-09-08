using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Kaziki : MonoBehaviour
{
    [SerializeField]
    private GameObject kazikiObj;
    [SerializeField]
    private GameObject player;


    private PlayerAnim anim;

    private bool IsNowThrowAnim = false;
    [SerializeField]
    private List<GameObject> light = new List<GameObject>();

    [SerializeField]
    [Header("カジキの発射タイミング")]
    private float throwTime;
    /*
        [SerializeField]
        private AlphaTestUI alphaTestUI;
    */

    [SerializeField]
    private SceneStartDelay CSD;

    // Start is called before the first frame update
    void Start()
    {
        if(anim == null)
        {
            anim = this.transform.root.GetComponent<PlayerAnim>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!CSD.IsDelay || CthulhuManager.IsDead) return;
        if (Input.GetMouseButtonDown(1) && KazikiStats.KazikiNowBullet == 1 && !PlayerController.DASH)
        {
            KazikiStats.KazikiNowBullet--;
            KazikiLight();
            UIManager.uiManager.KazikiUpdate();
            anim.KazikiAnim();
        }
        else if(Input.GetMouseButtonDown(1) && KazikiStats.KazikiNowBullet == 0 && !PlayerController.DASH)
        {
            GameManager.GameManagerClass.soundManager.Play("KazikiNotShot");
        }
    }

    public void KazikiLight()
    {
        if(KazikiStats.KazikiNowBullet >= 1)
        {
            Debug.Log("*");
            for(int i = 0; i < light.Count; i++)
            {
                light[i].SetActive(false);
            }
        }
        else
        {
            for(int i = 0; i < light.Count; i++)
            {
                Debug.Log("**");
                light[i].SetActive(true);
            }
        }
    }

    public void KazikiThrowAnim()
    {
        Instantiate(kazikiObj, new Vector3(player.transform.position.x,0f,player.transform.position.z), player.transform.rotation);
        
        GameManager.GameManagerClass.soundManager.Play("KazikiShot");
    }
}
