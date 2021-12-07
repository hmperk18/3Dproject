using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public Rigidbody coinRef;

    private bool isInsideTrigger = false;
    // To avoid null reference error.
    private bool visited = false;
    private Animator chestAnimatorRef;

    private Transform coinCreateRef;

    // Update is called once per frame
    void Update()
    {
        // collide with chest?
        if (isInsideTrigger == true)
        {
            if (Input.GetButtonDown("E") && !visited)
            {
                chestAnimatorRef.SetBool("isOpen?", true);
                GameObject.Find("OpenText").SetActive(false);
                //visited = true;

                // Create coin
                Rigidbody coinInstance;
                coinInstance = Instantiate(coinRef, coinCreateRef.position, coinCreateRef.rotation) as Rigidbody;
                coinInstance.AddForce(Random.Range(-50, 50), 300f, -30f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            isInsideTrigger = true;
            Transform chestRef = other.transform.parent.Find("TreasureChest");
            Animator chestAnimator = chestRef.GetComponent<Animator>();
            chestAnimatorRef = chestAnimator;

            coinCreateRef = other.transform.parent.Find("CoinCreatePoint");
        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            // GetComponent<Player>().points++;
        }

        if (coinRef == other)
        {
            Destroy(other.gameObject);
            // GetComponent<Player>().points++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            isInsideTrigger = false;
        }
    }
}
