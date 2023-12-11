using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public bool endsLevel = false;
    public GameObject dialogueBox;
    public GameObject choices;

    [TextArea(3, 10)]
    public string[] sentences;
}
