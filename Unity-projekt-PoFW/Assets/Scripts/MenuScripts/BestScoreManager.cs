using UnityEngine;
using System.Collections;
using System.IO;

public class BestScoreManager : MonoBehaviour {

    public Texture BackgroundTexture;

    public string MainMenu;

    public Texture MainMenuTexture;
    public Font FontForGui;

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

    void OnGUI()
    {
        string loadedLevel = Application.loadedLevelName;
        Player[] players = new Player[8];
        players[0]= LoadXML.loadScore(LVL_01_RND_01);
        players[1] = LoadXML.loadScore(LVL_01_RND_02);
        players[2] = LoadXML.loadScore(LVL_01_RND_03);
        players[3] = LoadXML.loadScore(LVL_01_RND_04);
        players[4] = LoadXML.loadScore(LVL_02_RND_01);
        players[5] = LoadXML.loadScore(LVL_02_RND_02);
        players[6] = LoadXML.loadScore(LVL_02_RND_03);
        players[7] = LoadXML.loadScore(LVL_02_RND_04);



       
            
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.135f, Screen.height * 0.87f, Screen.width / 7f, Screen.height / 7f), MainMenuTexture, ""))
        {
            Application.LoadLevel(MainMenu);
        }

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.font = FontForGui;
        style.fontSize = Screen.height / 45;
        style.alignment = TextAnchor.MiddleCenter;

        GUIStyle styleForTitle = new GUIStyle();
        styleForTitle.normal.textColor = Color.white;
        styleForTitle.font = FontForGui;
        styleForTitle.fontSize = Screen.height / 30;
        styleForTitle.alignment = TextAnchor.MiddleCenter;
        //1
        GUI.Label(
                new Rect(
                    0.06f * Screen.width,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 1\nround 1",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width, 
                    0.5f * Screen.height + 0.04f * Screen.height * i, 
                    Screen.width * 0.05f, 
                    Screen.height * 0.05f), 
                players[0].Points[i]+"",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width, 
                    0.5f * Screen.height + 0.04f * Screen.height * i, 
                    Screen.width * 0.05f, 
                    Screen.height * 0.05f), 
                players[0].ActualTime[i].ToString("MM/dd/yyyy"), 
                style);
        }
        //2
        GUI.Label(
                new Rect(
                    0.06f * Screen.width + 0.11f * Screen.width,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 1\nround 2",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[1].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[1].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        //3
        GUI.Label(
                 new Rect(
                     0.06f * Screen.width + 0.11f * Screen.width * 2,
                     0.4f * Screen.height,
                     Screen.width * 0.05f,
                     Screen.height * 0.05f),
                 "Level 1\nround 3",
                 styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width * 2,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[2].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width * 2, 
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[2].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        //4
        GUI.Label(
                new Rect(
                    0.06f * Screen.width + 0.11f * Screen.width * 3,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 1\nround 4",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width * 3,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[3].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width * 3,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[3].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        //5
        GUI.Label(
                new Rect(
                    0.06f * Screen.width + 0.11f * Screen.width * 4,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 2\nround 1",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width * 4,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[4].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width * 4,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[4].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        //6
        GUI.Label(
                new Rect(
                    0.06f * Screen.width + 0.11f * Screen.width * 5,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 2\nround 2",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width * 5,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[5].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width * 5,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[5].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        //7
        GUI.Label(
                new Rect(
                    0.06f * Screen.width + 0.11f * Screen.width * 6,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 2\nround 3",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width * 6,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[6].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width * 6,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[6].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        //8
        GUI.Label(
                new Rect(
                    0.06f * Screen.width + 0.11f * Screen.width * 7,
                    0.4f * Screen.height,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                "Level 2\nround 4",
                styleForTitle);

        for (int i = 0; i < 5; i++)
        {
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.11f * Screen.width * 7,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[7].Points[i] + "",
                style);
            GUI.Label(
                new Rect(
                    0.02f * Screen.width + 0.055f * Screen.width + 0.11f * Screen.width * 7,
                    0.5f * Screen.height + 0.04f * Screen.height * i,
                    Screen.width * 0.05f,
                    Screen.height * 0.05f),
                players[7].ActualTime[i].ToString("MM/dd/yyyy"),
                style);
        }
        

    }
}
