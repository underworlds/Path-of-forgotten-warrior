using UnityEngine;
using System.Collections;

public class MoveSpear : MonoBehaviour {

	private const float MOVE_SPEED	 = 5.0f;
	//private Transform character;
	// Use this for initialization
	void Start (){

	//	character =  GameObject.FindGameObjectWithTag("Character").transform;
	//	if (character == null) {
	//		print ("Didnt find character ...well fuck");		
	//	}  	
	}
	
	// Update is called once per frame
	void Update () {
		//print (" vector is " + transform.right.x + " / " + transform.right.y);
		//rigidbody2D.AddForce(new Vector2(1.0f,1.0f) * MOVE_SPEED);
		transform.Translate(Vector3.right * Time.deltaTime * MOVE_SPEED);
		//destroy object after 1 second... proc jsem tohle kurva nepouzil u te die animace se radeji neptam :D
		Destroy (this.gameObject,0.5f);
	}

/*	void OnCollisionEnter2D(Collision2D collision){
		if (!(collision.gameObject.tag.Equals("Character")))
		{
			Destroy(this.gameObject, 0.5f);
		}


	}
*/

}
