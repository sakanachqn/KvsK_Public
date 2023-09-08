using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject _objPause;

    private GameObject _objInstancePause;

    private int _count = 0;

    private static PauseController _instance;
    public static PauseController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance
                    = GameObject.FindObjectOfType<PauseController>();
            }
            return _instance;
        }
    }

    void Update()
    {
        //ESCを押したらポーズ画面になる
        if (Input.GetKey(KeyCode.Escape))
        {
            if (_count == 0)
            {
                _count++;
                GameObject _objInstance = Instantiate(_objPause,new Vector3(0,0,0), Quaternion.identity);
                _objInstancePause = _objInstance;
                Time.timeScale = 0;
            }
        }      
    }

    //ボタンを押した後の処理
    public void Button()
    {
        _count = 0;
        Time.timeScale = 1;
        Destroy(_objInstancePause);
    }
}
