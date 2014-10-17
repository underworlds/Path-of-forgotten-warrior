using UnityEngine;
using System.Collections;


public class RestartTrigger : MonoBehaviour {

	public Transform character;
	public GameManager gameManager;

	private Vector3 characterStartPosition;

	void OnTriggerEnter2D(Collider2D obj){//hero falls from some platform... 
		//get last number of hero's lifes from gameManager
		int lifesOfCharacter = gameManager.GetLifes ();
		//int lifesOfCharacter = 3;

		if (lifesOfCharacter > 1) {//hero had 2 or 3 lifes left
			lifesOfCharacter -= 1; // now hero has -1 life
			gameManager.SetLifes(lifesOfCharacter); //set it to gameManager
			//initialize new round 
			obj.transform.position = characterStartPosition;//set hero to startposition of the round
		} else {//hero had only 1 life left 
			//...he dies :( 
			//return hero to first round of this level

		}


	}

	// Use this for initialization
	void Start () {
		characterStartPosition = character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeRound(){
		//MAY BE THIS METHOD WILL BE IN GAME MANAGER ...NOT SOLVED YET
		//here should be initialized all coins, enemies and other round related things
		//it is due to round refreshment

	}
}
