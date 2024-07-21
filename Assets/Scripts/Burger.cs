using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col is CircleCollider2D && col.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject,0.2f);
			SoundManagerScript.PlaySound("powerup");		
			PlayerStats.healthHaggar = 1.0f; 	
		}
	}
}
