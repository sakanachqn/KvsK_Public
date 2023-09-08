using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySponePoollManager : MonoBehaviour
{
    public static EnemySponePoollManager enemySponePoolManager;
    public ObjectPool<GameObject> OffspringPool;
    public ObjectPool<GameObject> ShoggothPool;
    public ObjectPool<GameObject> FishingmanPool;

    [SerializeField]
    private List<GameObject> EnemyPrefab = new List<GameObject>();

    void Awake()
    {
        enemySponePoolManager = this.gameObject.GetComponent<EnemySponePoollManager>();
        OffspringPool = new ObjectPool<GameObject>(OnCreatePooledObject3, OnGetFromPool, OnReleaseToPool1, OnDestroyPooledObject);
        ShoggothPool = new ObjectPool<GameObject>(OnCreatePooledObject2, OnGetFromPool, OnReleaseToPool2, OnDestroyPooledObject);
        FishingmanPool = new ObjectPool<GameObject>(OnCreatePooledObject1, OnGetFromPool, OnReleaseToPool3, OnDestroyPooledObject);

    }
    GameObject OnCreatePooledObject1()
    {
        return Instantiate(EnemyPrefab[0]);
    }
    GameObject OnCreatePooledObject2()
    {
        return Instantiate(EnemyPrefab[1]);
    }
    GameObject OnCreatePooledObject3()
    {
        return Instantiate(EnemyPrefab[2]);
    }


    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void OnReleaseToPool1(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void OnReleaseToPool2(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void OnReleaseToPool3(GameObject obj)
    {
        obj.SetActive(false);
    }



    void OnDestroyPooledObject(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject GetGameObject(int i, Vector3 position, Quaternion rotation)
    {
        GameObject obj = null;
        switch(i)
        {
            case 0:
            {
                obj = FishingmanPool.Get();
                break;
            }
            case 1:
            {
                obj = ShoggothPool.Get();
                break;
            }
            case 2:
            {
                obj = OffspringPool.Get();
                break;
            }
        }
        Transform tf = obj.transform;
        tf.position = position;
        tf.rotation = rotation;

        return obj;
    }

/*
    public void ReleaseGameObject(GameObject obj,int i)
    {
        switch(i)
        {
            case 0:
            {
                FishingmanPool.SetActive(false);
                break;
            }
            case 1:
            {
                ShoggothPool.SetActive(false);          
                break;
            }
            case 2:
            {
                OffspringPool.SetActive(false);
                break;
            }
        }
    }
*/
}
