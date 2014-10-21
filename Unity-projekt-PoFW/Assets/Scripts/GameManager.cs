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

	public Transform camera;
	//public GUIText scoreSheetText;
	private GUIText scoreSheetText;
	
	
	private	static int lifes;
	private static int coins;
	private int points;
	private int hp; //healthpoints
	
	private int startCallCounter;


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

		//print ("Dostal jsem se k tomuto kodu...");
		//scoreSheetText = GameObject.FindObjectOfType<GUIText> ();
	}

	//END OF SINGLETONE CODE ....INSIPRED FROM: http://unitypatterns.com/singletons/


	void Start () {
		//InitialieRound ();
		lifes = 3;
		coins = 0;
		points = 0;
		hp = 100;

	}
	
	// Update is called once per frame
	void Update () {
		TextUpdate ();
	}

	
	public void AddCoin(){
		coins++;		
	}



	public int GetLifes(){
		return lifes;
	}

	public void RemoveOneLife(){
		lifes--;
		
	}


	void TextUpdate(){
		if(scoreSheetText != null){


			scoreSheetText.text = "Number of lifes: " + lifes +
				"\nNumber of coins: " + coins +
					"\nNumber of points: " + points +
					"\nHealth: " + hp +
					"\nVYPIS JEN KE KONTROLNIM UCELUM\nJE TREBA DORESIT JINAK";

		}else{
			scoreSheetText = GameObject.FindObjectOfType<GUIText> ();
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
