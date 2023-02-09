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

    //gameobject path left
    public GameObject pathLeft;
    //gameobject path right
    public GameObject pathRight;
    //gameobject path inner
    public GameObject pathInner;
    
    //function to give random path
    public GameObject RandomPath()
    {
        return new GameObject[] {pathLeft, pathRight, pathInner}[Random.Range(0, 3)];
    }
    public void InstantiateEnemy(GameObject enemy)
    {
        GameObject path = RandomPath();
        Instantiate(enemy, path.transform.GetChild(0).position, transform.rotation).GetComponent<Movement>().path = path;
    }
    
    void Spawn()
    {
            //wait for input from 1 to 7
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                InstantiateEnemy(basic);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                InstantiateEnemy(soldier);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                InstantiateEnemy(tank);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                InstantiateEnemy(Elite);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                InstantiateEnemy(flying);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                InstantiateEnemy(mage);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                InstantiateEnemy(Commander);
            }
    }
    

    void Update()
    {
       Spawn(); 
    }
}
