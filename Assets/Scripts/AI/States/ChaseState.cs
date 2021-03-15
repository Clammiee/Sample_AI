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
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

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
        //animation 
        //Animate(this.gameObject, "Condition", false);
    }
}
