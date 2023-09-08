using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetaUI : MonoBehaviour
{
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }

    void SceneLoaded (Scene nextScene, LoadSceneMode mode) 
    {
        
        var str = SceneManager.GetActiveScene().name;
        if(GameManager.GameManagerClass.titleSceneObj == str || 
            GameManager.GameManagerClass.resultSceneObj == str ||
            GameManager.GameManagerClass.gameoverSceneObj == str)
        {
            
            Destroy(this.gameObject);
            UIManager.uiManager.InitUI();
        }
        else
        {
            Debug.Log(score);
            StartCoroutine(InitCutuluhuScore());
            UIManager.uiManager.CutuluhuScore(0);
        }
    }

    IEnumerator InitCutuluhuScore()
    {
        yield return new WaitForSeconds(3.5f);
        UIManager.uiManager.CutuluhuScore(0);
    }


}
