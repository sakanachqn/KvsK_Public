using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem light;
    [SerializeField]
    private ParticleSystem magic;
    private bool flag;
    public bool inRange;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 3f && flag)
        {
            
            flag = false;
            light.Play();
        }
        if(timer > 5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

}
