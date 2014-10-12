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
	public GUIText scoreSheetText;


	private int heroLifeCounter = 3;
	private int coins = 0;
	private int points = 0;
	private int heroHealth = 100;
	//private Rect rectangle; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		scoreSheetText.text = "Number of lifes: " + heroLifeCounter +
						"\nNumber of coins: " + coins +
						"\nNumber of points: " + points +
						"\nHealth: " + heroHealth +
				"\nVYPIS JEN KE KONTROLNIM UCELUM\nJE TREBA DORESIT JINAK";


	}

	
	public void addCoin(int amount){
		coins++;	
		
	}

	/*
	public void OnGUI(){
		GUI.Label(Rect(0,0,Screen.width,Screen.height),("Number of lifes: " + heroLifeCounter +
		          									   "\nNumber of coins: "+coins+
		          									   "\n Number of points: " + points+
		          									   "\n Health: "+ heroHealth));
	}
	*/

}
