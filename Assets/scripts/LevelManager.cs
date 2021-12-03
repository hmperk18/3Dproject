using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private static int maxRooms = 4;
    [SerializeField] GameObject[] itemRooms = new GameObject[maxRooms]; // list of possible item spawn locations

    private int roomsIdx; // next free spot in the rooms list

    private void Awake()
    {
        instance = this;
        roomsIdx = 0;
    }

    // add a room to the list of rooms
    public static void AddRoom(GameObject room)
    {
        instance._AddRoom(room);
    }

    private void _AddRoom(GameObject room)
    {
        Debug.Log("spawned room");
        Debug.Log(roomsIdx);
        
        itemRooms[roomsIdx] = room;
        roomsIdx += 1; 

        // on the last room the idx will be increased and match maxRooms
            // when the last room is added spawn the items
        if (roomsIdx == maxRooms)
        {
            // spawn some items in the last few item rooms
                // took long to add to more rooms away from the center
            for(int i = maxRooms - 1; i >= 1; i--)
            {
                Debug.Log("spawn item");
                itemRooms[i].GetComponent<ItemRoom>().SpawnItem();
            }
        }
    }

    //TODO: keys collected UI
}
