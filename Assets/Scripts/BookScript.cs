using UnityEngine;

// This script is for the collectable books
public class BookScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Rotating the book
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // player picks up the books
        if (other.CompareTag("Player"))
        {
            // Add a book to the score
            LevelManager.IncreaseScore();

            // open door
                // parent = "room setting" parent.parent = "spawn_[direction]"
            transform.parent.parent.GetComponent<SpawnRoom>().CompleteRoom();

            // Destory the book 
            Destroy(gameObject);
        }
    }
}
