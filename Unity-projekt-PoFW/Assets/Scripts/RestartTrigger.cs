using UnityEngine;
using System.Collections;

public class RestartTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D obj){
		print ("YOU FAIL...");
		obj.transform.position = new Vector3 (-16.0f, 7.0f, 0.0f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
