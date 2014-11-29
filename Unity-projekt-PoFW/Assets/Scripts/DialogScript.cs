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

	public GameObject dialogFrame; 
	public Sprite[] dialogsSprites;

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


		dialogFrame = GameObject.Find("dialog1");
		if(dialogFrame == null){
			print ("There is no dialogFrame");
		}

		if(GameObject.Find("wraith") != null){
			wraith = GameObject.Find("wraith").transform;
		}else{
			wraith = null;
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

	//this code show him last dialog card (which is empty)
	//makes class of movement and fighting enabled  and then destroy itself
	private void endDialogs(){
		//print("Set dialog to empty one");
		dialogFrame.GetComponent<SpriteRenderer>().sprite = dialogsSprites[dialogsSprites.Length-1];
		//print("Release animator");
		anim.SetBool("Idle",false);
		//print("Moving");
		GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterMovement>().enabled = true;
		//print ("Fight");
		GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterFighting>().enabled = true;
		//print ("Destroy trigger");
		Destroy (this.gameObject);
		//print ("destroy dialog");
		Destroy (dialogFrame);
	}

	//do some javadoc here
	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag.Equals("Character") && !triggerhit){
			//find character and writh game objects
			GameObject character = obj.gameObject;



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
			GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterMovement>().enabled = false;
			GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterFighting>().enabled = false;

			//start the update code
			triggerhit = true;	//so there will be no trigger entries
			startDialogs = true; 
			iter++; //set iterator to 0
		}

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
		if(wraith != null){
			wraith.position = new Vector3(charX+wraithFrameOffset,wraith.transform.position.y,wraith.transform.position.z);
		}
	}

}