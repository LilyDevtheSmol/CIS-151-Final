using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueController : MonoBehaviour
{
    public GameManager gm;
    private SpriteRenderer _rend;
    private BoxCollider2D _bc2D;
    public string clueText;

    // Start is called before the first frame update
    void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
        _bc2D = GetComponent<BoxCollider2D>();
        //gm = GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log(clueText);
            gm.retrieveClue(clueText);
            _rend.enabled = false;
            _bc2D.enabled = false;
            Destroy(gameObject);
        }
    }
}
