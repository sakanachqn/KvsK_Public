using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoggothAnimation : MonoBehaviour
{
	[SerializeField] UnityEngine.AI.NavMeshAgent agent;
	[SerializeField]Animator animator;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }



    void Update()
	{
        MoveAnimation();
    }

    private void MoveAnimation()
    {
        if (agent.velocity.sqrMagnitude > 1)
        {
            animator.SetBool("toMove", true);
            //Debug.Log(this.gameObject.name);
        }
        else
        {
            animator.SetBool("toMove", false);
        }
        //Debug.Log(agent.velocity.sqrMagnitude);
    }

    public void ShoggothAttackAnimation()
    {
        animator.SetTrigger("toAttack");
    }

    public void ShoggothDeathAnimation()
    {
        animator.SetTrigger("toDeath");
    }


}
