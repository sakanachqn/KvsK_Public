using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
   //Hpスライダーの管理
   public Slider _slider;
    public void HpDown(float Hp)
    {
        _slider.value = CthulhuManager.cthulhuManager.maxHealth - Hp;
    }
    public void Start()
    {
        _slider = GameObject.Find("HpSlider").GetComponent<Slider>();

    }



    void Update()
    {
        
    }
}