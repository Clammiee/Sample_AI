using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{

    public ChaseState(AISystem aISystem) : base(aISystem)
    {        
    }


    public override void DoAction()
    {   
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Run", true);

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if(aI_System.player != null)
        {
            aI_System.agent.SetDestination(aI_System.player.transform.position);
            FaceMovementDirection(aI_System.player, aI_System.gameObject, aI_System.rotationSpeed);
        }
    }

    public override void End()
    {    
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Run", false);
    }

    public override void StopAnimation()
    {
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Run", false);
    }
}
