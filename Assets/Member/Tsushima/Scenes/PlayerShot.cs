using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    private Transform BulletParent;
    [SerializeField]
    private GameObject BulletObj;
    [SerializeField]
    private float BulletCoolDown;
    [SerializeField]
    public int BulletS;
    private bool ShotFlag;
    private Vector3 mousePosition;
    private Vector3 spherePosition;
    // Start is called before the first frame update
    void Start()
    {
        BulletS = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShotFlag = true;
            StartCoroutine(Shot(BulletCoolDown,BulletS));
        }
        if(Input.GetMouseButtonUp(0))
            ShotFlag = false;
            

        
    }

    // クールダウン
    private IEnumerator Shot(float f, int i)
    {
        Debug.Log("ShotStart");
        while(ShotFlag)
        {
            Debug.Log("WhileStart");
            for(int j = 0;j <= i;j++)
            { 
                Debug.Log(mousePosition);
                if(j > 0)
                {
                    var v = Random.Range(-8f,9f);
                    var vec = new Vector3(this.transform.rotation.x,this.transform.rotation.y,this.transform.rotation.z + v);
                    var obj = Instantiate(BulletObj, this.transform.position, this.transform.rotation,BulletParent);
                    
                    obj.transform.eulerAngles += new Vector3(vec.x,vec.y,vec.z);
                }
                else
                    Instantiate(BulletObj, this.transform.position, this.transform.rotation,BulletParent);
            }
            yield return new WaitForSeconds(f);
        }
    }
}
