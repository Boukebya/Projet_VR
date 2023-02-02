using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
//prefab
public GameObject basic;
public GameObject soldier;
public GameObject tank;
public GameObject Elite;
public GameObject flying;
public GameObject mage;
public GameObject Commander;

public float delay = 1f;

    void Spawn()
    {
            //if pressed 1 spawn basic enemy
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Instantiate(basic, transform.position, transform.rotation);
            }
            //if pressed 2 spawn soldier enemy
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Instantiate(soldier, transform.position, transform.rotation);
            }
            //if pressed 3 spawn tank enemy
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Instantiate(tank, transform.position, transform.rotation);
            }
            //if pressed 4 spawn elite enemy
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Instantiate(Elite, transform.position, transform.rotation);
            }
            //if pressed 5 spawn flying enemy
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Instantiate(flying, transform.position, transform.rotation);
            }
            //if pressed 6 spawn mage enemy
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Instantiate(mage, transform.position, transform.rotation);
            }
            //if pressed 7 spawn commander enemy
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Instantiate(Commander, transform.position, transform.rotation);
            }
    }
    

    void Update()
    {
       Spawn(); 
    }
}
