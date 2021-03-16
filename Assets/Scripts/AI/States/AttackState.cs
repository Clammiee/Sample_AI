using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void DoAction()
    {   
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Shoot", true);   
    }
    
    public override void End()
    {
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Shoot", false);
    }

    public override void StopAnimation()
    {
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Shoot", false);
    }
}
