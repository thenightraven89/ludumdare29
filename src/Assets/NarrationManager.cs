using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

public class NarrationManager : MonoBehaviour
{
    public static NarrationManager instance;

    private GUITexture background;

    void Awake()
    {
        instance = this;
        textHolder.text = string.Empty;
        background = GetComponent<GUITexture>();
        background.enabled = false;
    }

    // dictionary with entries
    private Dictionary<string, Sentence[]> items;

    void Start()
    {        
        // load data from file
        TextAsset terminalData = Resources.Load<TextAsset>("terminalData");
        StringReader terminalReader = new StringReader(terminalData.ToString());
        XmlSerializer terminalSerializer = new XmlSerializer(typeof(Entry[]));
        Entry[] entries = terminalSerializer.Deserialize(terminalReader) as Entry[];

        // create dictionary with entries
        items = new Dictionary<string, Sentence[]>();
        
        for (int i = 0; i < entries.Length; i++)
        {
            items.Add(entries[i].id, entries[i].sentences);
        }
    }

    public GUIText textHolder;

    public float timePerLetter = 0.5f; //in seconds per letter

    private Terminal currentTerminal;

    public void Narrate(Terminal terminal, string textid)
    {
        currentTerminal = terminal;

        if (items.ContainsKey(textid))
        {
            StartCoroutine(DisplayTextLetterByLetter(items[textid]));
        }
        else
        {
            textHolder.text = "< missing entry >";
            if (currentTerminal != null)
            {
                currentTerminal.inUse = false;
            }
        }
    }

    private IEnumerator DisplayTextLetterByLetter(Sentence[] sentences)
    {
        int phraseCount = sentences.Length;
        int phraseCursor = 0;

        int letterCount;
        int letterCursor;

        background.enabled = true;
        yield return new WaitForSeconds(0.5f);

        while (phraseCursor < phraseCount)
        {
            letterCount = sentences[phraseCursor].text.Length;
            letterCursor = 0;

            while (letterCursor < letterCount)
            {
                textHolder.text = sentences[phraseCursor].text.Substring(0, letterCursor + 1);
                letterCursor++;
                yield return new WaitForSeconds(timePerLetter);
            }

            yield return new WaitForSeconds(timePerLetter * letterCount);

            phraseCursor++;
        }

        textHolder.text = string.Empty;

        yield return new WaitForSeconds(0.5f);

        background.enabled = false;

        if (currentTerminal != null)
        {
            currentTerminal.inUse = false;
        }
        yield return null;
    }
}