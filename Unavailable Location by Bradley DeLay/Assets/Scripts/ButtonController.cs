using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private static ButtonController _instance;
    public static ButtonController Instance {  get { return _instance; } }

    public delegate void ButtonEventHandler(object sender);

    public event ButtonEventHandler Option1Clicked;
    public event ButtonEventHandler Option2Clicked;
    public event ButtonEventHandler Option3Clicked;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    public void Continue()
    {
        DialogueManager.Instance.DisplayNextSentence();
    }

    public void Button1()
    {
        Option1Clicked.Invoke(this);
    }

    public void Button2()
    {
        Option2Clicked.Invoke(this);
    }

    public void Button3()
    {
        Option3Clicked.Invoke(this);
    }
}

