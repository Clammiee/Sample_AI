using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State State;

    protected State StateVision;

    public void SetState(State state)
    {
        State = state;
        State.Start();
    }

    public void SetVision(State stateVision)
    {
        StateVision = stateVision;
        StateVision.Start();
    }

    //get state?

    //second state?
}
