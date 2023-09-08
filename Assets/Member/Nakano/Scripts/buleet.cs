using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buleet : MonoBehaviour
{
    //クトゥルフから発射される玉の速さの管理
    [SerializeField]
    public float bulletSpeed = 1;
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletSpeed/60.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //ここにプレイヤーのdamage処理お願いします
            StartCoroutine(HpInvinciblyManager.Invincible());
            Destroy(this.gameObject, 0.1f);
        }

        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject, 0.1f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
