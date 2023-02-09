using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosioneffect : MonoBehaviour
{

    void FixedUpdate()
    {
        //make it expanse with time and fade out
        transform.localScale += new Vector3(0.6f, 0.6f, 0.6f);
        GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 0.05f);
        
    }
}
