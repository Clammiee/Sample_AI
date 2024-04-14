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
        aI_System.agent.isStopped = true;
        aI_System.agent.SetDestination(aI_System.transform.position);
        FaceMovementDirection(aI_System.player, aI_System.gameObject, aI_System.rotationSpeed);
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
