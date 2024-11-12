using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
     void OnTriggerstay2d(Collider2D other)
    {
        Playercontroller controller = other.GetComponent<Playercontroller>();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
        
    }

}
