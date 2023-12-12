using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public DialogueTrigger initialTrigger; //Exists to enable the Greet
    private Queue<string> sentences;

    private static DialogueManager _instance;

    private Dialogue _currentDialogue;
    public static DialogueManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        _instance = this;
        initialTrigger.TriggerDialogue(); //Run Greet
    }

    public void StartDialogue(Dialogue dialogue) 
    {
        _currentDialogue = dialogue;
        _currentDialogue.choices.SetActive(false);
        _currentDialogue.dialogueBox.SetActive(true);
        sentences.Clear();

        nameText.text = _currentDialogue.name;

        foreach(string sentence in _currentDialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if(sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue() 
    {
        if (_currentDialogue.endsLevel == true)
        {

        }
        else 
        {
            _currentDialogue.choices.SetActive(true);
            _currentDialogue.dialogueBox.SetActive(false);
        }
    }
}
