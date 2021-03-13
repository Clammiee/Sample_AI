using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        //any other method calls go here
        
    }

    public override void End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);

    }
}
