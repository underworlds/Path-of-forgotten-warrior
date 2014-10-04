using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {

	//Kuba:
	/*Jak jsme se dohodli pohyb bude na šipkách, skok šipkou nahoru*/


	bool facingRight = true;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * 5.0f , rigidbody2D.velocity.y);
		 


		if(Input.GetKeyDown(KeyCode.UpArrow)){

			rigidbody2D.AddForce(new Vector2(0,250f));

		}


		if (move > 0 && !facingRight) {
			Flip();		
		}
		else if(move < 0 && facingRight){
			Flip ();
		}
	}

	/**
	 * Metoda z jednoho tutorialu, mela by otocit postavu tak aby koukala doleva...
	 * Muze byt odstraneno pokud chceme aby postava jen couvala a neotacela se :) 
	 * 
	 **/
	void Flip(){ //fliping the world
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale; //let me get local scale
		theScale.x *= -1;						// flip x axis	
		transform.localScale = theScale;		//get it back to local scale 
	}

}
