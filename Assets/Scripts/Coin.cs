using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to GoldCoin mesh
public class Coin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotating the coin
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Add 1 to points
            other.gameObject.GetComponent<Player>().points++;
            // Distory the coin 
            Destroy(gameObject);
        }
    }
}
