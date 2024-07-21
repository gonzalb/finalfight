using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaggarMovement : MonoBehaviour {
	public Rigidbody2D rigidbody2D;
	public float LerpConstant;
	public float speed;
	public Animator animator;
	bool facingRight = true;
	bool isWalking = false;


	public float xmin = -0.090f;
	public float xmax = 25.0f;
	public float ymin = -0.75f;
	public float ymax = 0.37f;

	private Vector3 change;
	
	//Use this for initialization
	void Start () {	
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Awake()
	{
		//DontDestroyOnLoad(this.gameObject);
	}

	public void FixedUpdate ()
	{
		change = Vector3.zero;
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		if (change != Vector3.zero)
		{			
			//move player
			
			var pos = transform.position + change.normalized * speed * Time.deltaTime;

			pos.x = Mathf.Clamp(pos.x, xmin, xmax);
			pos.y = Mathf.Clamp(pos.y, ymin, ymax);
			
			rigidbody2D.MovePosition(pos);

			animator.SetBool("isWalking",true);
		}
		else
		{
			animator.SetBool("isWalking",false);
		}

		if (change.x>0 && !facingRight)
			Flip();
		else if (change.x<0 && facingRight)
			Flip();

	}
	
	// Update is called once per frame
	public void Update () {		

		if (Input.GetKeyDown(KeyCode.O))
		{
		 	SoundManagerScript.PlaySound("doubleariat");
		 	animator.SetBool("isWalking",false);
		 	animator.SetTrigger("doublelariat");
		 	print("O key is released");
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
		 	SoundManagerScript.PlaySound("punch");
		 	animator.SetBool("isWalking",false);
		 	animator.SetTrigger("punch");
		 	print("P key is released");
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
		 	animator.SetBool("isWalking",false);
		 	animator.SetTrigger("grab");
		 	print("G key is released");
		}

		if (PlayerStats.healthHaggar <= 0)
		{
			//FindObjectOfType<GameManager>().EndGame();
			Destroy(gameObject);
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		print(col);
		print(col.GetType());

		
		if (col is CircleCollider2D) //col.gameObject.name.Equals("Haggar"))
		{
			print("hit enemy");
			PlayerStats.healthHaggar -= 0.1f;
		 	animator.SetTrigger("hurt");
 		 	SoundManagerScript.PlaySound("hit");					
		}	
	}

	
}
