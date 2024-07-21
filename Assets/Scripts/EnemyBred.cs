using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBred : Enemy {
	public static float healthBred = 1.0f; 
	public Transform homePosition;
	private SpriteRenderer spriteRenderer;
	public Rigidbody2D rigidbody2D;
	public float knockTime;

	// Use this for initialization
	void Start () {
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckDistance();
        this.spriteRenderer.flipX = target.position.x < this.transform.position.x;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		print(col);
		print(col.GetType());

	
		if (col is CircleCollider2D && col.gameObject.CompareTag("Player"))
		{

			healthBred = healthBred - 0.5f; 
		 	animator.SetTrigger("hurt");
 		 	SoundManagerScript.PlaySound("hit");

			rigidbody2D.isKinematic = false; 
			Vector2 m_NewForce = new Vector2(10, 1); 
			rigidbody2D.AddForce(m_NewForce, ForceMode2D.Impulse);
			StartCoroutine(KnockCo());

			if (healthBred <= 0.0f)
			{

	 		 	SoundManagerScript.PlaySound("enemydie");
	   			StartCoroutine(DoBlinks(1.0f, 0.02f));
				Destroy(gameObject,0.2f);
				Destroy(GameObject.Find("BredBar"),0.2f);
			} 				
		}	
	}

	IEnumerator KnockCo()
	{
		yield return new WaitForSeconds(knockTime);
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.isKinematic = true;
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
