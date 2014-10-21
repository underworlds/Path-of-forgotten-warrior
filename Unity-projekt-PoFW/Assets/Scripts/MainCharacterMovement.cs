using UnityEngine;
using System.Collections;


public class MainCharacterMovement : MonoBehaviour {

	//Kuba:
	/*Jak jsme se dohodli pohyb bude na šipkách, skok šipkou nahoru*/


	//Rychlost pohybu
	private float speed =  2.0f;

	//vyska skoku
	private int jumpHeight = 100;

	//komponenta pro detekci, zda se nachazim na zemi
	public Transform groundCheck;

	// radius kruhu ktery provede detekci
	float groundRadius = 0.1f;

	// maska urcujici co je zem
	public LayerMask whatIsGround;

	// promenna pro zjisteni zda je hrdina na zemi, 
	bool isGrounded = false; //melo by byt implicitne false

	//promenna pro hlidani jestli postava hledi doprava, nebo je otocena
	bool isFacingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//left movement
		if(Input.GetKey(KeyCode.LeftArrow) ){
			//transform.position -= Vector3.right * speed * Time.deltaTime;
			this.rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);

			//flipping the character
			if(isFacingRight){
				this.Flip();
			}
		}

		//right movement
		if(Input.GetKey(KeyCode.RightArrow) ){
			//transform.position += Vector3.right * speed * Time.deltaTime;
			this.rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

			if(!isFacingRight){
				this.Flip();
			}
		}


		isGrounded = (Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround));
		//jump movement
		if(Input.GetKey(KeyCode.UpArrow) && isGrounded){

			rigidbody2D.AddForce(new Vector3(0,jumpHeight,0));	
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
