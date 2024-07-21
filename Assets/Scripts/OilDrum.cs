using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilDrum : MonoBehaviour {
		public Animator animator;
		private SpriteRenderer spriteRenderer;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col is CircleCollider2D) //col.gameObject.name.Equals("Haggar"))
		{
		 	animator.SetTrigger("broken");
 			StartCoroutine(DoBlinks(1.0f, 0.02f));
			Destroy(gameObject,0.5f);
			SoundManagerScript.PlaySound("explode");							
		}
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
