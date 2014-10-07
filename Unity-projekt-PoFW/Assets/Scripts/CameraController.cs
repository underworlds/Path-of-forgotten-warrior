using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Transform character;

	Vector3 direction;


	// Use this for initialization
	void Start () {
		direction = this.transform.position - character.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (this.transform.position.y > -13) {
						transform.position = character.transform.position + direction;
		} else {
			print("Pres R to reload.");	

			if(Input.GetKeyDown(KeyCode.R)){

				transform.position = character.transform.position;
			}

		}
	}
}
