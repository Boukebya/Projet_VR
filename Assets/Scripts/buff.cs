using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour
{
    public float multiplier;
    
    //in the range, all enemies get speed buff one time, if they leave the range, they lose the buff
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Stat>().actualSpeed *= multiplier;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Stat>().actualSpeed = other.gameObject.GetComponent<Stat>().speed;
        }
    }
}
