using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoookAt : MonoBehaviour
{
	[SerializeField]
	private Transform target;
	void Start()
	{
		
	}

	void Update () 
	{
		this.transform.LookAt(target, Vector3.up);
    }
}
