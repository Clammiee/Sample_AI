﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void DoAction()
    {   
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Idle", true);
    }

    public override void End()
    {    
        AnimationEvents.TriggerOnPlayAnimation(aI_System.gameObject, "Idle", false);
    }
}
