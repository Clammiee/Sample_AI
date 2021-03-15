using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamagable
{
    [Tooltip("Make this the same as the Health")]
    [SerializeField] private float maxHealth = 100f;
    [Tooltip("Make this the same as the Max Health")]
    [SerializeField] private float health = 100f;
    [Tooltip("Drag in health bar as child of canvas")]
    [SerializeField] private Image healthBar;

    private float healthDecimal;

    public void Damage(float amount)
    {
        health = health - amount;
        healthDecimal = health/maxHealth;

        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            healthDecimal = 0f;
        }
        healthBar.fillAmount = healthDecimal;
    }

   /* private void LookAtCam()
    {
        Vector3 vector = cam.transform.position - damageChild.transform.position;
        vector.x = vector.z = 0.0f;
        damageChild.transform.LookAt(cam.transform.position - vector); 
        damageChild.transform.Rotate(0,180,0);
    }*/
}
