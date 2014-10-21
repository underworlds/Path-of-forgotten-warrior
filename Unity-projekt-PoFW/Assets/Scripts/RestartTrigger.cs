using UnityEngine;
using System.Collections;


public class RestartTrigger : MonoBehaviour {

	private Transform character;
	private GameManager gameManager;

	private Vector3 characterStartPosition;


	void OnTriggerEnter2D(Collider2D obj){//hero falls from some platform... .

		//get last number of hero's lifes from gameManager
		int lifesOfCharacter = gameManager.GetLifes ();

		if (lifesOfCharacter > 1) {//hero had 2 or 3 lifes left

			//Reaction of GameManager
			gameManager.RemoveOneLife();
			gameManager.ResetCollectedValues();

			//Restart LEVEL
			Application.LoadLevel(Application.loadedLevel);

		} else {//hero had only 1 life left 
			//...he dies :( 
			//return hero to first round of this level
			print("You died...HA HA HA. \nGAME OVER");

		}


	}

	// Use this for initialization
	void Start () {

		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}

		character =  GameObject.FindGameObjectWithTag("Character").transform;
		if (character == null) {
			print ("Didnt find character ...well fuck");		
		} 

		characterStartPosition = character.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
