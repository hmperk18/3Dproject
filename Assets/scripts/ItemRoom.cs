using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoom : MonoBehaviour
{
    [SerializeField] GameObject item;
    public void SpawnItem()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }
}
