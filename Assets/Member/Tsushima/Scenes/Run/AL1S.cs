using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AL1S : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;

    private NavMeshAgent agent;

    [SerializeField]
    private AudioSource ad;
    private bool soundFlag;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        soundFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 40f && !soundFlag)
        {
            Debug.Log("Play");
            soundFlag = true;
            ad.Play();
        } 
        else if(Vector3.Distance(player.transform.position, transform.position) > 45f && soundFlag)
        {
            soundFlag = false;
        }
        agent.SetDestination(player.transform.position);

		Vector3 p = player.transform.position;
		p.y = transform.position.y;
		transform.LookAt (p);
    }
}
