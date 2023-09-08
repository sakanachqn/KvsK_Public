using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameManagerClass.soundManager.BGMsource == null)
        {
            GameManager.GameManagerClass.soundManager.LoopPlay("BGM1");
        }
        else
        {
            GameManager.GameManagerClass.soundManager.ChangeBGM("BGM1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
