using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PatrolState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override IEnumerator DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        //any other method calls go here
        WayPointMovement();
        
        yield break;
    }

    private void WayPointMovement()
    {
        if(aI_System.waypointParent.transform.childCount > 0)
        {
            if(aI_System.hitTrigger == true)
            {
                //set navagent next child of waypointParent (waypointChildIterator) as destination
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
