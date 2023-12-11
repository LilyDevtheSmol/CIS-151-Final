using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    private int cluesCounted;
    private List<string> clues;
    public TextMeshProUGUI UI;

    public void Awake()
    {
        clues = new List<string>();
        // string filepath = Application.dataPath + "/StreamingAssets/Clues.txt"
        cluesCounted = 0;
    }

    public void update() 
    {
        if(cluesCounted == 4) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else if(cluesCounted == 12) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void addClue() 
    {
        cluesCounted++;
    }

    public void retrieveClue(string clue) 
    {
        clues.Add(clue);
        for (int i = 0; i <= cluesCounted; i++)
        {
            UI.text = clues[i] + "\n";
        }
        addClue();
    }

    public void level2Secret(GameObject bookcase)
    {
        if (cluesCounted == 8) 
        {
            Destroy(bookcase);
        }
    }
}
