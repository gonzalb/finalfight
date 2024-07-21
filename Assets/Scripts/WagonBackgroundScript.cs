using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonBackgroundScript : MonoBehaviour {

	public float scrollSpeed = 50f;
	public float length = 100f;
	Vector2 startPos;
	private float newPos;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		newPos = Mathf.Repeat(Time.time * scrollSpeed, 200);
		transform.position = startPos + Vector2.left * newPos;
	}
}
