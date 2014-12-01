using UnityEngine;
using System.Collections;

public class CreditsManager : MonoBehaviour {

    public Texture BackgroundTexture;

    public string MainMenu;

    public Texture MainMenuTexture;
    public Texture Credits;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.135f, Screen.height * 0.87f, Screen.width / 7f, Screen.height / 7f), MainMenuTexture, ""))
        {
            Application.LoadLevel(MainMenu);
        }
        GUI.Button(new Rect(Screen.width * 0.06f, Screen.height * 0.08f, Screen.width / 1.3f, Screen.height / 1.3f), Credits, "");
    }
}
