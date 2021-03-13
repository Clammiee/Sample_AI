using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override IEnumerator DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        //any other method calls go here
        
        yield break;
    }

    public override IEnumerator End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
        
        yield break;
    }
}
