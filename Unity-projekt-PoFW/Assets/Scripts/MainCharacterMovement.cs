using UnityEngine;
using System.Collections;

public class Hero{
	private int health;
	private int points;
	private bool isFacingRight;
	private bool isGrounded;

	public Hero(){
		this.health = 3;
		this.points = 0;
		this.isFacingRight = true;
		this.isGrounded = true;
	}

	public bool IsFacingRight(){
		return this.isFacingRight;
	}

	public void SetFacingRight(bool isFacingRight){
		this.isFacingRight = isFacingRight;
	}

	public bool IsGrounded(){
		return this.isGrounded;
	}

	public void SetGrounded(bool isGrounded){
		this.isGrounded = isGrounded;
	}


}

public class MainCharacterMovement : MonoBehaviour {

	//Kuba:
	/*Jak jsme se dohodli pohyb bude na šipkách, skok šipkou nahoru*/


	//Rychlost pohybu
	public float speed =  1.0f;
	//Hrdina pro uchovani jeho stavu
	private Hero hero;
	//vyska skoku
	private int jumpHeight = 280;
	//komponenta pro detekci, zda se nachazim na zemi
	public Transform groundCheck;
	// radius kruhu ktery provede detekci
	float groundRadius = 0.1f;
	// maska urcujici co je zem
	public LayerMask whatIsGround;
	// promenna pro zjisteni zda je hrdina na zemi, 
	//Pozn. nebylo mozne primo ukladat do instance hero, hazelo to error :)
	bool isGrounded = false; //melo by byt implicitne false


	// Use this for initialization
	void Start () {
		//Vytvoreni hrdiny
		this.hero = new Hero ();
	}
	
	// Update is called once per frame
	void Update () {

		//left movement
		if(Input.GetKey(KeyCode.LeftArrow) ){
			transform.position -= Vector3.right * speed * Time.deltaTime;
			if(this.hero.IsFacingRight()){
				this.Flip();
			}
		}

		//right movement
		if(Input.GetKey(KeyCode.RightArrow) ){
			transform.position += Vector3.right * speed * Time.deltaTime;
			if(!this.hero.IsFacingRight()){
				this.Flip();
			}
		}

		isGrounded = (Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround));
		hero.SetGrounded (isGrounded);

		//jump movement
		if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){

			rigidbody2D.AddForce(new Vector3(0,jumpHeight,0));	

		}



	}


	void FixedUpdate(){

	}
	
	/**
	 * Metoda z jednoho tutorialu, mela by otocit postavu tak aby koukala doleva...
	 * Muze byt odstraneno pokud chceme aby postava jen couvala a neotacela se :) 
	 * 
	 **/

	void Flip(){ //fliping the world
		this.hero.SetFacingRight(!this.hero.IsFacingRight());
		Vector3 theScale = transform.localScale; //let me get local scale
		theScale.x *= -1;						// flip x axis	
		transform.localScale = theScale;		//get it back to local scale 
	}

}
