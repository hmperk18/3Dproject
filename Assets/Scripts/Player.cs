using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If we want to use this script, attach it to FirstPersonController
public class Player : MonoBehaviour
{
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Displaying number of coins
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + points);
    }
}
