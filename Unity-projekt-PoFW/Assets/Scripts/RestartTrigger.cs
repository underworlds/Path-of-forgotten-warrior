using UnityEngine;
using System.Collections;


public class RestartTrigger : MonoBehaviour {

	public Transform character;
	public GameManager gameManager;

	private Vector3 characterStartPosition;


	void OnTriggerEnter2D(Collider2D obj){//hero falls from some platform... .

		//get last number of hero's lifes from gameManager
		int lifesOfCharacter = gameManager.GetLifes ();

		if (lifesOfCharacter > 1) {//hero had 2 or 3 lifes left

			gameManager.RemoveOneLife();

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
		characterStartPosition = character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
