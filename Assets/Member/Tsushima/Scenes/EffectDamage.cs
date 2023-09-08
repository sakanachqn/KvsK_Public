using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : MonoBehaviour
{
    [SerializeField]
    private LightningParticle lightningParticle;
    private bool flag;
    void Update()
    {
        if(lightningParticle.timer > 3.15f && !flag )
        {
            flag = true;
            if(lightningParticle.inRange)
                StartCoroutine(HpInvinciblyManager.Invincible());

        }
    }
}
