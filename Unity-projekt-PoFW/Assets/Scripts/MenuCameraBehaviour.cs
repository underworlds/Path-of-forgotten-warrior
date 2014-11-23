using UnityEngine;
using System.Collections;

public class MenuCameraBehaviour : MonoBehaviour {

    public Texture BackgroundTexture;
    public Texture NewGame;

    public string Level1Round1;

    public Texture Continue;
    public Texture ChooseLevel;
    public Texture BestScore;
    public Texture Credits;
    public Texture Help;
    public Texture Exit;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f, Screen.width / 5f, Screen.height / 10f), NewGame, ""))
        {
			GameManager gm = GameObject.FindObjectOfType<GameManager>();
			gm.inMainMenu = false;
			gm.TotalReset();
			gm.loadComponents();

            Application.LoadLevel(Level1Round1);

        }
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f, Screen.width / 5f, Screen.height / 10f), Continue, "");
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f * 2f, Screen.width / 5f, Screen.height / 10f), ChooseLevel, "");
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f * 3f, Screen.width / 5f, Screen.height / 10f), BestScore, "");
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f * 4f, Screen.width / 5f, Screen.height / 10f), Credits, "");
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f * 5f, Screen.width / 5f, Screen.height / 10f), Help, "");
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f * 6f, Screen.width / 5f, Screen.height / 10f), Exit, ""))
        {
            Application.Quit();
        }

    }
}
