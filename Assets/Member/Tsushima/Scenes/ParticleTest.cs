using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    void Start()
    {
        StartCoroutine(LoopParticle());
    }

    IEnumerator LoopParticle()
    {
        var wait = new WaitForSeconds(3);
        while(true)
        {
            particle.Play();
            yield return wait;
        }
    }
}
