using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private bool isGamePaused;

    public Texture HealthBarLimits;
    public Texture HealthBar;
    public Texture Helmets;
    public Texture ScoreLimits;

    public Font FontForGui;

    public AudioClip MenuClip;
    public AudioClip GameClip;

    public AudioSource AudioSourcePointer;

    public Texture Continue;
    public Texture BestScore;
    public Texture Help;
    public Texture Return;

    public int Lifes { get; set; }
    public int Points { get; set; }
    public int HP { get; set; }

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
		//init for camera location
		velocity = new Vector2(0.5f,0.5f);
        
		//init for GUI
		isGamePaused = false;
        Lifes = 3;
        Points = 0;
        HP = 100;
	}

	void Update(){
		Vector2 newPos2D = Vector2.zero;
		newPos2D.x = Mathf.SmoothDamp (this.transform.position.x, character.transform.position.x, ref velocity.x, smoothRate);
		newPos2D.y = Mathf.SmoothDamp (this.transform.position.y, character.transform.position.y + lookTransformConst , ref velocity.y, smoothRate);

		//UPDATES CAMERA TO OUR CHARACTERS LOCATION
		Vector3 newPos = new Vector3 (newPos2D.x, newPos2D.y, this.transform.position.z);
		this.transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
        
	
		//solution for in game menu
		if (Input.GetKeyDown(KeyCode.Escape)){
            if (isGamePaused){
                isGamePaused = false;
                AudioSourcePointer.clip = GameClip;
                AudioSourcePointer.Play();
               // AudioSourcePointer.mute = true;
            }
            else{
                isGamePaused = true;
                AudioSourcePointer.clip = MenuClip;
               // AudioSourcePointer.mute = false;
                AudioSourcePointer.Play();
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
        Texture2D tx2DFlash = new Texture2D(1, 1); //Creates 2D texture
        tx2DFlash.SetPixel(1, 1, Color.red); //Sets the 1 pixel to be white
        tx2DFlash.Apply(); //Applies all the changes made
        GUI.DrawTexture(new Rect(Screen.width * 0.11f, Screen.height * 0.13f, Screen.width * 0.221f * (HP / 100f), Screen.height * 0.025f), tx2DFlash); //Draws the texture for the entire screen (width, height)
        
        //GUI.Button(new Rect(Screen.width * 0.11f, Screen.height * 0.13f, Screen.width * 0.221f * (HP/100f), Screen.height * 0.78f), HealthBar, "");

        //healthbarlimits-done
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f, Screen.width * 0.24f, Screen.height * 0.78f), HealthBarLimits, "");

        //helmets-done
        switch (Lifes)
        {
            case 1:
                 GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
                break;
            case 2:
                 GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
                 GUI.Button(new Rect(Screen.width * 0.1f + Screen.width * 0.04f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
                 break;
            case 3:
                 GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
                 GUI.Button(new Rect(Screen.width * 0.1f + Screen.width * 0.04f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");
                 GUI.Button(new Rect(Screen.width * 0.1f + Screen.width * 0.04f * 2f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.width * 0.04f), Helmets, "");

                break;
        }
       
        //score
        GUI.Button(new Rect(Screen.width * 0.24f, Screen.height * 0.21f, Screen.width * 0.1f, Screen.height * 0.1f), ScoreLimits, "");
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.font = FontForGui;
        style.fontSize = Screen.height / 28;
        style.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(0.265f * Screen.width, 0.21f * Screen.height, Screen.width*0.05f, Screen.height*0.05f), Points + "", style);
        //ingame menu
        if (isGamePaused)
        {
            
            if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f, Screen.width / 5f, Screen.height / 10f), Continue, ""))
            {
                isGamePaused = false;
            }
            if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 2f, Screen.width / 5f, Screen.height / 10f), BestScore, ""))
            {
                Application.LoadLevel("BestScore");
            }
            if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 3f, Screen.width / 5f, Screen.height / 10f), Help, ""))
            {
                Application.LoadLevel("Help");
            }

            if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.12f + Screen.height * 0.11f * 4f, Screen.width / 5f, Screen.height / 10f), Return, ""))
            {
				GameObject.FindObjectOfType<GameManager>().inMainMenu = true;
				Application.LoadLevel("MainMenu");
            }
        }


        else
        {
            
        }
    }

}
