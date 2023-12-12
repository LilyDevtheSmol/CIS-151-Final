using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public DialogueTrigger Trigger;

    bool ButtonsAssigned = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Instance_Option1Clicked(object sender)
    {
        Trigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(!ButtonsAssigned && ButtonController.Instance != null)
        {
            ButtonController.Instance.Option1Clicked += Instance_Option1Clicked;
            ButtonsAssigned = true;
        }

    }
}
