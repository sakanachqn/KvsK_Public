using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabaDmy : MonoBehaviour
{
    [SerializeField]
    private SabaResidue sabaResidue;
    [SerializeField]
    private GameObject saba;

    public void Set(string str)
    {
        this.gameObject.tag = str;
    }

    public void Gen()
    {
        Instantiate(saba,this.transform.position,this.transform.rotation);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Ground") && sabaResidue.flag)
        {
            Gen();
            sabaResidue.end = true;
        }

    }

}
