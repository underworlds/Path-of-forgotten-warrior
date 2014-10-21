using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	private Transform character;
	private float smoothRate = 0.5f;
	private Vector2 velocity;
	private float lookTransformConst = 0.0f;


	// Use this for initialization
	void Start () {

		character =  GameObject.FindGameObjectWithTag("Character").transform;
		if (character == null) {
			print ("Didnt find character ...well fuck");		
		} 

		velocity = new Vector2(0.5f,0.5f);
	}

	void Update(){
		//print ("Camera window size is X:"+camera.pixelWidth+" Y:"+camera.pixelHeight);
		Vector2 newPos2D = Vector2.zero;
		newPos2D.x = Mathf.SmoothDamp (this.transform.position.x, character.transform.position.x, ref velocity.x, smoothRate);
		newPos2D.y = Mathf.SmoothDamp (this.transform.position.y, character.transform.position.y + lookTransformConst , ref velocity.y, smoothRate);

		//UPDATES CAMERA TO OUR CHARACTERS LOCATION
		Vector3 newPos = new Vector3 (newPos2D.x, newPos2D.y, this.transform.position.z);
		this.transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
	}

	public void setLookTransformCons(float newLookTransformConst){
		print("Const is goint to be " + newLookTransformConst); 
		lookTransformConst = newLookTransformConst;
	}
}
