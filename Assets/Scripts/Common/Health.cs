using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [Tooltip("Make this the same as the Health")]
    [SerializeField] private float maxHealth = 100f;
    [Tooltip("Make this the same as the Max Health")]
    [SerializeField] private float health = 100f;

    public void Damage(float amount)
    {
        health = health - amount;

        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
