using UnityEngine;
using System.Collections;
using System.IO;

public class BestScoreManager : MonoBehaviour {

    public Texture BackgroundTexture;

    public string MainMenu;

    public Texture MainMenuTexture;

    void OnGUI()
    {
       /* StreamWriter writer = new StreamWriter("hi.txt");

        writer.WriteLine("hi");
        writer.Close();*/
        
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BackgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.135f, Screen.height * 0.87f, Screen.width / 7f, Screen.height / 7f), MainMenuTexture, ""))
        {
            Application.LoadLevel(MainMenu);
        }

        GUI.Label(new Rect(0, 0, 100, 100), "hi");
    }
}
