using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Dash", true);
        }
        else
        {
            animator.SetBool("Dash", false);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger("ChargeComp");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Death");
        }
        if (Input.GetKey(KeyCode.V))
        {
            animator.SetBool("MoveA", true);
        }
        else
        {
            animator.SetBool("MoveA", false);
        }
    }
}
