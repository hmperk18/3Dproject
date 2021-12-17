using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] GameObject[] rooms; // possible rooms to spawn
    [SerializeField] GameObject[] roomLayouts; // possible setting to spawn
    [SerializeField] GameObject SpawnedRoom; // the spawned room

    public bool roomComplete = false; // true if the player completed room's task
    [SerializeField] DoorScript[] doors; // list of doors connected to this room

    // Start is called before the first frame update
    void Start()
    {
        // spawn a random room and layout from the possible
        int i = Random.Range(0, rooms.Length); // Note: Range is min inclusive and max inclusive
        SpawnedRoom = Instantiate(rooms[i], transform.position, transform.rotation);
        SpawnedRoom.transform.parent = transform;

        int j = Random.Range(0, roomLayouts.Length);
        int k = Random.Range(0, 4); // pick random orientation
        Instantiate(roomLayouts[j], transform.position, transform.rotation * Quaternion.Euler(0,90*k,0)).transform.parent = transform;

        // increment the number of rooms spawned
        LevelManager.AddRoom();
    }

    // get list of doors to open upon completion
    public void GetDoors()
    {
        // entry door is the child of the spawn node
        DoorScript entry = transform.GetChild(0).GetComponent<DoorScript>();

        // find children doors in the spawned room
        int doors_num = SpawnedRoom.transform.childCount - 2; // number of doors in room = children - wall/floor mesh
        doors = new DoorScript[doors_num + 1]; // include entry

        // add then doors
        doors[0] = entry;

        // get other doors
        int doors_idx = 1; // start at 1 since entry is at idx = 0
        for(int i = 2; i < SpawnedRoom.transform.childCount; i++)
        {
            // child i = spawn node
                // child 0 = door on spawn node
            doors[doors_idx] = SpawnedRoom.transform.GetChild(i).GetChild(0).GetComponent<DoorScript>();
            doors_idx++;
        }
    }

    // opens the doors when the book has been collected
    public void CompleteRoom()
    {
        foreach (DoorScript door in doors)
        {
            door.setDoor(true);
            roomComplete = true;
        }
    }

}
