using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

	public float xmin = -0.090f;
	public float xmax = 25.0f;
	public float ymin = -0.75f;
	public float ymax = 0.37f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, xmin, xmax),
			Mathf.Clamp(transform.position.y, ymin, ymax),
			transform.position.z
		);	
	}
}
