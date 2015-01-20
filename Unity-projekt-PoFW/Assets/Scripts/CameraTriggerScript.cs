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
		if(obj.tag == "Character"){

			if (this.tag == "CamTrig1down") {//CAMERA DOWN
				camController.setLookTransformCons(-1.0f);
			}
			if (this.tag == "CamTrig2zero") {//CAMERA NORMAL
				camController.setLookTransformCons(0.0f);
			}
			if (this.tag == "CamTrig3up") {//CAMERA UP
				camController.setLookTransformCons(1.0f);
			}
			if (this.tag == "CamTrig4down2x") {//CAMERA UP
				camController.setLookTransformCons(-1.5f);
		
			}
		}


	}
}
