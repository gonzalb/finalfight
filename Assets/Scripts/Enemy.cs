using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public string enemyName;
	public int baseAttack;
	public float moveSpeed;
	public float chaseRadius;
	public float attackRadius;
	public Transform target;
	public Animator animator;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckDistance()
	{
		if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
		{
			if (Vector3.Distance(target.position, transform.position) > attackRadius)
			{
				transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
				animator.SetBool("isAttacking", false);
			}
			else
			{				
				animator.SetBool("isAttacking", true);
			} 
		}
	}
}
