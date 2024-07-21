using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float xmin = -0.090f;
	public float xmax = 25.0f;
	public float ymin = -0.75f;
	public float ymax = 0.37f;

	[SerializeField]
	private Transform targetToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			Mathf.Clamp(targetToFollow.position.x, xmin, xmax),
			Mathf.Clamp(targetToFollow.position.y, ymin, ymax),
			transform.position.z
		);	
	}
}
