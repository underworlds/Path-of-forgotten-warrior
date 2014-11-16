using UnityEngine;
using System.Collections;

public class DialogScript : MonoBehaviour {
	GameObject dialogFrame; 
	public Sprite[] dialogsSprites = new Sprite[11];

	bool startDialogs = false;

	int iterator = 0; 
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
			dialogFrame.GetComponent<SpriteRenderer>().sprite = dialogsSprites[iterator];

			if(Input.GetKeyDown (KeyCode.Space)){
				if(iterator == dialogsSprites.Length-1){
					startDialogs = false;
				}else{
					iterator++;
				}

			}
		}
	}

	void OnTriggerEnter2D(Collider2D obj){//hero falls from some platform... .
		if (obj.gameObject.tag.Equals("Character")){
			startDialogs = true;
		}
	}
}
