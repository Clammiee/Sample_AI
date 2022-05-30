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
    [SerializeField] private float stopAnimTimer;
    [Tooltip("Needs to be higher than Stop Anim Timer")]
    [SerializeField] private float stayDeadTimer;
    [SerializeField] private bool isPlayerCharacter = true;
    [SerializeField] private Rigidbody rb;

    private float healthDecimal;

    public void Damage(float amount)
    {
        health = health - amount;
        healthDecimal = health/maxHealth;

        if(health <= 0)
        {
            healthDecimal = 0f;
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Dead", true);
                
             //So that the AI/ Player stays dead and cant function anymore
             IDead iDead = this.GetComponent<IDead>();
             if(iDead != null) iDead.Dead();

            StartCoroutine(StayDead(stayDeadTimer)); 
        }
        else 
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Hurt", true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            StartCoroutine(StopAnim(stopAnimTimer));
        }
        healthBar.fillAmount = healthDecimal;
    }

    private IEnumerator StopAnim(float time)
    {
        yield return new WaitForSeconds(time);
        AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Hurt", false);
        AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Dead", false);
        if (isPlayerCharacter == true) rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        else rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    private IEnumerator StayDead(float time)
    {
        yield return new WaitForSeconds(time);
        AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Dead", true);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
