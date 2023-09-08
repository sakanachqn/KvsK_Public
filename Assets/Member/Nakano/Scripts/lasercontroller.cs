using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lasercontroller : MonoBehaviour
{
    //これを呼び出すとレーザーが発動するようになる奴
    [SerializeField]
    private GameObject player;
    [SerializeField]
    public Rightlaserbeam rightlaserbeam;
    [SerializeField]
    public leftlaserbeam leftlaserbeam;

    public void Dolaser()
    {
        if (player.transform.position.x<0)
        {
            Debug.Log("ZZZZZ");
            rightlaserbeam.Doer(Vector3.left,Vector3.forward);
        }
        if(player.transform.position.x>-0.1)
        {
            Debug.Log("XXXXX");
            leftlaserbeam.Doer(Vector3.left, Vector3.forward);
        }
    }
}