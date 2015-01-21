using UnityEngine;
using System.Collections;



/**READ ME !!!!!!
 * 
 * To work dialogs properly, you have to make DialogTrigger and dialogSprite in scene
 * Then you have manually set size of dialogSprites array and you have tu add correct sprite to each element.
 * And you have to add dialogFrame to public field GameObject.
 * Once character entered the trigger the firts sprite is shown. At SPACE (next sprite) and at S (skip all).
 * 
 */


public class DialogScript : MonoBehaviour {

	public GameObject character;

	public GameObject dialogFrame; 
	public Sprite[] dialogsSprites;

	public bool thereIsSomethingNextToDialogFrame =  false;

	private bool startDialogs = false;
	private bool triggerhit = false;

	private Animator anim;

	private int iter = -1; 
	private int prevIter = -1;

	private const float dialogFrameOffset = 2.2f;
	private const float wraithFrameOffset = 5.2f;

	private Transform wraith; 

	// Use this for initialization
	void Start () {
		//print("STARTING METHOD OF DIALOGS");


		character = GameObject.FindGameObjectWithTag("Character");
		if(character == null){
			print ("There is no character");
		}

		if(GameObject.FindGameObjectWithTag("EnemyBig") != null){
			wraith = GameObject.FindGameObjectWithTag("EnemyBig").transform;
			//print("Find wraith");
		}else{
			wraith = null;
			print("DID not find wraith");
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(startDialogs){

			if(Input.GetKeyDown(KeyCode.Space)){
				//print("Space hitted");
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



	//do some javadoc here
	void OnTriggerEnter2D(Collider2D obj){
		print("HIT TRIGER"+ obj.tag);
		if (obj.gameObject.tag.Equals("Character") && !triggerhit){

			//disable moving of character
			character.GetComponent<MainCharacterMovement>().enabled = false;
			character.GetComponent<CharacterFighting>().enabled = false;

			//read chracters position
			float charX  = character.transform.position.x;
			float charY  = character.transform.position.y;

			//get animator of character
			anim = character.GetComponent<Animator>();
			//stop all animations and run Idle animation
			ClearAnimator();

			//set dialogFrame position using characters position
			dialogFrame.transform.position = new Vector3(charX+dialogFrameOffset,charY+0.4f,dialogFrame.transform.position.z);

			//set position of things behind dialogFrame using characters position
			setWhatIsNextToFrame(charX);

			//start the update code
			triggerhit = true;	//so there will be no trigger entries
			startDialogs = true; 
			iter++; //set iterator to 0
		}

	}

	//this code show him last dialog card (which is empty)
	//makes class of movement and fighting enabled  and then destroy itself
	private void endDialogs(){
		//print("Set dialog to empty one");
		dialogFrame.GetComponent<SpriteRenderer>().sprite = dialogsSprites[dialogsSprites.Length-1];
		//print("Release animator");
		anim.SetBool("Idle",false);
		//print("Moving");
		character.GetComponent<MainCharacterMovement>().enabled = true;
		//print ("Fight");
		character.GetComponent<CharacterFighting>().enabled = true;
		
		//enable scripts for things next to frame
		if(wraith != null){
			wraith.GetComponent<EnemyBehaviour>().enabled = true;
		}
		
		
		//print ("Destroy trigger");
		Destroy (this.gameObject);
		//print ("destroy dialog");
		Destroy (dialogFrame);
	}







	//stop all moving of chracter used before disabling moving scripts
	private void ClearAnimator(){
		anim.SetBool("Idle",true);
		anim.SetBool("Ground",true);
		anim.SetBool("shieldCover",false);
		anim.SetBool("slash",false);
		anim.SetBool("throw",false);
		anim.SetBool("die",false);
		anim.SetFloat("vSpeed",0.0f);
		anim.SetFloat("Speed",0.0f);
	}

	private void setWhatIsNextToFrame(float charX){
		if(wraith != null && thereIsSomethingNextToDialogFrame){
			wraith.position = new Vector3(charX+wraithFrameOffset,wraith.transform.position.y,wraith.transform.position.z);

			//turn off wraiths enemy behaviour
			wraith.GetComponent<EnemyBehaviour>().enabled = false;
		}
	}

	//this function is used only in LVL01RND03 when the chraracter kills wraith

	public void ReplacementForOnTriggerEntry(){
		if (!triggerhit){

			//read chracters position
			float charX  = character.transform.position.x;
			//set dialogFrame position using characters position
			dialogFrame.transform.position = new Vector3(charX+dialogFrameOffset,dialogFrame.transform.position.y,dialogFrame.transform.position.z);
			
			//set position of things behind dialogFrame using characters position
			setWhatIsNextToFrame(charX);
			
			//get animator of character
			anim = character.GetComponent<Animator>();
			//stop all animations and run Idle animation
			ClearAnimator();
			
			//disable moving of character
			character.GetComponent<MainCharacterMovement>().enabled = false;
			character.GetComponent<CharacterFighting>().enabled = false;
			
			//start the update code
			triggerhit = true;	//so there will be no trigger entries
			startDialogs = true; 
			iter++; //set iterator to 0
		}
	}

}