using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator doorAnimatorRef;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Open door
        if (other.gameObject.CompareTag("Door"))
        {
            Transform doorRef = other.transform.parent.Find("Door");
            Animator animator = doorRef.GetComponent<Animator>();
            doorAnimatorRef = animator;
            doorAnimatorRef.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Close door
        if (other.gameObject.CompareTag("Door"))
        {
            doorAnimatorRef.SetBool("isOpen", false);
        }
    }
}
