using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public static int health = 100;
    public static int money = 100;
    public TMP_Text text_hp;
    public TMP_Text text_money;
    
    public GameObject Archer;
    
   
    //function to instantiate a new tower at mouse position
    public void InstantiateTower(GameObject tower)
    {
        //if the player has enough money
        if (money >= tower.GetComponent<Archer>().cost)
        {
            //shoot a ray from the camera to the mouse position if it hit floor, spawn tower at that position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Floor")
                {
                    //add +1 to z of hit.point 
                    hit.point += new Vector3(0, 0, 1);
                    //hit is where to spawn the tower with 0 rotation
                    Instantiate(tower, hit.point, Quaternion.identity);
                    
                    //subtract the cost of the tower from the player's money
                    money -= tower.GetComponent<Archer>().cost;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            //if hp 0 text hp equals dead
            if (health <= 0)
            {
                text_hp.text = "Dead, change scene idk..";
            }
            else{
        //display the money
        text_money.text = money.ToString();
        //display the hp
        text_hp.text = health.ToString();
        
         if (Input.GetMouseButtonDown(0))
                {
                    //spawn Archer prefab
                    InstantiateTower(Archer);
                }
             }

    }
    
    
}
