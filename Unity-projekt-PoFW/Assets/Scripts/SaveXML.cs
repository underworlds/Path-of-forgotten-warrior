using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

public class SaveXML : MonoBehaviour {

	// Use this for initialization
	void Start () {
        XmlSerializer xmls = new XmlSerializer(typeof(Player));

        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
        using (var stream = File.OpenWrite("my_player.xml"))
        {
            using (var xmlWriter = XmlWriter.Create(stream, settings))
            {
                xmls.Serialize(xmlWriter, new Player { Level = 5, Health = 500 }, ns);
            }
        }

        Player player = null;
        using (var stream = File.OpenRead("my_player.xml"))
        {
            player = xmls.Deserialize(stream) as Player;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[XmlRoot]
public class Player
{
    [XmlElement]
    public int Level { get; set; }

    [XmlElement]
    public int Health { get; set; }
}