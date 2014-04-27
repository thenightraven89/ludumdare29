using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Entry
{
    public Entry()
    {

    }

    [XmlAttribute]
    public string id;

    public Sentence[] sentences;
}