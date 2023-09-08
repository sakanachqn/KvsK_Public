using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutuluhuCrosshair : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    void Update()
    {
/*
        var mouse = Input.mousePosition;
        var target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y * 5f, 10f));
        this.transform.position = new Vector3(target.x,0f,target.z + 10);
*/
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = new RaycastHit();
        if(Physics.Raycast(ray, out hit))
        {
            this.transform.position = new Vector3(hit.point.x,0f,hit.point.z);

        }     

    }
}
