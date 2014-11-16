using UnityEngine;
using System.Collections;


public class RestartTrigger : MonoBehaviour {

	//private Transform character;
	private GameManager gameManager;
	//private Animator anim;




	//COLISION WITH RESTART FLOOR
    void OnTriggerEnter2D(Collider2D obj){//hero falls from some platform... .

        //get last number of hero's lifes from gameManager
        if (obj.gameObject.tag.Equals("Character")){
			//reaguje na pocet zivotu charactera
			gameManager.killCharacter();
        }
    }

	//COLISION WITH TRAPS
    //zisti ci sa plosiny dotkol alebo nie
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Character"))
        {
			gameManager.killCharacter();
        }
    }
	/*
	void ResolveCharacterLifeCount(){
		//kontroluje kto sa dotkol danej plosiny 
		int lifesOfCharacter = gameManager.GetLifes();
		
		if (lifesOfCharacter > 1)
		{//hero had 2 or 3 lifes left
			
			//Reaction of GameManager			
			gameManager.killCharacter();
			
		}
		else
		{//hero had only 1 life left 
			gameManager.RemoveOneLife();
			gameManager.killCharacter();
		}
	}

	//here the waitforseconds is exactly the length of animaton
	//if you move with animation sample you have to change this

	//is implemented via gamemanager

	private IEnumerator Die(){
		anim.SetBool("die",true);
		yield return new WaitForSeconds(1.273f);
		Destroy(character.gameObject);
		gameManager.TotalReset();

		//...should be returned to GAME OVER scene and then to MAIN MENU scene
		Application.LoadLevel("Lvl1-round1");
	} 	

*/


//-------------------INITIALIZATION CODE-----------------

	void Start () {

		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}
		/*
		character =  GameObject.FindGameObjectWithTag("Character").transform;
		if (character == null) {
			print ("Didnt find character ...well fuck");		
		} */
		/*
		anim =  GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>();
		if (character == null) {
			print ("Didnt find animator ...well fuck");		
		} */
		//characterStartPosition = character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
