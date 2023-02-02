using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;
    public float critChance;
    public float range = 100f;
    public float speed = 15f;
    GameObject close;
    //particles
    public GameObject impactEffect;
    
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

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void Start()
    {
    //get damage from parent
    damage = transform.parent.GetComponent<Archer>().damage;
    //get crit chance from parent
    critChance = transform.parent.GetComponent<Archer>().critChance;
    close = Find();

    }

    // Update is called once per frame
    void Update()
    {           
    //find the closest enemy
    GameObject stillClose = Find();
    //speed is getting faster
    speed += 0.1f;
    
    if (stillClose != null && stillClose == close){
        forward(close);
    }
    else{
        //continue forward
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    
    }
    //function to deal damage
    void DealDamage(GameObject enemy)
    {
        //deal damage
        enemy.GetComponent<Stat>().TakeDamage(damage, critChance);
    }
    
    //if collides with enemy, destroy arrow
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor")
        {
            //deal damage
            DealDamage(collision.gameObject);
            Destroy(gameObject);
        }
    }
    //on destroy
    void OnDestroy()
    {
        // spawn particle effect
        Instantiate(impactEffect, transform.position, transform.rotation);        
    }
}
