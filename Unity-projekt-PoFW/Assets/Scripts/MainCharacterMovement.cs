using UnityEngine;
using System.Collections;


public class MainCharacterMovement : MonoBehaviour {

	//Just for fall damage
	private GameManager gameManager;
	private bool fallDamageCanBeUsed = true;

	//Rychlost pohybu
	private float maxSpeed = 2.5f;
	
	//vyska skoku ...dal bych asi mene, neco kolem 75
	private int jumpHeight = 300;
	
	//komponenta pro detekci, zda se nachazim na zemi
	public Transform groundCheck;
	
	// radius kruhu ktery provede detekci
	private const float graundRadius = 0.1f;

	// maska urcujici co je zem
	public LayerMask whatIsGround;
	
	// promenna pro zjisteni zda je hrdina na zemi, 
	public bool isGrounded = false; //melo by byt implicitne false
	
	//promenna pro hlidani jestli postava hledi doprava, nebo je otocena
	public bool isFacingRight = true;
	
	//Animator
	private Animator anim;

	// moving direction
	private float move;
	public bool canMove = true;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(anim == null){
			print("There is no animator");
		}

		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}

	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){	
			isGrounded = false;
			anim.SetBool("Ground",isGrounded);
			rigidbody2D.AddForce(new Vector2(0,jumpHeight));
		}
	}


	void FixedUpdate(){
		if(canMove){
			move = Input.GetAxis ("Horizontal");

			anim.SetFloat("Speed", Mathf.Abs (move));
			
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

			if(move > 0 && !isFacingRight){
				Flip();
			}else if(move < 0 && isFacingRight) {
				Flip ();
			}
			
			//jumping stuff and setting to animations
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, graundRadius, whatIsGround);
			anim.SetBool("Ground",isGrounded);
			anim.SetFloat("vSpeed",rigidbody2D.velocity.y);

			//dealing with fall damage
			ResolveFallDamage(rigidbody2D.velocity.y);

		}else{
			anim.SetFloat("Speed", Mathf.Abs (0.0f));
		}
	}


	/**
	 * Dealing with situation when character falls for a long time...he drop from somewhere
	 */
	private void ResolveFallDamage(float velocityY){
		if(velocityY < -10.5f && fallDamageCanBeUsed ){
			fallDamageCanBeUsed = false;
			this.gameObject.GetComponent<Animator>().SetTrigger("hitTrigger");
			gameManager.FallDamage();
			if(velocityY < -15.5f){
				gameManager.FallDamage();
			}
		}else if(rigidbody2D.velocity.y >= -10.5f){
			fallDamageCanBeUsed = true;
		}		
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
