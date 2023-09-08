using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lightning;
    private float timer;

    [SerializeField]
    private SceneStartDelay CSD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CSD.IsDelay) return;
        timer += Time.deltaTime;
        if(timer > 5f)
        {
            timer = 0f;
            Instantiate(lightning,new Vector3(PlayerController.PlayerGameObject.transform.position.x,PlayerController.PlayerGameObject.transform.position.y + 0.1f,PlayerController.PlayerGameObject.transform.position.z), Quaternion.identity);
        }
    }
}
