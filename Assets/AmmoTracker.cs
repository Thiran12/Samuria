using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracker : MonoBehaviour
{
    public Weapon PlayerWeapon;
    public Text AmmoText;
   

    // Update is called once per frame
    void Update()
    {
        if (PlayerWeapon != null)
        {
            AmmoText.text = PlayerWeapon.Ammocount.ToString();
        }

        
    }
}
