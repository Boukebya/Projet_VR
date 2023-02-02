using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public int damage;
    public float attackSpeed;
    public float range = 100;
    public float critChance = 0.05f;
    
    public Transform firePoint;
    public GameObject arrowPrefab;
    //get line renderer from children
    public LineRenderer lineRenderer;
    
    //function to find the closest enemy
    void Find()
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
            Attack(closestEnemy);
        }
    }
    
    // function attack is on cooldown
    bool onCooldown = false;
    void Attack(GameObject enemy)
    {
        if (!onCooldown)
        {
            //shoot an arrow at the enemy as child of Archer
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation, transform);
            
            //start cooldown
            StartCoroutine(Cooldown());
        }
    }
    //coroutine for cooldown
    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(attackSpeed);
        onCooldown = false;
    }

    //function if cursor is over the archer, show range, in 3d
     void OnMouseOver()
     {
        //turn red
        GetComponent<Renderer>().material.color = Color.red;  
        //show range in circle
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 360;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        for (int i = 0; i < 360; i++)
        {
            float angle = i * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * range;
            float z = Mathf.Sin(angle) * range;
            lineRenderer.SetPosition(i, new Vector3(x, 0, z));
        }     
        //if left mouse button is pressed upgrade tower by increasing range,damage and attack speed
        if (Input.GetMouseButtonDown(0))
        {
            range += 10;
            damage += 10;
            attackSpeed -= 0.1f;
            critChance += 0.2f;
        }
                  
     }

        void OnMouseExit()
        {
            //turn white
            GetComponent<Renderer>().material.color = Color.white;
            //hide range
            lineRenderer.enabled = false;
        }
    // Update is called once per frame
    void Update()
    {
        Find();
    }
}
