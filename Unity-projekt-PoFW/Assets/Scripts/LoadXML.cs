using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

public class LoadXML : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Player player = null;
        string path = "my_player.xml";

        XmlSerializer serializer = new XmlSerializer(typeof(Player));

        StreamReader reader = new StreamReader(path);
        player = (Player)serializer.Deserialize(reader);
        reader.Close();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
