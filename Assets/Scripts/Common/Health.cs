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

    private float healthDecimal;
    private int dieOnce = 0;

    public void Damage(float amount)
    {
        health = health - amount;
        healthDecimal = health/maxHealth;

        if(health <= 0)
        {
            if(dieOnce == 0)
            {
                healthDecimal = 0f;
                AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Dead", true);
                //Add Interface that disables all script functionalities so that the AI or player stays dead
                dieOnce++;
            }
            StartCoroutine(StopAnim(stopAnimTimer));
            StartCoroutine(StayDead(stayDeadTimer));
        }
        else 
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Hurt", true);
            StartCoroutine(StopAnim(stopAnimTimer));
        }
        healthBar.fillAmount = healthDecimal;
    }

    private IEnumerator StopAnim(float time)
    {
        yield return new WaitForSeconds(time);
        AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Hurt", false);
        AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Dead", false);
    }

    private IEnumerator StayDead(float time)
    {
        yield return new WaitForSeconds(time);
        AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Idle", false);
    }
}
