using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletGage : MonoBehaviour
{
    public Slider ammoSlider;

    private int bulletsRemaining;
    private int maxBullets = 20;

    private void Start()
    {
        UpdateBulletGage();
    }

    private void UpdateBulletGage()
    {
        float ammoPercentage = (float)bulletsRemaining / maxBullets;
        ammoSlider.value = ammoPercentage;
    }

    public void DecreaseBullets()
    {
        if (bulletsRemaining > 0)
        {
            bulletsRemaining--;
            UpdateBulletGage();
        }
    }

    public void IncreaseBullets()
    {
        if (bulletsRemaining < maxBullets)
        {
            bulletsRemaining++;
            UpdateBulletGage();
        }
    }
}

