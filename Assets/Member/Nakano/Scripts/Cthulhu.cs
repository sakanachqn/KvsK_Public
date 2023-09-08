using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Cthulhu : MonoBehaviour
//�N�g�D���t���T�o��J�W�L�ɓ����������̃_���[�W����
{

    public CthulhuManager cthulhuManager;

    private void OnTriggerEnter(Collider other)
    {
        if (cthulhuManager.health <= 0)
        {
            return;
        }
        if (other.gameObject.CompareTag("Saba"))
        {
            
            cthulhuManager.health -= 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Kaziki"))
        {
            
            cthulhuManager.health -= 1000;
            Destroy(other.gameObject);
        }
        if (cthulhuManager.health <= 0)
        {
            Debug.Log("���񂾂�");
        }
        cthulhuManager.hpSlider.HpDown(cthulhuManager.health);

    }
}


