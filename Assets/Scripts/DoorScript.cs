using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] SpawnRoom parent;
    [SerializeField] Transform door; // the door to open/close
    Quaternion open;
    Quaternion close;
    bool isClosed = false;

    private AudioSource audioSource;
    [SerializeField] AudioClip openCloseSound;

    private void Awake()
    {
        parent = GetComponentInParent<SpawnRoom>();
        open = Quaternion.Euler(0, 90, 0); // save the initial rotation
        close = transform.rotation; // the parents rotation is 0,0,0 = closed

        audioSource = GetComponent<AudioSource>();
    }

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

        audioSource.PlayOneShot(openCloseSound);
        if (open)
        {
            door.localRotation = this.open;
            isClosed = true;
        } else
        {
            // play only on close
            door.rotation = close;
            isClosed = true;
        }
    }
}
