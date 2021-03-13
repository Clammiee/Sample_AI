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
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

    }

    public override void End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
    }
}
