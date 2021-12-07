using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private bool isInsideTrigger = false;
    private bool isOpen = false;
    private Animator chestAnimatorRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // collide with chest?
        if (isInsideTrigger == true)
        {
            //if (Input.GetButtonDown("E"))
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                chestAnimatorRef.SetBool("isOpen", isOpen);
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
