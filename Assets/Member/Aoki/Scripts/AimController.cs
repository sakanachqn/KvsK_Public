using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public Vector3 targetPos;
    public Image aimImage;

    void Update()
    {
        // 「マウスの位置」と「照準器の位置」を同期させる。
        transform.position = Input.mousePosition;
    }
}