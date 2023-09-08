using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRb : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0f || rb.velocity.z != 0f)
        {
            rb.velocity = new Vector3(0f,0f,0f);
        }
    }
}
