using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonController : MonoBehaviour
{
    //タイトルへ戻る
    public void TitleSceneButton()
    {
        PauseController.Instance.Button();
        SceneManager.LoadScene("TitleScene");
    }

    //再開する
    public void RestartButton()
    {
        PauseController.Instance.Button();
    }
}
