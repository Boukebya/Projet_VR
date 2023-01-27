using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;
    public float range = 100f;
    
     GameObject Find()
        {
            //find all enemies in range
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //find the closest enemy
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
            //if the closest enemy is in range, attack it
            if (closestDistance <= range)
            {
            return closestEnemy;
            }
            else
            {
            return null;
            }
        }

    void forward(GameObject closestEnemy){
        transform.LookAt(closestEnemy.transform);
        //speed has to get to the enemy in 1 second
        float speed = 10;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void Start()
    {
    //get damage from parent
    damage = transform.parent.GetComponent<Archer>().damage;
    }

    // Update is called once per frame
    void Update()
    {           
    //find the closest enemy
    GameObject close = Find();
    if (close != null){
        forward(close);
    }
    //if closestEnemy is null, destroy the arrow
    else{
        Destroy(gameObject);
    }
    
    }
    
    
    //if collides with enemy, destroy arrow
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
