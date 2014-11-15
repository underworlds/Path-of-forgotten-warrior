using UnityEngine;
using System.Collections;


/**
 * This class should manage all about characters fighting
 */
public class CharacterFighting : MonoBehaviour {
	//tlacitka pro souboje A-  utok mecem, S-kryti stitem, D - hod kopim
	//Animator
	private Animator anim;

	//THROWING SPEAR FIELDS
	private Transform firePoint;
	private const float THROW_DISTANCE = 10.0f;
	public LayerMask whatToHit;
	public Transform spearPrefab;
	private MainCharacterMovement mcm;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(anim == null){
			print("There is no animator");
		}

		firePoint = this.transform.FindChild("FirePoint");
		if(firePoint == null){
			print ("Didnt find fire point ... well fuck!");

		}

		mcm = GetComponent<MainCharacterMovement>();
		if(mcm == null){
			print ("Didnt find MainCharacterMovement ... well fuck!");
			
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


		//SLASH
		if(Input.GetKeyDown(KeyCode.A)){	
			anim.SetBool ("slash",true);
			//here shloud be impmentation of characters attack
		}
		if(Input.GetKeyUp(KeyCode.A)){
			anim.SetBool ("slash",false);

		}

		//THROW
		if(Input.GetKeyDown(KeyCode.D) && (mcm.isGrounded)){	
			anim.SetBool ("throw",true);
			//here shloud be impmentation of characters attack
			//we have to wait for throw animation before throw
			StartCoroutine(ThrowSpear());
		}
		if(Input.GetKeyUp(KeyCode.D)){
			anim.SetBool ("throw",false);
		}
	}

	private IEnumerator ThrowSpear(){
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		Vector2 throwDirection = (new Vector2(firePoint.position.x+10.0f, firePoint.position.y) - firePointPosition);
		anim.SetBool ("throw",true);

		yield return new WaitForSeconds(0.560f);

		// cast ray to see if we hit enemy
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,throwDirection, THROW_DISTANCE, whatToHit);
		//show user the spear and do some magic
		ThrowEffect();
		//just for debugging purposes	
		Debug.DrawLine(firePointPosition, (new Vector2(firePoint.position.x+THROW_DISTANCE, firePoint.position.y)));

		//if(hit.collider.tag != "Enemy" ){

		//}

	}

	void ThrowEffect(){
		//spawning of spear
		Instantiate(spearPrefab, firePoint.position, firePoint.rotation);		
	}
}
