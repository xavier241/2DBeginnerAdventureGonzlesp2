using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Other)
    {
        Playercontroller controller = Other.GetComponent<Playercontroller>();
        if (controller != null)
        {
            if (controller.Health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);

            }
            
        }
        Debug.Log("Object that enterd the trigger is: " + Other);  
    }
}
