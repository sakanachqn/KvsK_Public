using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolInstantiate : MonoBehaviour
{
    [SerializeField]
    private bool useObjectPool = true;
    [SerializeField]
    private BulletPoolManager poolManager;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private Transform target;
    private float spawnInterval;
    [SerializeField]
    private float destroyWaitTime = 120;

    private bool nowReload;
    [SerializeField]
    private GameObject mazzleflash;

    private WaitForSeconds spawnIntervalWait;
    private WaitForSeconds sabaReload;

    [SerializeField]
    private SceneStartDelay CSD;


/*
    [SerializeField]
    private AlphaTestUI alphaTestUI;
*/

    void Start()
    {
        spawnIntervalWait = new WaitForSeconds(SabaStats.SabaFireRate);
        sabaReload = new WaitForSeconds(SabaStats.SabaReloadTime);
        StartCoroutine(SabaSpawn());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) StartCoroutine(SabaReload());
    }

    private IEnumerator SabaSpawn()
    {
        var ClickWait = new WaitUntil(() => Input.GetMouseButton(0));
        while (true)
        {
            yield return spawnIntervalWait;
            mazzleflash.SetActive(false);
            yield return ClickWait;
            Spawn(Bullet);
        }
    }

    void Spawn(GameObject prefab)
    {
        if(SabaStats.SabaNowBullet <= 0 || PlayerController.DASH || !CSD.IsDelay || CthulhuManager.IsDead)  return;
        mazzleflash.SetActive(true);
        SabaStats.SabaNowBullet--;
        GameManager.GameManagerClass.soundManager.Play("SabaShot");

        UIManager.uiManager.BulletTextUpdate();

        if(SabaStats.SabaNowBullet <= 0) StartCoroutine(SabaReload());
        BulletPoolDestroy destroyer;
        if(useObjectPool)
        {
            destroyer = poolManager.GetGameObject(prefab, this.transform.position, this.transform.rotation).GetComponent<BulletPoolDestroy>();
            destroyer.sabaResidue.InitSet();
            destroyer.PoolManager = poolManager;
        }
        else
        {
            destroyer = Instantiate(prefab, this.transform.position, this.transform.rotation).GetComponent<BulletPoolDestroy>();
            //destroyer.sabaResidue.bulletMove.MoveFlag = true;
            destroyer.sabaResidue.InitSet();
        }

        if(destroyer != null)
        {
            destroyer.StartDestroyTimer(destroyWaitTime);
        }
    }

    IEnumerator SabaReload()
    {
        if(nowReload) yield break;
        GameManager.GameManagerClass.soundManager.Play("SabaReload");
        nowReload = true;
        SabaStats.SabaNowBullet = 0;
        UIManager.uiManager.BulletTextUpdate();
        yield return sabaReload;
        SabaStats.SabaNowBullet = SabaStats.SabaMaxBullet;
        UIManager.uiManager.BulletTextUpdate();
        nowReload = false;
    }

}
