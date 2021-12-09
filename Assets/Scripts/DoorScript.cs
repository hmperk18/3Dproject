using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator doorAnimatorRef;
    [SerializeField] SpawnRoom parent;
    [SerializeField] Transform door; // the door to open/close
    Quaternion open;
    Quaternion close;
    bool isClosed = false;

    private void Awake()
    {
        parent = GetComponentInParent<SpawnRoom>();
        open = Quaternion.Euler(0, 90, 0); // save the initial rotation
        close = transform.rotation; // the parents rotation is 0,0,0 = closed
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
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
    }*/

    private void OnTriggerExit(Collider other)
    {
        // Close door if the player enters and the room is not complete
        if (other.gameObject.CompareTag("Player") && !parent.roomComplete)
        {
            setDoor(false);

            // prevent other possible door interactions
            transform.GetComponent<BoxCollider>().enabled = false;

            // get the doors to open when the player enters the room
            parent.GetDoors();
        }
    }

    // open = true to open the door, false to close
    public void setDoor(bool open)
    {
        if(open)
        {
            door.localRotation = this.open;
            isClosed = true;
        } else
        {
            door.rotation = close;
            isClosed = true;
        }
    }
}
