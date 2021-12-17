using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] SpawnRoom parent; // reference to the spawn script of the parent node
    
    [SerializeField] Transform door; // the door to open/close
    private Quaternion open;
    private Quaternion close;

    private AudioSource audioSource;
    [SerializeField] AudioClip openCloseSound;

    private void Awake()
    {
        parent = GetComponentInParent<SpawnRoom>();
        open = Quaternion.Euler(0, 90, 0);              // save the initial rotation
        close = transform.rotation;                     // parent's rotation is 0,0,0 = closed

        // for playing opening/closing sound
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        // Close door if the player enters and the room is not complete
        if (other.gameObject.CompareTag("Player") && !parent.roomComplete)
        {
            setDoor(false);

            // prevent player from closing the door when they leave the room
            transform.GetComponent<BoxCollider>().enabled = false;

            // get the doors to open when the player enters the room
            parent.GetDoors();
        }
    }

    // change the state of the door
        // open = true to open the door, false to close
    public void setDoor(bool open)
    {
        // play sound on open/close
        audioSource.PlayOneShot(openCloseSound);

        // change the door state accordingly
        if (open)
        {
            door.localRotation = this.open;
        } else {
            door.rotation = this.close;
        }
    }
}
