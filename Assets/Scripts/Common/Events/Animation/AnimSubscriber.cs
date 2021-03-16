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

    public void SetOnPlayAnimation(string condition, bool boolean)
    {
        animator.SetBool(condition, boolean);
    }
}
