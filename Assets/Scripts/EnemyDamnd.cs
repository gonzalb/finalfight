using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamnd : MonoBehaviour {

	public string enemyName;
	public int baseAttack;
	public float moveSpeed;
	public float chaseRadius;
	public float attackRadius;
	public Transform target;
	public Animator animator;

	private SpriteRenderer spriteRenderer;
	public Rigidbody2D rigidbody2D;
	public float knockTime;

	public static float healthDamnd = 1.0f; 

	void Awake()
	{
     	target = GameObject.FindWithTag("Player").transform; //target the player
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckDistance();
        this.spriteRenderer.flipX = target.position.x < this.transform.position.x;
	}

	public void CheckDistance()
	{
		if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
		{
			if (Vector3.Distance(target.position, transform.position) > attackRadius)
			{
				transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
				animator.SetBool("isAttacking", false);
				animator.SetBool("isWalking", true);
			}
			else
			{
				animator.SetBool("isAttacking", true);
			} 
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{		
		if (col is CircleCollider2D && col.gameObject.CompareTag("Player"))
		{

			healthDamnd = healthDamnd - 0.25f; 
		 	animator.SetTrigger("hurt");
 		 	SoundManagerScript.PlaySound("hit");

			rigidbody2D.isKinematic = false; 
			Vector2 m_NewForce = new Vector2(10, 1); 
			rigidbody2D.AddForce(m_NewForce, ForceMode2D.Impulse);
			StartCoroutine(KnockCo());

			if (healthDamnd <= 0.0f)
			{
	 		 	SoundManagerScript.PlaySound("enemydie");
	   			StartCoroutine(DoBlinks(1.0f, 0.02f));
				Destroy(gameObject,0.2f);
				//Destroy(GameObject.Find("BredBar"),0.2f);
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
