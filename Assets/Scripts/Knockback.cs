using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

	public float thrust;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEntered2D(Collider2D other)
	{
		print("knockback");

		if (other.gameObject.CompareTag("Enemy"))
		{
			print("Enemy tag");
			Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
			if (enemy != null)
			{
				enemy.isKinematic = false;
				Vector2 diff = enemy.transform.position - transform.position;
				diff = diff.normalized * thrust;
				print("addforce: "+diff);
				enemy.AddForce(diff, ForceMode2D.Impulse);
				enemy.isKinematic = true;
			}
		}

	}
}
