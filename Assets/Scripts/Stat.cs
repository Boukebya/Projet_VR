using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public static float maxHealth = 25;
    public float mHealth = maxHealth;
    public float health = maxHealth;
<<<<<<< HEAD
    public bool isCrit = false;
    public int armor = 0;
    public float armorReduction = 0;
    public float speed = 10;
    
    //death effect
    public GameObject deathEffect;
=======
>>>>>>> parent of 4123b84 (Tower, movement mechanic, stat)
    
    public HealthBar healthBar;
    
    public float damageTaken = 0;
    //get position of displayer
    public Transform displayer;
    
    //prefab for the damage text
    public GameObject damageTextPrefab;


<<<<<<< HEAD
    //Change Color and size for a short time
    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(ResetColor(color));
        //change randomly the size of the object between 0.9 and 1.1   
    }
    //Reset Color and size
<<<<<<< HEAD
    IEnumerator ResetColor()
=======
    // Update is called once per frame
    void Update()
=======
    IEnumerator ResetColor(Color color)
>>>>>>> parent of 76149be (damage adaptation and baricade)
    {
    MoveForward();
    }
    
    //Move forward with constant speed
    public void MoveForward()
>>>>>>> parent of 4123b84 (Tower, movement mechanic, stat)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }
    
    //take damage
    public void TakeDamage(float damage)
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
        //get color of the object
        Color color = GetComponent<Renderer>().material.color;
>>>>>>> parent of 76149be (damage adaptation and baricade)
        //on hit change to red for 0.1 seconds
        ChangeColor(color);
        
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
<<<<<<< HEAD
=======
        damageTaken = damage;
>>>>>>> parent of 4123b84 (Tower, movement mechanic, stat)
        health -= damageTaken;
        
=======

>>>>>>> parent of 76149be (damage adaptation and baricade)
        
        health -= damageTaken;
        // instantiate damage text as a child of the enemy for 1 second
        GameObject damageText = Instantiate(damageTextPrefab, displayer.position, Quaternion.identity, transform);
        Destroy(damageText, 1f);
        
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
        healthBar.UpdateHealthBar();
>>>>>>> parent of 4123b84 (Tower, movement mechanic, stat)
=======
        
>>>>>>> parent of 76149be (damage adaptation and baricade)
    }
    
    // detect collision with projectile
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
            //get damage from projectile
            float damage = collision.gameObject.GetComponent<Arrow>().damage;
            TakeDamage(damage);
        }
    }
>>>>>>> parent of 4123b84 (Tower, movement mechanic, stat)
=======
            //get damage from projectile
            float damage = collision.gameObject.GetComponent<Arrow>().damage;
            //get crit chance from projectile
            float critChance = collision.gameObject.GetComponent<Arrow>().critChance;
            TakeDamage(damage, critChance);
        }
    }
    
>>>>>>> parent of 76149be (damage adaptation and baricade)
}
