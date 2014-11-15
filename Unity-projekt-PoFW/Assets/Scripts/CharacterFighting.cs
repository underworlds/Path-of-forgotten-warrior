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
		if(Input.GetKey(KeyCode.S) && (Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.001f )){
			anim.SetBool("shieldCover",true);
		}else{
			anim.SetBool("shieldCover",false);
		}
	}
}
