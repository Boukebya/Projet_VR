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
    
    void SpawnSelf()
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

   
    IEnumerator SpawnWave()
    {
        StartCoroutine(Wave());
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
        yield return new WaitForSeconds(5f);
        wave++;
        isOver = true;
    }
    
    IEnumerator Wave()
    {
    
        //spawn enemies in list enemies
        foreach (GameObject enemy in enemies)
        {
            InstantiateEnemy(enemy);
            yield return new WaitForSeconds(0.25f);
        }
        
     //if wave modulo 1, add 1 basic enemy to list enemies
        if (wave % 1 == 0)
        {
            enemies.Add(basic);
        }
        //if wave modulo 2, add 1 soldier enemy to list enemies
        if (wave % 3 == 0)
        {
            enemies.Add(soldier);
        }
        //if wave modulo 3, add 1 tank enemy to list enemies
        if (wave % 5 == 0)
        {
            enemies.Add(tank);
        }
        //if wave modulo 4, add 1 Elite enemy to list enemies
        if (wave % 7 == 0)
        {
            enemies.Add(Elite);
        }
        //if wave modulo 5, add 1 flying enemy to list enemies
        if (wave % 8 == 0)
        {
            enemies.Add(flying);
        }
        //if wave modulo 6, add 1 mage enemy to list enemies
        if (wave % 10 == 0)
        {
            enemies.Add(mage);
        }
        //if wave modulo 7, add 1 Commander enemy to list enemies
        if (wave % 15 == 0)
        {
            enemies.Add(Commander);
        }     
    }
    
   
    //liste of enemies
    List<GameObject> enemies = new List<GameObject>();    
    bool isOver = true;
    int wave = 1;
    
    void Start()
    {
        enemies.Add(basic);
        enemies.Add(basic);
        enemies.Add(soldier);
    }
    
    void Update()
    {
       // spawn 1 more enemy every wave, each wave ends when all enemies are dead and after 5 seconds
       // enemy spawn is spaced out by 0.15f
        if (isOver)
        {
            isOver = false;
            print("Wave " + wave);
            StartCoroutine(SpawnWave());
        }
    }
}
