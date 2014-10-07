using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	void OnTriggerEnter2D(){
		print ("CHANGE SCENE");
		Application.LoadLevel("Test-scene");	
	}

}
