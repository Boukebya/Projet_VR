using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGun : MonoBehaviour
{
    public float damage;
    public float critChance;
    public float range = 10;
    // line renderer
    public LineRenderer lineRenderer;
    //particle
    public GameObject particle;
    
    // Start is called before the first frame update
    void Start()
    {
             //set damage to parent's damage
                damage = transform.parent.GetComponent<Archer>().damage;
              //set range to parent's range
                range = transform.parent.GetComponent<Archer>().range;
                //set critChance to parent's critChance
                critChance = transform.parent.GetComponent<Archer>().critChance;
    }
    
    //find nearest enemy in range
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
    

    void FixedUpdate()
    {
    bool asShot = false;
    // draw line to target and deal damage
        GameObject target = Find();
        if (target != null && !asShot)
        {
        asShot = true;
            //draw line to target
            lineRenderer.enabled = true;
            //draw line from firepoint to random point on target
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.transform.position);
            //create particle at target size divided by 4
            GameObject particleInstance = Instantiate(particle, target.transform.position, target.transform.rotation);
            particleInstance.transform.localScale = target.transform.localScale / 4;
            
            
            //deal damage one time only
            target.GetComponent<Stat>().TakeDamage(damage, critChance);
            //sépare l'objet de son parent
            transform.parent = null;
            
        }
        Destroy(gameObject,0.1f );
    }

}
