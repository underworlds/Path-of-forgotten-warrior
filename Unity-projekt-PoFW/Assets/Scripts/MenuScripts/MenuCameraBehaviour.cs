using UnityEngine;
using System.Collections;

public class MenuCameraBehaviour : MonoBehaviour {

    public Texture BackgroundTexture;
    public Texture NewGame;

    public string Level1Round1Scene;
    public string ChooseLevelScene;
    public string BestScoreScene;
    public string CreditsScene;
    public string HelpScene;
    

    public Texture Continue;
    public Texture ChooseLevel;
    public Texture BestScore;
    public Texture Credits;
    public Texture Help;
    public Texture Exit;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.14f, Screen.width / 5f, Screen.height / 10f), NewGame, ""))
        {
			/*GameManager gm = GameObject.FindObjectOfType<GameManager>();
			gm.inMainMenu = false;
			gm.TotalReset();
			gm.loadComponents();*/

            Application.LoadLevel(Level1Round1Scene);

        }
    /*    if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.11f, Screen.width / 5f, Screen.height / 10f), Continue, ""))
        {

        }*/
        if(GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.14f + Screen.height * 0.11f * 1f, Screen.width / 5f, Screen.height / 10f), ChooseLevel, ""))
        {
            Application.LoadLevel(ChooseLevelScene);
        }
        if(GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.14f + Screen.height * 0.11f * 2f, Screen.width / 5f, Screen.height / 10f), BestScore, ""))
        {
            Application.LoadLevel(BestScoreScene);
        }
        if(GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.14f + Screen.height * 0.11f * 3f, Screen.width / 5f, Screen.height / 10f), Credits, ""))
        {
            Application.LoadLevel(CreditsScene);
        }
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.14f + Screen.height * 0.11f * 4f, Screen.width / 5f, Screen.height / 10f), Help, ""))
        {
            Application.LoadLevel(HelpScene);
        }
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.14f + Screen.height * 0.11f * 5f, Screen.width / 5f, Screen.height / 10f), Exit, ""))
        {
            Application.Quit();
        }

    }
}
