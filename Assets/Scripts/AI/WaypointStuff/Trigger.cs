using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //create interface to say that we hit a trigger
        }
    }
}
