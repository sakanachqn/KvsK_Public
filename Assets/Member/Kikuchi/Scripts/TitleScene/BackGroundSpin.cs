using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpin : MonoBehaviour
{
    [SerializeField]
    private float clockSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, clockSpeed * Time.deltaTime);
        if (transform.rotation.z >= 360) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
