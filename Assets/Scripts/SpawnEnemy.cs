using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
//prefab
public GameObject basic;
public GameObject tank;

public float delay = 1f;
    //coroutine
    IEnumerator Spawn()
    {
        while (true)
        {
            //spawn 10 basic enemies, then 1 tank
            for (int i = 0; i < 10; i++)
            {
                Instantiate(basic, transform.position, transform.rotation);
                yield return new WaitForSeconds(delay);
            }
            Instantiate(tank, transform.position, transform.rotation);
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
