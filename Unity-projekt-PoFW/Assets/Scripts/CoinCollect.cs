using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "Character") {
			print ("pridej minci");		
		}
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
