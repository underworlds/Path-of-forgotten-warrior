using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private bool isGamePaused;

    public Texture HealthBarLimits;
    public Texture HealthBar;
    public Texture Helmets;
    public Texture ScoreLimits;


    public Texture NewGame;

    public string Level1Round1;

    public Texture Continue;
    public Texture ChooseLevel;
    public Texture BestScore;
    public Texture Credits;
    public Texture Help;
    public Texture Exit;

	private Transform character;
	private float smoothRate = 0.5f;
	private Vector2 velocity;
	private float lookTransformConst = 0.0f;


	// Use this for initialization
	void Start () {
		character =  GameObject.FindGameObjectWithTag("Character").transform;
		if (character == null) {
						print ("Didnt find character ...well fuck");		
				}
		velocity = new Vector2(0.5f,0.5f);
        isGamePaused = false;
	}

	void Update(){
		Vector2 newPos2D = Vector2.zero;
		newPos2D.x = Mathf.SmoothDamp (this.transform.position.x, character.transform.position.x, ref velocity.x, smoothRate);
		newPos2D.y = Mathf.SmoothDamp (this.transform.position.y, character.transform.position.y + lookTransformConst , ref velocity.y, smoothRate);

		//UPDATES CAMERA TO OUR CHARACTERS LOCATION
		Vector3 newPos = new Vector3 (newPos2D.x, newPos2D.y, this.transform.position.z);
		this.transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                print("itHappen");
                isGamePaused = false;
            }
            else
            {
                print("itdidnotHappen");
                isGamePaused = true;
            }


        }
	}

	public void setLookTransformCons(float newLookTransformConst){
		print("Const is goint to be " + newLookTransformConst); 
		lookTransformConst = newLookTransformConst;
	}
    private void OnGUI()
    {
        //healthbar-done
        GUI.Button(new Rect(Screen.width * 0.11f, Screen.height * 0.13f, Screen.width * 0.221f, Screen.height * 0.78f), HealthBar, "");

        //healthbarlimits-done
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f, Screen.width * 0.24f, Screen.height * 0.78f), HealthBarLimits, "");

        //helmets-done

        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
        GUI.Button(new Rect(Screen.width * 0.1f + Screen.width * 0.04f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
        GUI.Button(new Rect(Screen.width * 0.1f + Screen.width * 0.04f * 2f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");

        //score
        GUI.Button(new Rect(Screen.width * 0.24f, Screen.height * 0.21f, Screen.width * 0.1f, Screen.height * 0.1f), ScoreLimits, "666");

        //ingame menu
        if (isGamePaused)
        {

            if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f, Screen.width / 5f, Screen.height / 10f), NewGame, ""))
            {
                Application.LoadLevel(Level1Round1);
            }
            GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f, Screen.width / 5f, Screen.height / 10f), Continue, "");
            GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 2f, Screen.width / 5f, Screen.height / 10f), ChooseLevel, "");
            GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 3f, Screen.width / 5f, Screen.height / 10f), BestScore, "");
            GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 4f, Screen.width / 5f, Screen.height / 10f), Credits, "");
            GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 5f, Screen.width / 5f, Screen.height / 10f), Help, "");
            if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 6f, Screen.width / 5f, Screen.height / 10f), Exit, ""))
            {
                Application.Quit();
            }
        }
    }

}
