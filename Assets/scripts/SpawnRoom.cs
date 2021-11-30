using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int doornum; // number of doors
    [SerializeField] GameObject[] rooms; // possible rooms to spawn

    void Start()
    {
        int i = Random.Range(0, rooms.Length-1); // Note: Range is min inclusive and max inclusive
        GameObject room = Instantiate(rooms[i], transform.position, transform.rotation);
        room.transform.parent = transform;
        if(room.layer == LayerMask.NameToLayer("ItemRoom"))
        {
            LevelManager.AddRoom(room);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
