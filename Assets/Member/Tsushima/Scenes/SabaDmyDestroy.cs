using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SabaDmyDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "BetaTest")
        {
            StartCoroutine(DestroyTimer(75f));
        }
        else
        {
            StartCoroutine(DestroyTimer(5f));
        }
    }


    IEnumerator DestroyTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
