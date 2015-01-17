using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

public class LoadXML 
{
	public static Player loadScore(string name) {
        Player player = null;
        string path = name+".xml";

        XmlSerializer serializer = new XmlSerializer(typeof(Player));

        StreamReader reader = new StreamReader(path);
        player = (Player)serializer.Deserialize(reader);
        reader.Close();

        return player;
	}
}
