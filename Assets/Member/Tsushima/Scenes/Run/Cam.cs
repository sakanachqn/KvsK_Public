using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    float X_Rotation;
    float Y_Rotation;

    [SerializeField]
    private float Xsn;
    [SerializeField]
    private float Ysn;

    float maxview = 60;
    float minview = 360 - 60;

    void Start()
    {
        //カーソルをロックする
        Cursor.lockState = CursorLockMode.Locked;
        //カーソルを見えなくする
        Cursor.visible = false;
    }
    void Update()
    {
        X_Rotation = Input.GetAxis("Mouse X") * Xsn * Time.deltaTime;
        Y_Rotation = Input.GetAxis("Mouse Y") * Ysn * Time.deltaTime;

        maxview = 60;
        minview = 360 - 60;

        var localAngle = player.transform.localEulerAngles;
        localAngle.x += -Y_Rotation;


        if (localAngle.x > maxview && localAngle.x < 180)
        {
        localAngle.x = maxview;
        }
        if (localAngle.x < minview && localAngle.x > 180)
        {
        localAngle.x = minview;
        }

        player.transform.localEulerAngles = localAngle; //カメラの縦回転
        localAngle = player.transform.localEulerAngles;
        localAngle.y += X_Rotation;
        player.transform.localEulerAngles = localAngle;
        
    }
}
