using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public static float maxHealth = 25;
    public float mHealth = maxHealth;
    public float health = maxHealth;
    
    public HealthBar healthBar;
    
    public float damageTaken = 0;
    //get position of displayer
    public Transform displayer;
    
    //prefab for the damage text
    public GameObject damageTextPrefab;


    // Update is called once per frame
    void Update()
    {
    MoveForward();
    }
    
    //Move forward with constant speed
    public void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }
    
    //take damage
    public void TakeDamage(float damage)
    {
        damageTaken = damage;
        health -= damageTaken;
        // instantiate damage text as a child of the enemy for 1 second
        GameObject damageText = Instantiate(damageTextPrefab, displayer.position, Quaternion.identity, transform);
        Destroy(damageText, 1f);
        
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.UpdateHealthBar();
    }
    
    // detect collision with projectile
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            //get damage from projectile
            float damage = collision.gameObject.GetComponent<Arrow>().damage;
            TakeDamage(damage);
        }
    }
}
