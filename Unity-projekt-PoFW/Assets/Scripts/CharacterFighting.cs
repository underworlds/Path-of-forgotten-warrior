using UnityEngine;
using System.Collections;


/**
 * This class should manage all about characters fighting
 */
public class CharacterFighting : MonoBehaviour {

	//Animator
	private Animator anim;
	
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(anim == null){
			print("There is no animator");
		}
	}
	
	// Update is called once per frame
	void Update () {

		//SHIELD COVER
		if(Input.GetKey(KeyCode.S) && (Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.001f )){
			anim.SetBool("shieldCover",true);
			//here should be implementation of shielded state of character
		}else{
			anim.SetBool("shieldCover",false);
		}


		//
		if(Input.GetKeyDown(KeyCode.A)){	
			anim.SetBool ("slash",true);
			//here shloud be impmentation of characters attack
		}


		if(Input.GetKeyUp(KeyCode.A)){
			anim.SetBool ("slash",false);

		}/*else{
			anim.SetBool ("slash",false);
		}*/
	}
}
