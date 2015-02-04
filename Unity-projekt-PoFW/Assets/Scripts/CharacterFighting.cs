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
	public bool isShieldDown;
    public bool isTimeToThrowSpear;

	private string tagOfHitCollider = "";

	// Use this for initialization
	void Start () {
        isShieldDown = false;
        isTimeToThrowSpear = true;
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
				string HCT = hit.collider.tag;
				if(HCT == "Enemy" || HCT == "EnemyAdv" || HCT == "EnemyBig" || HCT == "Kerberos" ){
					hit.collider.gameObject.GetComponent<EnemyBehaviour>().Hit();
				}		
			}else{
				//print ("...Collider of hit was null");
			}

		}

		if(Input.GetKeyUp(KeyCode.A)){
			anim.SetBool ("slash",false);

		}

		//THROW
		if(Input.GetKeyDown(KeyCode.D) && (mcm.isGrounded) && isTimeToThrowSpear /*&& (mcm.move == 0.0f)*/){	
			mcm.canMove = false;
			anim.SetBool ("throw",true);

			//we have to wait for throw animation before throw
			StartCoroutine(ThrowSpear());
		}else{
			anim.SetBool ("throw",false);
		}
	}



	private IEnumerator ThrowSpear(){

		anim.SetBool ("throw",true);
        isTimeToThrowSpear = false;
		yield return new WaitForSeconds(0.520f);
		
		//show user the spear and do some magic
		ThrowEffect();

		mcm.canMove = true;

		/* THIS IS NOW SOLVED IN MOVESPEAR SCRIPT
		if(hit.collider != null){ 

			if(hit.collider.tag == "Enemy" || hit.collider.tag == "EnemyAdv" || hit.collider.tag == "EnemyBig" ){
				hit.collider.gameObject.GetComponent<EnemyBehaviour>().Hit();
			}		
		}else{
			//print ("...Collider of hit was null");
		}*/

        yield return new WaitForSeconds(1f);
        isTimeToThrowSpear = true;

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
