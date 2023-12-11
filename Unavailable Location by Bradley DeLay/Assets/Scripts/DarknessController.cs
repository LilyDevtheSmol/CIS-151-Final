using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessController : MonoBehaviour
{
    SpriteRenderer darkness;
    
    // Start is called before the first frame update
    void Start()
    {
        darkness = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D()
    {
        darkness.enabled = false;
    }

    void OnTriggerExit2D()
    {
        darkness.enabled = true;
    }
}
