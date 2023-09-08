using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolDestroy : MonoBehaviour
{
    [SerializeField]
    public BulletPoolManager PoolManager { get; set; }
    [SerializeField]
    public SabaResidue sabaResidue;
    private float timer;

    public void StartDestroyTimer(float time)
    {
        StartCoroutine(DestroyTimer(time));
    }
    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator DestroyTimer(float time)
    {
        timer = 0f;
        var bulletMove = this.gameObject.GetComponent<BulletMove>();
        bulletMove.SabaRandom();
        //yield return new WaitForSeconds(time);
        yield return new WaitUntil(() => sabaResidue.end == true || timer > 5f);
        if(PoolManager != null && timer > 5f)
        {
            sabaResidue.Gen();
            PoolManager.ReleaseGameObject(gameObject);
        }
        else if(PoolManager != null)
        {
            PoolManager.ReleaseGameObject(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
