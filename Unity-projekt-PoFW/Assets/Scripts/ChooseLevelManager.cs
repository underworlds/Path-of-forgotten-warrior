using UnityEngine;
using System.Collections;

public class ChooseLevelManager : MonoBehaviour {

    public Texture BackgroundTexture;

    public string MainMenu;

    public string Lvl1Round1;
    public string Lvl1Round2;
    public string Lvl1Round3;
    public string Lvl1Round4;
    public string Lvl2Round1;
    public string Lvl2Round2;
    public string Lvl2Round3;
    public string Lvl2Round4;
    public string Lvl3Round1;
    public string Lvl3Round2;
    public string Lvl3Round3;
    public string Lvl3Round4;
    public string Lvl4Round1;
    public string Lvl4Round2;
    public string Lvl4Round3;
    public string Lvl4Round4;

    public Texture MainMenuTexture;

    public Texture Lvl1Round1Texture;
    public Texture Lvl1Round2Texture;
    public Texture Lvl1Round3Texture;
    public Texture Lvl1Round4Texture;
    public Texture Lvl2Round1Texture;
    public Texture Lvl2Round2Texture;
    public Texture Lvl2Round3Texture;
    public Texture Lvl2Round4Texture;
    public Texture Lvl3Round1Texture;
    public Texture Lvl3Round2Texture;
    public Texture Lvl3Round3Texture;
    public Texture Lvl3Round4Texture;
    public Texture Lvl4Round1Texture;
    public Texture Lvl4Round2Texture;
    public Texture Lvl4Round3Texture;
    public Texture Lvl4Round4Texture;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.12f, Screen.width / 7f, Screen.height / 7f), Lvl1Round1Texture, ""))
        {
            Application.LoadLevel(Lvl1Round1);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f, Screen.height * 0.12f, Screen.width / 7f, Screen.height / 7f), Lvl1Round2Texture, ""))
        {
            Application.LoadLevel(Lvl1Round2);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f*2, Screen.height * 0.12f, Screen.width / 7f, Screen.height / 7f), Lvl1Round3Texture, ""))
        {
            Application.LoadLevel(Lvl1Round3);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f*3, Screen.height * 0.12f, Screen.width / 7f, Screen.height / 7f), Lvl1Round4Texture, ""))
        {
            Application.LoadLevel(Lvl1Round4);
        }

        if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.12f + Screen.height * 0.18f, Screen.width / 7f, Screen.height / 7f), Lvl2Round1Texture, ""))
        {
            Application.LoadLevel(Lvl2Round1);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.18f, Screen.width / 7f, Screen.height / 7f), Lvl2Round2Texture, ""))
        {
            Application.LoadLevel(Lvl2Round2);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 2, Screen.height * 0.12f + Screen.height * 0.18f, Screen.width / 7f, Screen.height / 7f), Lvl2Round3Texture, ""))
        {
            Application.LoadLevel(Lvl2Round3);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 3, Screen.height * 0.12f + Screen.height * 0.18f, Screen.width / 7f, Screen.height / 7f), Lvl2Round4Texture, ""))
        {
            Application.LoadLevel(Lvl2Round4);
        }

        if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.12f + Screen.height * 0.18f*2, Screen.width / 7f, Screen.height / 7f), Lvl3Round1Texture, ""))
        {
            Application.LoadLevel(Lvl3Round1);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.18f * 2, Screen.width / 7f, Screen.height / 7f), Lvl3Round2Texture, ""))
        {
            Application.LoadLevel(Lvl3Round2);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 2, Screen.height * 0.12f + Screen.height * 0.18f * 2, Screen.width / 7f, Screen.height / 7f), Lvl3Round3Texture, ""))
        {
            Application.LoadLevel(Lvl3Round3);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 3, Screen.height * 0.12f + Screen.height * 0.18f * 2, Screen.width / 7f, Screen.height / 7f), Lvl3Round4Texture, ""))
        {
            Application.LoadLevel(Lvl3Round4);
        }

        if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.12f + Screen.height * 0.18f * 3, Screen.width / 7f, Screen.height / 7f), Lvl4Round1Texture, ""))
        {
            Application.LoadLevel(Lvl4Round1);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f, Screen.height * 0.12f + Screen.height * 0.18f * 3, Screen.width / 7f, Screen.height / 7f), Lvl4Round2Texture, ""))
        {
            Application.LoadLevel(Lvl4Round2);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 2, Screen.height * 0.12f + Screen.height * 0.18f * 3, Screen.width / 7f, Screen.height / 7f), Lvl4Round3Texture, ""))
        {
            Application.LoadLevel(Lvl4Round3);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 3, Screen.height * 0.12f + Screen.height * 0.18f * 3, Screen.width / 7f, Screen.height / 7f), Lvl4Round4Texture, ""))
        {
            Application.LoadLevel(Lvl4Round4);
        }

        if (GUI.Button(new Rect(Screen.width * 0.138f, Screen.height * 0.12f + Screen.height * 0.18f * 4, Screen.width / 7f, Screen.height / 7f), MainMenuTexture, ""))
        {
            Application.LoadLevel(MainMenu);
        }

    }
}
