using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public static float maxHealth = 25;
    public float mHealth = maxHealth;
    public float health = maxHealth;
    public bool isCrit = false;
    public int armor = 0;
    public float armorReduction = 0;
    public float speed = 10;
    public float actualSpeed;
    
    public bool isSlowed = false;
    
    //death effect
    public GameObject deathEffect;
    
    public HealthBar healthBar;
    
    public float damageTaken = 0;
    //get position of displayer
    public Transform displayer;
    
    //prefab for the damage text
    public GameObject damageTextPrefab;
    //color
    public Color color;


    //Change Color and size for a short time
    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(ResetColor());
        //change randomly the size of the object between 0.9 and 1.1   
    }
    //Reset Color and size
    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.05f);
        //get back to the original color not white
        GetComponent<Renderer>().material.color = color;

    }
    
    //take damage
    public void TakeDamage(float damage, float critChance)
    {
        //on hit change to red for 0.1 seconds
        ChangeColor();
        
        //get armor reduction
        armorReduction = 1 - (Mathf.Log(armor + 1, 2) / 10);
        damageTaken = damage * armorReduction;
        //chance to crit depending on crit chance
        float crit = Random.Range(0f, 1f);
        if (crit <= critChance)
        {
            damageTaken *= 2;
            isCrit = true;
        }
        health -= damageTaken;
        
        
        // instantiate damage text as a child of the enemy for 1 second
        GameObject damageText = Instantiate(damageTextPrefab, displayer.position, Quaternion.identity, transform);
        healthBar.UpdateHealthBar();
        
        //death
        if (health <= 0)
        {
            Destroy(gameObject,0.01f);
            //instantiate death effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
    

 
    
    //while colliding with baricade
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Baricade")
        {
            isSlowed = true;   
        }
    }
    
    
    void Update()
    {
        if (isSlowed)
        {
            actualSpeed = speed * 0.2f;
        }
        else
        {
            actualSpeed = speed;
        }
        isSlowed = false;
        
    }
}
