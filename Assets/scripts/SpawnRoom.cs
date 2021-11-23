using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int doornum; // number of doors
    [SerializeField] GameObject[] rooms; 

    void Start()
    {
        int i = Random.Range(0, rooms.Length);
        GameObject room = Instantiate(rooms[i], transform.position, transform.rotation);
        room.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
