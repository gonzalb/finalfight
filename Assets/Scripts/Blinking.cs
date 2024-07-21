using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	float timer = 0.0f;
    int seconds;

	// Use this for initialization
	void Start () {
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
  		StartCoroutine(BlinkText());
	}
	
	public IEnumerator BlinkText(){
	//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
			spriteRenderer.enabled = true;
			yield return new WaitForSeconds(.5f);
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(.5f);
		}
	}
}
