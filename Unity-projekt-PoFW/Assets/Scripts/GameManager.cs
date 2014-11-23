using UnityEngine;
using System.Collections;

/**
 *Trida by mela hlidat prubeh hry. Zde pripadne doplnujte seznam co vse ma trida nastarosti (do zavorky kdo pridal):
 * - hlidani poctu zivotu (Kuba)
 * - hlidani poctu pozbiranych minci (Kuba)
 * - hlidani poctu bodu (Kuba) / vychazim z GDD
 * - hlidani health pointu 
 * -
 */


public class GameManager : MonoBehaviour {

	private Transform camera;
	private GUIText scoreSheetText;
	private GameObject character;
	private Animator anim;

	private bool load = true;
	private int loadCounter = 0;

	//FIGHTING VALUES
	private float damage = 0.2f;
	private float cumulateDamage = 0.0f;
	private bool isDead = false;

	//CHARACTERS VALUES
	private	static int lifes;
	private static int coins;
	private static int points;
	private static int hp; //healthpoints

	//CHECKPOINTS VALUES 
	private static int cpCoins;
	private static int cpPoints;
	//private static int cpCoins; ...will be implemented


	// CONSTANT VALUES ...WILL BE ALLWAYS UPPERCASE
	private const int STARTING_NUMBER_OF_LIFES = 3;
	private const int STARTING_NUMBER_OF_COINS = 0;
	private const int STARTING_NUMBER_OF_POINTS = 0;
	private const int STARTING_NUMBER_OF_HP = 100;

	private const int POINTS_PER_COIN = 10;
	private const int POINTS_PER_STD_ENEMY = 20; //should be multiplied by level numer (eg 20 x 1...(level 1))

	//strings to adding points
	private const string COIN_STR = "coin";
	private const string STANDART_ENEMY_STR = "enemy";
	//...

	//SINGLETON CODE
	private static GameManager _instance;
	public static GameManager instance{
		get{
			if(_instance == null){
				_instance = GameObject.FindObjectOfType<GameManager>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);

			}

			return _instance;
		}

	}



	void Awake(){

		if (_instance == null) {
			//If I am first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad (this);

		} else {
			//If a Singleton alreadz exists and zou find
			//another reference in scene, destroy it!
			if(this != _instance){
				Destroy(this.gameObject);
			}


		}

	}

	//END OF SINGLETONE CODE ....INSPIRED FROM: http://unitypatterns.com/singletons/


	void Start () {
		lifes = STARTING_NUMBER_OF_LIFES;
		coins = STARTING_NUMBER_OF_COINS;
		points = STARTING_NUMBER_OF_POINTS;
		hp = STARTING_NUMBER_OF_HP;

		cpCoins = STARTING_NUMBER_OF_COINS;
		cpPoints = STARTING_NUMBER_OF_POINTS;
	
	}
	
	// Update is called once per frame
	void Update () {
		TextUpdate ();

		if(load){
			//Finding camera
			print ("LOADING");		
			camera = GameObject.FindObjectOfType<Camera>().transform;
			if (camera == null) {
				print ("Didnt find Camera ...well fuck");		
			}

			character =  GameObject.FindGameObjectWithTag("Character");
			if (character == null) {
				print ("Didnt find Character ...well fuck");		
			} 

			anim = character.GetComponent<Animator>();
			if(anim == null){
				print ("Didnt find Animator ...well fuck");
			}
			loadCounter ++;
			if(loadCounter == 10){
				loadCounter = 0;
				load = false;
			}
		}

        camera.GetComponent<CameraController>().Lifes = lifes;
        camera.GetComponent<CameraController>().Points = points;
        camera.GetComponent<CameraController>().HP = hp;
	}




	public void AddCoin(){
		coins++;		
		AddPoints (COIN_STR);
	}

	private void AddPoints(string type){
		if(type == COIN_STR){
			points += POINTS_PER_COIN;
		}
		if(type == STANDART_ENEMY_STR){
			points += POINTS_PER_STD_ENEMY; //SHOULD BE 20xLEVEL_NUMBER ... 
		}
	}


	public int GetLifes(){
		return lifes;
	}

	public void RemoveOneLife(){
		lifes--;
		
	}

	/**
	 * This method will be used, when player hit the change scene trigger.
	 * Current values of points coins will be stored to cpPoints, cpCoins values;
	 * So every time from now, when player lost his life, he will respawn with this checkpoint values.
	 */
	public void Checkpoint(){
		load=true;
		cpCoins = coins;
		cpPoints = points;
	} 

	public void ResetCollectedValues(){
		coins = cpCoins;
		points = cpPoints;
		hp = 100;
	}

	/**
	 * This method will be used, when player dies. (Lost his 3 lifes).
	 * All atributes will be setted to init values.	
	 */
	public void TotalReset(){
		this.Start ();
	}

	void TextUpdate(){
		if(scoreSheetText != null){
            scoreSheetText.text = points + "";
/*
			scoreSheetText.text = "Number of lifes: " + lifes +
				"\nNumber of coins: " + coins +
					"\nNumber of points: " + points +
					"\nHealth: " + hp +
					"\nVYPIS JEN KE KONTROLNIM UCELUM\nJE TREBA DORESIT JINAK"+
					"\nCP values: [points / coins] " + cpPoints +  " / " +cpCoins;*/

		}else{
			scoreSheetText = GameObject.FindObjectOfType<GUIText> ();
		}

	}



//-------------------fighting methods--------------------------


	public void CharacterReceiveHitFromUndead(){

		cumulateDamage += damage;

		if(Mathf.Abs(cumulateDamage - 1.0f) < 0.09f){
			hp -= 1;
			cumulateDamage = 0.0f;	
		}
		
		if(hp <= 0){
			hp = 0;
			killCharacter();
		}
	}

	public void CharacterKillEnemy(){
		AddPoints(STANDART_ENEMY_STR);	
	}



	//----DIYING SOLUTION--------

	public void killCharacter(){
		hp = 0;
		
		if(hp == 0 && !isDead){
			isDead = true;
			StartCoroutine(Die());
		}
	}



//here the waitforseconds is exactly the length of animaton
//if you move with animation sample you have to change this

private IEnumerator Die(){
	anim.SetBool("die",true);
	yield return new WaitForSeconds(1.273f);
	
	RemoveOneLife();
	Destroy(character.gameObject);
	if((lifes) == 0){
			TotalReset();
			isDead = false;
			load = true;
			Application.LoadLevel("MainMenu");
	}else{
			ResetCollectedValues();
			isDead = false;
			load = true;
			Application.LoadLevel(Application.loadedLevel);
	}
}



















	/////////////////////---------UNUSED CODE------------//////////////
	/// 
	/// 

	/*
	public void InitializeRound(){
		//lifes, coins, points, hps init
		lifes = 3;
		coins = 0;
		points = 0;
		hp = 100;
	}
	*/
	/*
	public void OnGUI(){
		GUI.Label(Rect(0,0,Screen.width,Screen.height),("Number of lifes: " + heroLifeCounter +
		          									   "\nNumber of coins: "+coins+
		          									   "\n Number of points: " + points+
		          									   "\n Health: "+ heroHealth));


	*/
}
