using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    public static CursorManager cursorManager;

    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;

    }

    void SceneLoaded (Scene nextScene, LoadSceneMode mode) 
    {
        CursorUpdate();
        Debug.Log(nextScene.name);
        Debug.Log(mode);
    }

    public void CursorUpdate()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        var str = SceneManager.GetActiveScene().name;
        if(GameManager.GameManagerClass.titleSceneObj == str || 
            GameManager.GameManagerClass.resultSceneObj == str ||
            GameManager.GameManagerClass.gameoverSceneObj == str)
        {
            Debug.Log("Cursor:enable");
            Cursor.visible = true;
        }
        else
        {
            Debug.Log("Cursor:false");
            Cursor.visible = false;
        }
    }

}
