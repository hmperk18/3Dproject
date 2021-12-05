using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoom : MonoBehaviour
{
    [SerializeField] GameObject[] items;

    // use idx of item room to determine which color book to spawn
        // this will chose a diff color for each room
    public void SpawnItem(int item_idx)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        // used % length bc there are more rooms than possible book colors
        Instantiate(items[item_idx % items.Length], pos, Quaternion.identity);
    }
}
