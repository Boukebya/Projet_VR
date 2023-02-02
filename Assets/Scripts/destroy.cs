using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //destroy after 1 second
        Destroy(gameObject, delay);
    }
}
