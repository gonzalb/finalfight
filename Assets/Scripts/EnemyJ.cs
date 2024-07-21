using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJ : Enemy {

	public static float healthJ;
	private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Start () {
		healthJ = 1.0f;
		animator = GetComponent<Animator>();
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		CheckDistance();
		this.spriteRenderer.flipX = target.position.x < this.transform.position.x;
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		if (col is CircleCollider2D) 
		{
			print("hit EnemyJ");
			healthJ = healthJ - 0.5f; 
		 	animator.SetTrigger("hurt");
 		 	SoundManagerScript.PlaySound("hit");
			if (healthJ <= 0.0f)
			{
	 		 	SoundManagerScript.PlaySound("enemydie");
  	   			StartCoroutine(DoBlinks(1.0f, 0.02f));
				Destroy(gameObject,0.2f);
			} 				
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
