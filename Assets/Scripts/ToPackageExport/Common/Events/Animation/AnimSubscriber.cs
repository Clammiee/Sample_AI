using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSubscriber : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    void Awake()
    {
        AnimationEvents.OnPlayAnimation += SetOnPlayAnimation;
    }

    private void OnDestroy() 
    {
        AnimationEvents.OnPlayAnimation -= SetOnPlayAnimation;
    }

    public void SetOnPlayAnimation(GameObject obj, string condition, bool boolean)
    {
        if(this.gameObject == obj) animator.SetBool(condition, boolean);
    }

    public void Shoot() //attach to shooting animation as an event
    {
        ActionEvents.TriggerOnShootBullet(this.gameObject);
    }
}
