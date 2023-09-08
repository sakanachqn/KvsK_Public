using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookPos : MonoBehaviour
{
    [SerializeField]
    private Transform crosshair;    //視線の位置
    [SerializeField]
    private Transform player;   //自身の位置

    private void Update()
    {
        SetFoward();
    }

    public void SetFoward()
    {
        Vector3 axis = player.transform.right;

        player.transform.rotation = Quaternion.FromToRotation(player.transform.forward, crosshair.transform.position - player.transform.position) * player.transform.rotation;
    }

}