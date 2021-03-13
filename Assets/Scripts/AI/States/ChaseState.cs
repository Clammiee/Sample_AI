using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    private GameObject player;

    public ChaseState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if(player != null)
        {
            aI_System.agent.SetDestination(player.transform.position);
            FaceMovementDirection(player, aI_System.gameObject, aI_System.rotationSpeed);
        }
    }

    public override void End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
    }
}
