using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	private GameManager gameManager;

	//LEVEL 1
	private const string LVL_01_RND_01 = "Lvl1-round1";
	private const string LVL_01_RND_02 = "Lvl1-round2";
	private const string LVL_01_RND_03 = "Lvl1-round3";
	private const string LVL_01_RND_04 = "Lvl1-round4";

	//LEVEL 2
	private const string LVL_02_RND_01 = "Lvl2-round1";
	private const string LVL_02_RND_02 = "Lvl2-round2";
	private const string LVL_02_RND_03 = "Lvl2-round3";
	private const string LVL_02_RND_04 = "Lvl2-round4";

	//LEVEL 3
	private const string LVL_03_RND_01 = "Lvl3-round1";
	private const string LVL_03_RND_02 = "Lvl3-round2";
	private const string LVL_03_RND_03 = "Lvl3-round3";
	private const string LVL_03_RND_04 = "Lvl3-round4";

	//LEVEL 2
	private const string LVL_04_RND_01 = "Lvl4-round1";
	private const string LVL_04_RND_02 = "Lvl4-round2";
	private const string LVL_04_RND_03 = "Lvl4-round3";
	private const string LVL_04_RND_04 = "Lvl4-round4";

	private const string THE_END = "TheEnd";


	void Start(){
		gameManager = GameObject.FindObjectOfType<GameManager>();
		if (gameManager== null) {
			print ("Didnt find gameManager ...well fuck");		
		}
	}

	void OnTriggerEnter2D(){
		/*
			Tady by mela byt vyresena change scene animace... 
			Par pokusu bylo ale nepodarilo se.
		 */


		string loadedLevel = Application.loadedLevelName;
		switch (loadedLevel)
		{

		//------------LEVEL 1-----------------
		case LVL_01_RND_01:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_01_RND_02);
			break;
		case LVL_01_RND_02:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_01_RND_03);
			break;
		case LVL_01_RND_03:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_01_RND_04);
			break;
		case LVL_01_RND_04:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_02_RND_01);
			break;
		
		//----------------LEVEL 2-------------
		case LVL_02_RND_01:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_02_RND_02);
			break;
		case LVL_02_RND_02:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_02_RND_03);
			break;
		case LVL_02_RND_03:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_02_RND_04);
			break;
		case LVL_02_RND_04:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_03_RND_01);
			break;

		//----------------LEVEL 3-------------
		case LVL_03_RND_01:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_03_RND_02);
			break;
		case LVL_03_RND_02:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_03_RND_03);
			break;
		case LVL_03_RND_03:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_03_RND_04);
			break;
		case LVL_03_RND_04:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_04_RND_01);
			break;

		//----------------LEVEL 4-------------
		case LVL_04_RND_01:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_04_RND_02);
			break;
		case LVL_04_RND_02:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_04_RND_03);
			break;
		case LVL_04_RND_03:
			gameManager.Checkpoint();
			Application.LoadLevel(LVL_04_RND_04);
			break;
		case LVL_04_RND_04:
			gameManager.Checkpoint();
			Application.LoadLevel(THE_END);
			break;
		}

	}
}
