using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazikiResidue : MonoBehaviour
{
    [SerializeField]
    private BulletMove bulletMove;
    [SerializeField]
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            boxCollider.enabled = false;
            bulletMove.MoveFlag = false;
            this.tag = "Null";
        }
    }
}
