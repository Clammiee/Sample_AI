using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    public PatrolState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void Start()
    {
        aI_System.hitTrigger = true; //to let us to to the first waypoint (with below method)
    }

    public override void DoAction()
    {   
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Run", true);
        WayPointMovement();
    }

    private void WayPointMovement()
    {
        if(aI_System.waypointParent.transform.childCount > 0)
        {
            if(aI_System.waypointChildIterator == aI_System.waypointParent.transform.childCount) aI_System.waypointChildIterator = 0;

            if(aI_System.hitTrigger == true)
            {
                GameObject destination = aI_System.waypointParent.transform.GetChild(aI_System.waypointChildIterator).gameObject;
                aI_System.agent.SetDestination(destination.transform.position);
                FaceMovementDirection(destination, aI_System.gameObject, aI_System.rotationSpeed);

                aI_System.waypointChildIterator++;
                aI_System.hitTrigger = false;
            }
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
