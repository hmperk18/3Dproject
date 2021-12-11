using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] rooms; // possible rooms to spawn
    [SerializeField] GameObject[] roomLayouts;
    [SerializeField] GameObject SpawnedRoom;
    public bool roomComplete = false;
    [SerializeField] DoorScript[] doors;

    void Start()
    {
        // spawn a random room from the possible
        int i = Random.Range(0, rooms.Length); // Note: Range is min inclusive and max inclusive
        SpawnedRoom = Instantiate(rooms[i], transform.position, transform.rotation);
        SpawnedRoom.transform.parent = transform;

        // spawn a layout within the room
        int j = Random.Range(0, roomLayouts.Length);
        int k = Random.Range(0, 4); // pick random orientation
        Instantiate(roomLayouts[j], transform.position, transform.rotation * Quaternion.Euler(0,90*k,0)).transform.parent = transform;

        // increment the number of rooms spawned
        LevelManager.AddRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // get list of doors to open upon completion
    public void GetDoors()
    {
        // entry door is the child of the spawn node
        DoorScript entry = transform.GetChild(0).GetComponent<DoorScript>();

        // find children doors in the spawned room
        int doors_num = SpawnedRoom.transform.childCount - 2; // first 2 children are mesh for room then also entry door
        doors = new DoorScript[doors_num + 1]; // include entry

        // add then doors
        doors[0] = entry;

        // room -> spawn nodes -> door
        int doors_idx = 1; 
        for(int i = 2; i < SpawnedRoom.transform.childCount; i++)
        {
            // child i = spawn node
                // child 0 = door on spawn node
            doors[doors_idx] = SpawnedRoom.transform.GetChild(i).GetChild(0).GetComponent<DoorScript>();
            doors_idx++;
        }
        
    }

    // have puzzle gameobject call this function
    public void CompleteRoom()
    {
        foreach (DoorScript door in doors)
        {
            door.setDoor(true);
            roomComplete = true;
        }

        // TODO - play unlock sound
    }

    public IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        CompleteRoom();
    }

}
