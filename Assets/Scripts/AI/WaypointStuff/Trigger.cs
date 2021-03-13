using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            HitTrigger hitTrigger = other.gameObject.GetComponent<HitTrigger>();
            if(hitTrigger != null) hitTrigger.OnHitTrigger(this.gameObject);
        }
    }
}
