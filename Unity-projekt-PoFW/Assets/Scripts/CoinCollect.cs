﻿using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {


	private GameManager gameManager;


	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "Coin") {
			gameManager.AddCoin();
			Destroy (obj.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}
	}
}


