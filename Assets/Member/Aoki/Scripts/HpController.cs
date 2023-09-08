using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    private int number = 6;

    [SerializeField]
    private int childnumber = 0;

    void Start()
    {
        transform.GetChild(childnumber).gameObject.SetActive(true);
        //HpInvinciblyManager.PlayerHp = number;
    }
    void Update()
    {
        //if (HpInvinciblyManager.PlayerHp < number || HpInvinciblyManager.PlayerHp > number)
        //{
        //    HpChange();
        //}


    }

    private void HpChange()
    {

        transform.GetChild(childnumber).gameObject.SetActive(false);

        //HpInvinciblyManager.PlayerHp = number;

        childnumber = number;

        transform.GetChild(childnumber).gameObject.SetActive(true);

    }
}