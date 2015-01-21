using UnityEngine;
using System.Collections;


public class RestartTrigger : MonoBehaviour {

	private GameManager gameManager;
    private GameObject character;
    

	//COLISION WITH RESTART FLOOR
    void OnTriggerEnter2D(Collider2D obj){//hero falls from some platform... .
        
        
        if (obj.gameObject.tag.Equals("Character")){
			character = GameObject.FindGameObjectWithTag("Character");
            character.GetComponent<AudioForHero>().deathSound();
			gameManager.killCharacter();
        }

    }

	//COLISION WITH TRAPS
    //zisti ci sa plosiny dotkol alebo nie
    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.tag.Equals("Character")){
			character = GameObject.FindGameObjectWithTag("Character");
            //character.GetComponent<AudioForHero>().deathSound();
			gameManager.killCharacter();
        }
    }



//-------------------INITIALIZATION CODE-----------------

	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
