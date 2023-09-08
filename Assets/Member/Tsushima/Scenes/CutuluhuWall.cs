using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutuluhuWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Mackrel"))
        {
            CthulhuManager.cthulhuManager.health -= 10;
            UIManager.uiManager.CutuluhuScore(Random.Range(1,6));
            Destroy(other.gameObject);
            Debug.Log("hit");
        }
        else if (other.gameObject.CompareTag("SwordFish"))
        {
            CthulhuManager.cthulhuManager.health -= 1000;
            UIManager.uiManager.CutuluhuScore(100);
            Destroy(other.gameObject);
            Debug.Log("hit");
        }
        CthulhuManager.cthulhuManager.hpSlider.HpDown(CthulhuManager.cthulhuManager.health);
    }
}
