using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueSoundPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameManagerClass.soundManager.ChangeBGM("BGM2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
