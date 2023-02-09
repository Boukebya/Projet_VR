using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float damage;
    public float critChance;
    public float range = 10;
    public float explosionRadius = 5f;
    
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    
    // explosion effect
    public GameObject explosion;
    
    //on destroy, instantiate explosion effect
    void OnDestroy()
    {
       // instantiate and make it its own child
        GameObject explosionEffect = Instantiate(explosion, transform.position, transform.rotation);
        explosionEffect.transform.parent = transform;
       }

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
        
        
    public void Fire(GameObject targetobj)
                {
                    //get transform of target
                    Transform target = targetobj.transform;
                    // look at the target
                    transform.LookAt(target);
                    // Calculate distance to target
                    float targetDistance = Vector3.Distance(transform.position, target.position);
            
                    // Calculate the velocity needed to throw the object to the target at specified angle.
                    float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
            
                    // Extract the X  Y componenent of the velocity
                    float Vx = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
                    float Vy = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
            
                    // Calculate flight time.
                    float flightDuration = targetDistance / Vx;
            
                    
            
                    // Launch projectile in direction of target with specified force.
                    GetComponent<Rigidbody>().velocity = transform.forward * Vx;
                    GetComponent<Rigidbody>().velocity += Vector3.up * Vy;
                    
                    
            
                    Destroy(gameObject, flightDuration+0.5f);
                }
       
       void Explode(){
       // Expanding sphere collider
         Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.tag == "Enemy")
                {
                    //absolute value of distance between enemy and shell
                    float distance = Mathf.Abs(Vector3.Distance(transform.position, hitColliders[i].transform.position));
                    
                    //damageDealt is inversely proportional to distance and is capped at 0.4
                    float damageMultiplier = Mathf.Clamp(1 - (distance / explosionRadius), 0.4f, 1);
                    float damageDealt = damage * damageMultiplier;
                    //print damage and distance and multiplier
                    //print("Damage dealt: " + damageDealt + " Distance: " + distance + " Multiplier: " + damageMultiplier);
                    hitColliders[i].gameObject.GetComponent<Stat>().TakeDamage(damageDealt, critChance);
                }
                i++;
                
            }
            
            //destroy the shell
            Destroy(gameObject,0.016f);
       }
       
       
    void Start()
    {
     //set damage to parent's damage
        damage = transform.parent.GetComponent<Archer>().damage;
      //set range to parent's range
        range = transform.parent.GetComponent<Archer>().range;
        //set critChance to parent's critChance
        critChance = transform.parent.GetComponent<Archer>().critChance;
        
      GameObject enemy = Find();
      // direct the shell towards the enemy
        if (enemy != null)
        {
            transform.LookAt(enemy.transform);
        }
        // give the shell a force depending on distance
        if (enemy != null)
        {
            Fire(enemy);
            
        }
    }
    
    // on collision with enemy or floor, destroy the shell
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor")
        {
            //turn red
            GetComponent<Renderer>().material.color = Color.red;
            Explode();
        }
    }
}
