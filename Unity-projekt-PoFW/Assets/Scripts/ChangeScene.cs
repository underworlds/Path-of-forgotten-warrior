using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	//LEVEL 1
	private const string LVL_01_RND_01 = "Lvl1-round1";
	private const string LVL_01_RND_02 = "Lvl1-round2";
	private const string LVL_01_RND_03 = "Lvl1-round3";
	private const string LVL_01_RND_04 = "Lvl1-round4";
	//LEVEL 2

	void Start(){

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
			Application.LoadLevel(LVL_01_RND_02);
			break;
		case LVL_01_RND_02:
			Application.LoadLevel(LVL_01_RND_03);
			break;
		case LVL_01_RND_03:
			Application.LoadLevel(LVL_01_RND_04);
			break;
		case LVL_01_RND_04:
			//bude dodelano...
			break;
		}
		//----------------LEVEL 2-------------
	}
}
