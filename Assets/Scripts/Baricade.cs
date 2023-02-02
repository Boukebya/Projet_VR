using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baricade : MonoBehaviour
{
    public float damage;
    public float critChance = 0.05f;
    public float slow = 0.3f;  
    public float delay;
    bool onCooldown = false;
    
    public GameObject baricade;
    
    //on collision with enemy
        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //deal damage every delay
                if (!onCooldown)
                {
                    //damage enemy
                     collision.gameObject.GetComponent<Stat>().TakeDamage(damage, critChance);
                    StartCoroutine(Cooldown());
                }
                //slow enemy
                collision.gameObject.GetComponent<Stat>().isSlowed = true;
                collision.gameObject.GetComponent<Stat>().actualSpeed = collision.gameObject.GetComponent<Stat>().speed * slow;
                
            }
        }
        //on collision exit
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Stat>().isSlowed = false;
                collision.gameObject.GetComponent<Stat>().actualSpeed = collision.gameObject.GetComponent<Stat>().speed;
            }
        }
        
        //coroutine for cooldown
        IEnumerator Cooldown()
        {
            onCooldown = true;
            yield return new WaitForSeconds(delay);
            onCooldown = false;
        }
        
}
