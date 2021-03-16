using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected AISystem aI_System;

    public State(AISystem aISystem)
    {
        aI_System = aISystem;
    }
        
    public virtual void Start()
    {
    }

    public virtual void DoAction()
    {
    }

    public virtual void End()
    {
    }

//--- COMMON FUNCTIONALITIES WITHIN THE STATES -----------------//

    protected void FaceMovementDirection(GameObject goal, GameObject AI, float rotationSpeed)
    {
        if(goal != null && AI != null && rotationSpeed > 0)
        {
            var lookPos = goal.transform.position - AI.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            AI.transform.rotation = Quaternion.Slerp(AI.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
