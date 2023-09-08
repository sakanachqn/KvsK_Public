using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameManagerClass.soundManager.ChangeBGM("BGMWIN");
    }

}
