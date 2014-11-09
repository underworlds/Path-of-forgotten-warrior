using UnityEngine;
using System.Collections;


public class MainCharacterMovement : MonoBehaviour {
	
	//Kuba:
	/*Jak jsme se dohodli pohyb bude na šipkách, skok šipkou nahoru*/
	
	
	//Rychlost pohybu
	private float maxSpeed = 2.5f;
	
	//vyska skoku ...dal bych asi mene, neco kolem 75
	private int jumpHeight = 100;
	
	//komponenta pro detekci, zda se nachazim na zemi
	public Transform groundCheck;
	
	// radius kruhu ktery provede detekci
	private const float graundRadius = 0.1f;
	
	
	// maska urcujici co je zem
	public LayerMask whatIsGround;
	
	// promenna pro zjisteni zda je hrdina na zemi, 
	bool isGrounded = false; //melo by byt implicitne false
	
	//promenna pro hlidani jestli postava hledi doprava, nebo je otocena
	public bool isFacingRight = true;
	
	//Animator
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(anim == null){
			print("There is no animator");
		}
	}

	void Update(){

		if(Input.GetKey(KeyCode.UpArrow) && isGrounded) ;
		{
			print("going to add force");
			anim.SetBool("Ground",false);
			//rigidbody2D.AddForce(new Vector2(0,jumpHeight));
		}
	}


	void FixedUpdate(){
		float move = Input.GetAxis ("Horizontal"); // musi se jeste prenastavit axis

		anim.SetFloat ("Speed", Mathf.Abs (move));
			
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			
			
		if(move > 0 && !isFacingRight){
			Flip();
		}else if(move < 0 && isFacingRight) {
			Flip ();
		}

		isGrounded = (Physics2D.OverlapCircle (groundCheck.position, graundRadius, whatIsGround));
		anim.SetBool("Ground",isGrounded);
		anim.SetFloat("vSpeed",rigidbody2D.velocity.y);

		//jump movement

		/*if(Input.GetKey(KeyCode.UpArrow) && isGrounded){
			rigidbody2D.AddForce(new Vector3(0,jumpHeight,0));	
		}*/
	}


	/**
	 * Metoda z jednoho tutorialu, mela by otocit postavu tak aby koukala doleva...
	 * Muze byt odstraneno pokud chceme aby postava jen couvala a neotacela se :) 
	 * 
	 **/
	
	void Flip(){ //fliping the world
		isFacingRight = (!isFacingRight);
		Vector3 theScale = transform.localScale; //let me get local scale
		theScale.x *= -1;						// flip x axis	
		transform.localScale = theScale;		//get it back to local scale 
	}
	
	
	
}
