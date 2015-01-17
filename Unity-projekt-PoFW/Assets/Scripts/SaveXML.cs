using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;

public class SaveXML
{
	public static void Save(string name, Player playerScore) 
    {
        XmlSerializer xmls = new XmlSerializer(typeof(Player));

        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
        using (var stream = File.OpenWrite(name+ ".xml"))
        {
            using (var xmlWriter = XmlWriter.Create(stream, settings))
            {
                xmls.Serialize(xmlWriter, new Player { Points = playerScore.Points , ActualTime = playerScore.ActualTime }, ns);
            }
        }
	}
}

[XmlRoot]
public class Player
{
    [XmlElement]
    public int[] Points { get; set; }

    [XmlElement]
    public List<DateTime> ActualTime { get; set; }

    public void AddScore(int score, DateTime date)
    {
        int[] temp= {0,0,0,0,0,0};
        for (int i = 0; i < 5; i++)
        {
            temp[i] = Points[i];
        }
        temp[5] = score;
        List<DateTime> tempTime = new List<DateTime>(6);
        foreach(var item in ActualTime)
        {
            tempTime.Add(item);
        }
        tempTime.Add(date);

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    int tempTemp = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = tempTemp;

                    DateTime tempTempDate = tempTime[j];
                    tempTime[j] = tempTime[j + 1];
                    tempTime[j + 1] = tempTempDate;
                }
            }
        }
        
        Points = new int[5];
        ActualTime = new List<DateTime>(5);
        
        for (int i = 0; i < 5; i++)
        {
            Points[i] = temp[i];
            ActualTime.Add(tempTime[i]);
        }
    }
}