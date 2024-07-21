using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject myPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject,0.1f);
			SoundManagerScript.PlaySound("explode");
	        Instantiate(myPrefab, new Vector2( 7.4f, -0.16f), Quaternion.identity);

			// 7.4 -0.16				
		}
	}
}
