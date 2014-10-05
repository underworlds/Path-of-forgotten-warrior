using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {

	//Kuba:
	/*Jak jsme se dohodli pohyb bude na šipkách, skok šipkou nahoru*/


	//Rychlost pohybu
	public float speed =  3.0f;

	//vyska skoku
	private int jumpHeight = 250;

	//SOUVISEJICI S KONTROLOU JSETLI JSME NA ZEMI NEBO NE .....ZATIM NEDORESENO
	public bool isGrounded = false; //melo by byt implicitne false
	//public RaycastHit hit = new RaycastHit();
	//public Transform groundCheck;
	//float groundRadius = 0.5f;
	//public LayerMask whatIsGround;



	//souvisi s metodou Flip()
	//private bool facingRight = true;





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//left movement
		if(Input.GetKey(KeyCode.LeftArrow) ){
			transform.position -= Vector3.right * speed * Time.deltaTime;

		}

		//right movement
		if(Input.GetKey(KeyCode.RightArrow) ){
			transform.position += Vector3.right * speed * Time.deltaTime;
			
		}

		//jump movement
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			/*
			if(isGrounded){
				Jump();
			}*/

			rigidbody2D.AddForce(new Vector3(0,jumpHeight,0));	

		}

	}



	void Jump(){

		isGrounded = false;
		print ("JUMP METHOD");
		rigidbody2D.AddForce(new Vector3(0,jumpHeight,0));	
	}

	void FixedUpdate(){
// ZDE SE SNAZIM RESIT JESTLI JE NAS CHARACTER NA ZEMI ....ALE PO VSECH MOZNYCH ZKOUSKACH SE MI TO NEPODARILO...
//		Ray ray = new Ray (this.transform.position, Vector3.down);
		/*
		bool hitground = Physics.Raycast (ray, out hit, 20.0f);
		if (hitground) {
			isGrounded = hit.distance <=10.0f;		
		
		}
		Debug.DrawRay (ray.origin, ray.direction,Color.yellow);
		Debug.Log ("Hit distance: "+hit.distance.ToString()+" Did hit: "+hitground.ToString());

		*/

/*
	   isGrounded = Physics.Raycast(transform.position, -Vector3.up,hit);


		Debug.DrawRay (transform.position, -transform.up * 2.0f, Color.green);

		if (Physics.Raycast (transform.position, Vector3.right, 150.0f)) {

			print ("HIT right");
		}

		print ("Grounded IS " + isGrounded);

*/
	}




	/**
	 * Metoda z jednoho tutorialu, mela by otocit postavu tak aby koukala doleva...
	 * Muze byt odstraneno pokud chceme aby postava jen couvala a neotacela se :) 
	 * 
	 **/


	/*
	void Flip(){ //fliping the world
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale; //let me get local scale
		theScale.x *= -1;						// flip x axis	
		transform.localScale = theScale;		//get it back to local scale 
	}*/

}
