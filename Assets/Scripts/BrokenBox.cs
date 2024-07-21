using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBox : MonoBehaviour {

    public GameObject myPrefab;
	private GameObject instantiatedObj;	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col is CircleCollider2D && col.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject,0.1f);
			SoundManagerScript.PlaySound("brokenbox");
	        instantiatedObj = (GameObject)Instantiate(myPrefab, new Vector2(transform.position.x, transform.position.y-0.5f), transform.rotation);
			Destroy(instantiatedObj, 0.5f);
		}
	}
}
