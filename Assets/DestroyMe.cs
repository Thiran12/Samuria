using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float LifeTime = 3f;
    float shootTime;
   

    private void Update()
    {
        shootTime += Time.deltaTime;
        if (shootTime > LifeTime)
        {

            GameObject.Destroy(gameObject);
          
        }
    }
}
