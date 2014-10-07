using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	private int coins;
	private int health;

	void AddCoin(){
		coins += 1;
		print ("Coins " + coins);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
