using UnityEngine;
using System.Collections;

public class ChooseLevelManager : MonoBehaviour {

    public Texture BackgroundTexture;

    public string MainMenu;
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

    public Texture MainMenuTexture;

    public Texture Lvl1Round1Texture;
    public Texture Lvl1Round2Texture;
    public Texture Lvl1Round3Texture;
    public Texture Lvl1Round4Texture;
    public Texture Lvl2Round1Texture;
    public Texture Lvl2Round2Texture;
    public Texture Lvl2Round3Texture;
    public Texture Lvl2Round4Texture;
    
    /*public Texture Lvl3Round1Texture;
    public Texture Lvl3Round2Texture;
    public Texture Lvl3Round3Texture;
    public Texture Lvl3Round4Texture;
    public Texture Lvl4Round1Texture;
    public Texture Lvl4Round2Texture;
    public Texture Lvl4Round3Texture;
    public Texture Lvl4Round4Texture;*/


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.15f, Screen.width / 14f, Screen.height / 7f), Lvl1Round1Texture, ""))
        {
            Application.LoadLevel(LVL_01_RND_01);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f, Screen.height * 0.15f, Screen.width / 14f, Screen.height / 7f), Lvl1Round2Texture, ""))
        {
            Application.LoadLevel(LVL_01_RND_02);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f*2, Screen.height * 0.15f, Screen.width / 14f, Screen.height / 7f), Lvl1Round3Texture, ""))
        {
            Application.LoadLevel(LVL_01_RND_03);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f*3, Screen.height * 0.15f, Screen.width / 14f, Screen.height / 7f), Lvl1Round4Texture, ""))
        {
            Application.LoadLevel(LVL_01_RND_04);
        }

        if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.15f + Screen.height * 0.2f, Screen.width / 14f, Screen.height / 7f), Lvl2Round1Texture, ""))
        {
            Application.LoadLevel(LVL_02_RND_01);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f, Screen.height * 0.15f + Screen.height * 0.2f, Screen.width / 14f, Screen.height / 7f), Lvl2Round2Texture, ""))
        {
            Application.LoadLevel(LVL_02_RND_02);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 2, Screen.height * 0.15f + Screen.height * 0.2f, Screen.width / 14f, Screen.height / 7f), Lvl2Round3Texture, ""))
        {
            Application.LoadLevel(LVL_02_RND_03);
        }
        if (GUI.Button(new Rect(Screen.width * 0.02f + Screen.width * 0.1f * 3, Screen.height * 0.15f + Screen.height * 0.2f, Screen.width / 14f, Screen.height / 7f), Lvl2Round4Texture, ""))
        {
            Application.LoadLevel(LVL_02_RND_04);
        }

     /*   if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.12f + Screen.height * 0.18f*2, Screen.width / 7f, Screen.height / 7f), Lvl3Round1Texture, ""))
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
        }*/

        if (GUI.Button(new Rect(Screen.width * 0.138f, Screen.height * 0.12f + Screen.height * 0.18f * 4, Screen.width / 7f, Screen.height / 7f), MainMenuTexture, ""))
        {
            Application.LoadLevel(MainMenu);
        }

    }
}
