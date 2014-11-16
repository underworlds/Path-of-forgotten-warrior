   using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

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


    private Vector2 position = new Vector2(0, 0); //pozicie hrdiny
    public bool IsHeroOnDesk { set; private get; } //premenna ci je hrdina na doske
    
	//fields for attack
	private bool attacking = false;
	private GameObject character;
	private GameManager gameManager;
	private CharacterFighting charFight;
	private float timeToNextAttack;
	private const float UNDEAD_ATTACK_TIME = 3.0f;

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


		timeToNextAttack = Time.time;

    }

    void Update(){
        //je hrdina na doske - aktivacia nepriatelov
        if (IsHeroOnDesk){
            
            //kontrola ci nepriatel sa neotocil
            int check = 0;
            
			if(Vector3.Distance(position,this.transform.position) < 0.5f){//vzdalenost k utoku, zastav a zautoc
				attacking = true;
				StopMovement();
				Attack();
			}else{
				attacking = false;
				anim.SetBool("attack",false);
				character.GetComponent<Animator>().SetBool("hit", false);
			}


			//zistuje na ktorej strane je hrdina - ci je hrdina nalavo
            if (position.x<this.rigidbody2D.position.x && attacking == false){
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
            if (position.x > this.rigidbody2D.position.x && attacking == false) {
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
    


	//metoda zastaveni pohyby
	private void StopMovement(){
		anim.SetBool("walk",false);
		currentSpeed = 0.0f;
		
	}

	//metoda pro utok
	private void Attack(){
		print ("attack");
		anim.SetBool("attack",true);

		if( Vector3.Distance(position,this.transform.position) < 0.5f && !charFight.isShieldDown){
	
			character.GetComponent<Animator>().SetBool("hit", true);

			if((timeToNextAttack < Time.time)){

				timeToNextAttack += UNDEAD_ATTACK_TIME; 
				gameManager.CharacterReceiveHitFromUndead();
			}


		}else{

		}
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
        
        this.position = position;
    }


    //metoda na detekovanie hrdinu - moze nan zautocit
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Character"))
        {
           // Destroy(collision.gameObject);
        }

    }
    
}
