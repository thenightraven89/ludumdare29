using UnityEngine;
using System.Collections;
using System;
using System.Xml.Serialization;

[Serializable]
public class Sentence
{
    public Sentence()
    {

    }

    [XmlAttribute]
    public string text;
}