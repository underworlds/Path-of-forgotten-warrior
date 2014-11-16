﻿using UnityEngine;
using System.Collections;

public class MoveSpear : MonoBehaviour {

	private const float MOVE_SPEED	 = 5.0f;
	private Transform character;
	private MainCharacterMovement mcm;

	private int isFacingRight = 1;


	// Use this for initialization
	void Start (){

		mcm = GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterMovement>();
		if (mcm == null) {
			print ("Didnt find mcm component ...well fuck");		
		}  
		//asking characters param isFacingRight if true or false
		//and do this only once, in START()
		SetIntIsFacingRight(mcm.isFacingRight);
	}
	
	// Update is called once per frame
	void Update () {

		//set rotation of sprite correctly
		Quaternion rotationOfSpear = transform.rotation;
		rotationOfSpear.y = 90 - (isFacingRight * 90); //it will be 180 for isNotFacingRight and 0 for isFacingRight
		transform.rotation = rotationOfSpear; 

		//move sprite
		transform.Translate(isFacingRight*transform.right * Time.deltaTime * MOVE_SPEED);

		//destroy  after 1 second
		Destroy (this.gameObject,0.5f);
	}

	void OnCollisionEnter2D(Collision2D collision){
		print ("Spear hit something");
		Destroy(this.gameObject);
	}

	void SetIntIsFacingRight(bool isFR){
		if(isFR){
			isFacingRight = 1;
		}else{
			isFacingRight = -1;
		}

	}

/*	void OnCollisionEnter2D(Collision2D collision){
		if (!(collision.gameObject.tag.Equals("Character")))
		{
			Destroy(this.gameObject, 0.5f);
		}


	}
*/

}
