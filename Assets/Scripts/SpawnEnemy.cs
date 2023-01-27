using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
//prefab
public GameObject enemyPrefab;

public float delay = 1f;
    //coroutine
    IEnumerator Spawn()
    {
        while (true)
        {
            //spawn enemy
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            //wait 1 second
            yield return new WaitForSeconds(delay);
        }
    }
    //spawn enemy every 1 second
    void Start()
    {
        StartCoroutine(Spawn());
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
