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
	private const float THROW_DISTANCE = 5.0f;
	private const float SLASH_DISTANCE = 0.3f;
	public LayerMask whatToHit;
	public Transform spearPrefab;
	private MainCharacterMovement mcm;
	public bool isShieldDown = false;

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
			isShieldDown = true;

		}else{
			isShieldDown = false;
			anim.SetBool("shieldCover",false);
		}


		//SLASH
		if(Input.GetKeyDown(KeyCode.A)){	
			anim.SetBool ("slash",true);

			int isFR = IsFRtoInt(GetComponent<MainCharacterMovement>().isFacingRight);
			Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
			Vector2 throwDirection = (new Vector2(firePoint.position.x+(isFR*10.0f), firePoint.position.y) - firePointPosition);

			RaycastHit2D hit = Physics2D.Raycast(firePointPosition,throwDirection, SLASH_DISTANCE);
			//Debug.DrawLine(firePointPosition, (new Vector2(firePoint.position.x+(isFR*SLASH_DISTANCE), firePoint.position.y)));

			if(hit.collider != null){ 
				if(hit.collider.tag == "Enemy" ){
					hit.collider.gameObject.GetComponent<EnemyBehaviour>().Killed();
				}		
			}else{
				//print ("...Collider of hit was null");
			}

		}

		if(Input.GetKeyUp(KeyCode.A)){
			anim.SetBool ("slash",false);

		}

		//THROW
		if(Input.GetKeyDown(KeyCode.D) && (mcm.isGrounded)){	
			anim.SetBool ("throw",true);

			//we have to wait for throw animation before throw
			StartCoroutine(ThrowSpear());
		}else{
			anim.SetBool ("throw",false);
		}
	}

	private IEnumerator ThrowSpear(){
		int isFR = IsFRtoInt(GetComponent<MainCharacterMovement>().isFacingRight);

		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		Vector2 throwDirection = (new Vector2(firePoint.position.x+(isFR*10.0f), firePoint.position.y) - firePointPosition);
		//print (throwDirection);
		anim.SetBool ("throw",true);

		yield return new WaitForSeconds(0.520f);

		// cast ray to see if we hit enemy
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,throwDirection, THROW_DISTANCE, whatToHit);
		//show user the spear and do some magic
		ThrowEffect();
		//just for debugging purposes	
		//Debug.DrawLine(firePointPosition, (new Vector2(firePoint.position.x+(isFR*THROW_DISTANCE), firePoint.position.y)));

		if(hit.collider != null){ 

			if(hit.collider.tag == "Enemy" ){
				hit.collider.gameObject.GetComponent<EnemyBehaviour>().Killed();
			}		
		}else{
			//print ("...Collider of hit was null");
		}

	}



	void ThrowEffect(){
		//spawning of spear
		Instantiate(spearPrefab, firePoint.position, firePoint.rotation);		
	}

	private int IsFRtoInt(bool iFR){
		if(iFR){
			return 1;
		}else{
			return -1;
		}
	}

}
