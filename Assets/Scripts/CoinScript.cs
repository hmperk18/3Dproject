using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to GoldCoin mesh
public class CoinScript : MonoBehaviour
{
    [SerializeField] int book_color; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotating the book
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add a book to the score
            LevelManager.IncreaseScore(book_color);

            // Destory the book 
            Destroy(gameObject);
        }
    }
}
