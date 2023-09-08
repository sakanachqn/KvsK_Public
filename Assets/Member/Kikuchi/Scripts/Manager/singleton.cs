using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static GameObject singletonManager;

    private void Awake()
    {
        if(singletonManager == null)
        {
            singletonManager = this.gameObject;
        }
    }

}
