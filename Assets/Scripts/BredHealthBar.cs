using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BredHealthBar : MonoBehaviour {

	Vector3 localScale;
	public float scalebar = 0.32f;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		localScale.x = (1 - EnemyBred.healthBred)*scalebar;
		transform.localScale = localScale;
	}
}
