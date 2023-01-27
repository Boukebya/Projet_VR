using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Stat entity;
    
    public void UpdateHealthBar() {
    //print health and mHealth to console
    float fillAmount = (float)entity.health / (float)entity.mHealth;
    //print(fillAmount);
    // divide current health by max health to get a percentage and normalize it to 0-1
    healthBarImage.fillAmount = fillAmount;
    
    }
    
    void Update() {
    //make the gealth bat face the camera
    transform.LookAt(Camera.main.transform);
    transform.Rotate(0, 180, 0);
    }
    
    
    
}
