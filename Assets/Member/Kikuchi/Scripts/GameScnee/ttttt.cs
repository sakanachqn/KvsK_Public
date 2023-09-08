
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttttt : MonoBehaviour
{
    private Renderer renderer;



    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            renderer.material.SetFloat("_RimLight", 1f);
        }
        if(Input.GetMouseButtonDown(1))
        {
            renderer.material.SetFloat("_RimLight", 0f);
        }
    }


}
