using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) 
    {
        sentences.Clear();

        nameText.text = dialogue.name;

        foreach(string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(dialogue);
    }

    public void DisplayNextSentence(Dialogue dialogue) 
    {
        if(sentences.Count == 0) 
        {
            EndDialogue(dialogue);
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue(Dialogue dialogue) 
    {
        if (dialogue.endsLevel == true)
        {

        }
        else 
        {
            dialogue.choices.SetActive(true);
            dialogue.dialogueBox.SetActive(false);
        }
    }
}
