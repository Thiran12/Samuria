using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthTracker : MonoBehaviour
{

    public Enemy Boss;
    public Slider slider;
    
   
    void Update()
    {
        slider.maxValue = Boss.maxHealth;
        slider.value = Boss.currentHealth;
    }
}
