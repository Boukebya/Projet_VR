using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageDisplayer : MonoBehaviour
{
    //textmeshPro text component
    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        //get the damage from parent
        float damage = transform.parent.GetComponent<Stat>().damageTaken;
        //get isCrit
        bool isCrit = transform.parent.GetComponent<Stat>().isCrit;
        
        // arrondir le damage au dixieme le plus proche
        damage = Mathf.Round(damage * 10f) / 10f;
        //display the damage
        text.text = damage.ToString();
        
        //if isCrit, change color to red
        if (isCrit)
        {
            text.color = Color.red;
        }
        //destroy the text after 1 second
        Destroy(gameObject, 1f);
        //separate the text from the parent
        transform.parent = null;
    }
    
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        //move on the y axis 
        transform.position += new Vector3(0, 0.07f, 0);
        // do a sin wave on the x axis
        transform.position += new Vector3(Mathf.Sin(Time.time) * 0.07f, 0, 0);
        // fade within 1 second
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.MoveTowards(text.color.a, 0, Time.deltaTime));
        
        
    }

}
