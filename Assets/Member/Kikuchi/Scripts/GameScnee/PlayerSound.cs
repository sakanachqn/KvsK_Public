using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public void KazikiCharge()
    {
        GameManager.GameManagerClass.soundManager.Play("KazikiCharge");
    }


}
