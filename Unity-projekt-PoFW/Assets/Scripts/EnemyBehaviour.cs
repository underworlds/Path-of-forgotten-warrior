   using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	/*
	 * Enemies tags + (number of lifes)
	 * Standard UNDEAD enemy: "Enemy" (1)
	 * Advanced UNDEAD enemy: "EnemyAdv" (2)
	 * Wraith enemy: "BigEnemy" (3)
	 * 
	 * 
"	 */

    //parametre na urcenie orientacie nepriatela
    public BoxCollider2D colider;
    bool isFacingRight = true;

    //parametry na urcenie akceleracie a rychlosti pohybu nepriatelov
    public float gravity = 2;
    public float speed = 8;
    public float acceleration = 30;
    private float targetSpeed = 1.5f;

	//sila utoku nepratel
	private const int DAMAGE_OF_UNDEAD = 10;

    //privatne premenne na chod nepriatela
    private float currentSpeed;


    private Vector2 charPosition = new Vector2(0, 0); //pozicie hrdiny
    public bool IsHeroOnDesk { set; private get; } //premenna ci je hrdina na doske
    
	//fields for attack
	private bool attacking = false;
	private GameObject character;
	private GameManager gameManager;
	private CharacterFighting charFight;
	private float timeToNextAttack = 0.0f;
	private const float UNDEAD_ATTACK_TIME = 1.5f;
	private bool enemyIsKilled = false;
	private int enemyLifes = -1;

	//Animation fields
	Animator anim;
    


    void Start()
    {
        IsHeroOnDesk = false;

		anim = GetComponent<Animator>();
		if(anim == null){
			print("There is no animator");
		}

		character =  GameObject.FindGameObjectWithTag("Character");
		if (character == null) {
			print ("Didnt find character ...well fuck");		
		}

		charFight = character.GetComponent<CharacterFighting>();

		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}

		//resolve how many lifes has enemy
		GetEnemyStartLifes();
    }

    void FixedUpdate(){
        //je hrdina na doske - aktivacia nepriatelov
        if (IsHeroOnDesk && !enemyIsKilled){
            
            //kontrola ci nepriatel sa neotocil
            int check = 0;
            
			if(Vector3.Distance(charPosition,this.transform.position) < 0.5f){//vzdalenost k utoku, zastav a zautoc
				attacking = true;
				StopMovement();
				Attack();
			}else{
				attacking = false;
				anim.SetBool("attack",false);
				character.GetComponent<Animator>().SetBool("hit", false);
			}


			//zistuje na ktorej strane je hrdina - ci je hrdina nalavo
            if (charPosition.x<this.rigidbody2D.position.x && attacking == false){
				//nastavenie rychlosti a animace pohybu
				anim.SetBool("walk",true);
				currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
                //pohyb
                transform.position -= Vector3.right * currentSpeed * Time.deltaTime;
                
				//otocenie ak je otoceny na zlu stranu
                if (!isFacingRight)
                    this.Flip();
				
                
            }else{
                //hrdina je napravo
                check++;
            }

            //zistuje ci je hrdina napravo
            if (charPosition.x > this.rigidbody2D.position.x && attacking == false) {
				//nastavenie rychlosti a animace pohybu
				anim.SetBool("walk",true);
				currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
                //pohyb
                transform.position += Vector3.right * currentSpeed * Time.deltaTime;
                
				//otocenie ak je na zlu stranu otoceny
                if (isFacingRight)
                    this.Flip();

			}else{
                //hrdina je nalavo
                check++;
            }

            //hrdina bol nalavo aj napravo pocas jedeho updatu - zastav nepriatela
            if (check == 2){
				StopMovement();
            }


		}else{//hrdina nieje na ploche - nulova rychlost
			StopMovement();
    	} 
	}
    


	//metoda zastaveni pohybu
	private void StopMovement(){
		anim.SetBool("walk",false);
		currentSpeed = 0.0f;
	}

	//metoda pro utok
	private void Attack(){
		anim.SetBool("attack",true);

		if( Vector3.Distance(charPosition,this.transform.position) < 0.5f && !charFight.isShieldDown){
			character.GetComponent<Animator>().SetBool("hit", true);
			//ZDE BUDE METODA, KTERA ROZHODNE JAKY HIT CHARACTER DOSTAL...
			gameManager.CharacterReceiveHitFromUndead();
		}
	}

	public void Hitted(){
		if(!enemyIsKilled){
			enemyLifes--;
			if(enemyLifes == 0){ //enemy ma alespon jeden zivot
				enemyIsKilled = true;
				character.GetComponent<Animator>().SetBool("hit", false);
				gameManager.CharacterKillEnemy();
				
				StartCoroutine(UndeadDie());
			}else{
				//enemy ma alespon jeden zivot
				//PREHREJ ANIMACI ZASAHU ENEMY
			}


		}
	}

	private IEnumerator UndeadDie(){
		anim.SetBool("die",true);
		yield return new WaitForSeconds(1.200f);
		Destroy(this.gameObject);
	}

    //sposob vypoctu rychlosti nepriatela
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    //otocenie
    void Flip()
    { 
        isFacingRight = (!isFacingRight);
        Vector3 theScale = transform.localScale; 
        theScale.x *= -1;						
        transform.localScale = theScale;		
    }
    //metoda na urcenie pozicie hrdinu
    public void setHeroPosition(Vector2 position)
    {
        if (IsHeroOnDesk)
        {
            Debug.Log("je na doske");
        }
        else
        {
            Debug.Log("nieje na doske");
        }
        
		if(!enemyIsKilled){
        	this.charPosition = position;
		}
    }




    //metoda na detekovanie hrdinu - moze nan zautocit
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Character"))
        {
           // Destroy(collision.gameObject);
        }

    }

	/**
	 * Tato metoda slouzi pri uvodnim spousteni scriptu k tomu,
	 * aby zjistila kolik ma dany enemy zivotu
	 * 
	 * Enemies tags + (number of lifes)
	 * Standard UNDEAD enemy: "Enemy" (1)
	 * Advanced UNDEAD enemy: "EnemyAdv" (2)
	 * Wraith enemy: "EnemyBig" (3)
	 */
	private void GetEnemyStartLifes(){
		string t = this.tag;
		//print("printing tag enemy: " + t);

		switch(t){
		case "Enemy":
			enemyLifes = 1;
			break;

		case "EnemyAdv":
			enemyLifes = 2;
			break;
		
		case "EnemyBig":
			enemyLifes = 3;
			break;
		}
	}

}
