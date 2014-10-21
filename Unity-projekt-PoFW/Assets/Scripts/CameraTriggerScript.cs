using UnityEngine;
using System.Collections;

public class CameraTriggerScript : MonoBehaviour {

	private CameraController camController;

	// Use this for initialization
	void Start () {
		camController = GameObject.FindObjectOfType<CameraController>();
		if (camController == null) {
			print ("Didnt find cameraController ...well fuck");		
		}
	}

	void OnTriggerEnter2D(Collider2D obj){

		if (this.tag == "CamTrig1down") {
			camController.setLookTransformCons(-0.03f);
		}
		if (this.tag == "CamTrig2zero") {
			camController.setLookTransformCons(0.0f);
		}
		if (this.tag == "CamTrig3up") {
			camController.setLookTransformCons(0.03f);
		}

	}
}
