using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade : MonoBehaviour
{
    public float damageMultiplier = 1;
    public float fixedDamage = 5;
    
    public int costMultiplier = 1;
    public int fixedCost = 5;
    
    public float rangeMultiplier = 1;
    public float fixedRange = 5;
    
    public float attackSpeedMultiplier = 1;
    public float fixedAs = 5;
    
    public float critChanceMultiplier = 1;
    public float fixedcrit = 5;
    

    void Upgrade()
    {
         // get level from archer script gameobject
        int level = GetComponent<Archer>().level;
        // get cost from archer script gameobject
        int cost = GetComponent<Archer>().cost;
        // get damage from archer script gameobject
        float damage = GetComponent<Archer>().damage;
        // get range from archer script gameobject
        float range = GetComponent<Archer>().range;
        // get attack speed from archer script gameobject
        float attackSpeed = GetComponent<Archer>().attackSpeed;
        // get crit chance from archer script gameobject
        float critChance = GetComponent<Archer>().critChance;
        
        //if player has enough money
        if (Player.money >= cost)
        {
            Player.money -= cost;
            //upgrade the tower
            level++;
            //increase the cost, so it's more and more expensive to upgrade
            cost = fixedCost + (cost * costMultiplier);
            //increase the damage
            damage = fixedDamage + (damage * damageMultiplier);
            //increase the range
            range = fixedRange + (range * rangeMultiplier);
            //increase the attack speed
            attackSpeed = fixedAs + (attackSpeed * attackSpeedMultiplier);
            //increase the crit chance
            critChance = fixedcrit + (critChance * critChanceMultiplier);
            
            //print the new stats
            print("Level: " + level);
            print("Damage: " + damage);
            print("Range: " + range);
            print("Attack Speed: " + attackSpeed);
            print("Crit Chance: " + critChance);
            //change Archer script values
            GetComponent<Archer>().level = level;
            GetComponent<Archer>().cost = cost;
            GetComponent<Archer>().damage = damage;
            GetComponent<Archer>().range = range;
            GetComponent<Archer>().attackSpeed = attackSpeed;
            GetComponent<Archer>().critChance = critChance;
            
        }
        else
        {
            print("Not enough money");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        //if player clicks on tower
        if (Input.GetMouseButtonDown(0))
        {

        
            //get mouse position
            Vector3 mousePos = Input.mousePosition;
            //convert mouse position to world position
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            //cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            //if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                //if the ray hits the tower
                if (hit.collider.gameObject == gameObject)
                {
                    //upgrade the tower
                    Upgrade();
                }
            }
        }
         
    }
}
