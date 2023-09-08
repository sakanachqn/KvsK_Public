using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject child;
    public bool MoveFlag;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name.Substring(0, 1) == "0")
        {
            speed = SabaStats.SabaBulletSpeed;
            MoveFlag = true;

        }
        else if(this.gameObject.name.Substring(0, 1) == "1")
        {
            speed = KazikiStats.KazikiBulletSpeed;
            MoveFlag = true;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(MoveFlag)
            this.gameObject.transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    public void SabaRandom()
    {
        if(this.gameObject.name.Substring(0,1) == "1") return;
        // サバのランダム化
        MoveFlag = true;
        var rot = transform.eulerAngles;
        var rnd = SabaStats.SabaRandomAC * 0.5f;
        rnd = Random.Range(-rnd,rnd);
        rot.y += rnd;
        this.transform.localRotation = Quaternion.Euler( rot.x, rot.y, rot.z);
        //Debug.Log(child.transform.localRotation);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Shoggoth") || other.gameObject.tag == ("Offspring"))
        {
            if (this.gameObject.name.Substring(0, 1) == "0")
                GameManager.GameManagerClass.soundManager.Play("SabaHit");
            if (this.gameObject.name.Substring(0, 1) == "1")
                GameManager.GameManagerClass.soundManager.Play("KazikiHit");
        }

    }
}
