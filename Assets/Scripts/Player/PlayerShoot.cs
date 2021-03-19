using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : PlayerInputs
{
    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if(ShootInput() == true)
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Shoot", true);
        }
        else 
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Shoot", false);
        }
    }

    private bool ShootInput()
    {
        if(base.InputDetection(playerActions.Attack) > 0f) return true;
        else return false;
    }
}
