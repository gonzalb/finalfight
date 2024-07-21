using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoScript : MonoBehaviour {


		private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
			StartCoroutine(DoBlinks(1.0f, 0.2f));
	}

	IEnumerator DoBlinks(float duration, float blinkTime) 
	{
         while (duration > 0f) {
                 duration -= Time.deltaTime;
      
            //toggle renderer
            spriteRenderer.enabled = !spriteRenderer.enabled;
      
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
         }
  
         //make sure renderer is enabled when we exit
         spriteRenderer.enabled = true;
    }
}
