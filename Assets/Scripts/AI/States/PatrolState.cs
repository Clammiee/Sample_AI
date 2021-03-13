using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    public PatrolState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override IEnumerator Start()
    {
        aI_System.hitTrigger = true; //to let us to to the first waypoint (with below method)
        yield break;
    }

    public override IEnumerator DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        WayPointMovement();
        
        yield break;
    }

    private void WayPointMovement()
    {
        if(aI_System.waypointParent.transform.childCount > 0)
        {
            if(aI_System.waypointChildIterator == aI_System.waypointParent.transform.childCount) aI_System.waypointChildIterator = 0;

            if(aI_System.hitTrigger == true)
            {
                Vector3 destination = aI_System.waypointParent.transform.GetChild(aI_System.waypointChildIterator).transform.position;
                aI_System.agent.SetDestination(destination);

                aI_System.waypointChildIterator++;
                aI_System.hitTrigger = false;
            }
        }
    }

    public override IEnumerator End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
        
        yield break;
    }

}
