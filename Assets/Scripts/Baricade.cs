using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baricade : MonoBehaviour
{
    public float damage;
    public float critChance = 0.05f;
    public float slow = 0.3f;  
    
    public GameObject baricade;
    
    //on collision with enemy
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //deal damage to enemy
                collision.gameObject.GetComponent<Stat>().TakeDamage(damage,0);
            }
        }
}
