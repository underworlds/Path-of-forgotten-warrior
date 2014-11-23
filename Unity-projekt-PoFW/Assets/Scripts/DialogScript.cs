using UnityEngine;
using System.Collections;



/**READ ME !!!!!!
 * 
 * To work dialogs properly, you have to make DialogTrigger and dialogSprite in scene
 * Then you have manually set size of dialogSprites array and you have tu add correct sprite to each element.
 * Once character entered the trigger the firts sprite is shown. It reacht at SPACE (next sprite) and S (skip all).
 * 
 */


public class DialogScript : MonoBehaviour {
	GameObject dialogFrame; 
	public Sprite[] dialogsSprites;
	bool startDialogs = false;

	int iter = -1; 
	int prevIter = -1;
	// Use this for initialization
	void Start () {

		dialogFrame = GameObject.Find("dialog1");
		if(dialogFrame == null){
			print ("There is no dialogFrame");
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(startDialogs){

			if(Input.GetKeyDown(KeyCode.Space)){
				iter++;
			}

			if(iter > prevIter){  //iterator has changed
				//change sprite
				if(iter == (dialogsSprites.Length-1) ){
					endDialogs();
				}else{
					dialogFrame.GetComponent<SpriteRenderer>().sprite = dialogsSprites[iter];
				}
			}

			//print("Iterator " + iter);

			if(Input.GetKey(KeyCode.S)){// key S to skip dialogues,

				endDialogs ();
			}
		}
	}

	//this code show him last dialog card (which is empty)
	//makes class of movement and fighting enabled  and then destroy itself
	private void endDialogs(){
		dialogFrame.GetComponent<SpriteRenderer>().sprite = dialogsSprites[dialogsSprites.Length-1];

		//print("Moving");
		GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterMovement>().enabled = true;
		//print ("Fight");
		GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterFighting>().enabled = true;
		//print ("Destroy");
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D obj){

		if (obj.gameObject.tag.Equals("Character")){
			startDialogs = true;
			GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterMovement>().enabled = false;
			GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterFighting>().enabled = false;
			iter++; //set iterator to 0
		}

	}


}