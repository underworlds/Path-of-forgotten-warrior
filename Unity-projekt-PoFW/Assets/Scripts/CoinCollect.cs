using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {


	public GameManager gameManager;


	void OnTriggerEnter2D(Collider2D obj){
		//print ("Collision detected");
		if (obj.tag == "Coin") {
			//print("Tag confirmed");
			gameManager.addCoin(1);
			Destroy (obj.gameObject);
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
