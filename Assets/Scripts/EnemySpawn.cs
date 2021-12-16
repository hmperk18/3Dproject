using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Testing to see if it can spawn an enemy. Can be delted.
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyGo;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateEnemy();
    }

    void InstantiateEnemy()
    {
        GameObject currentEnemy = (GameObject)Instantiate(enemyGo);
        currentEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        StartCoroutine("waitForFewSeconds");
    }

    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(10.0f);
        InstantiateEnemy();
    } 
}
