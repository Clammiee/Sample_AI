using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISystem : StateMachine, HitTrigger
{
    //public because we call these in other scripts (mainly specific state scripts)
    public enum states{Idle, Patrol, Chase, Attack};
    public GameObject waypointParent;
    [HideInInspector] public bool hitTrigger = false;
    [HideInInspector] public GameObject triggerWeHit;
    [HideInInspector] public int waypointChildIterator = 0;
    public NavMeshAgent agent;
    public float rotationSpeed = 5f;
    public GameObject gunTip;
    [HideInInspector] public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetState(new IdleState(this));
        State.DoAction();
    }

//----------- UI STUFF ------------------// 
    public void IdleButton()
    {
        CommonTasks(states.Idle);
    }

    public void PatrolButton()
    {
        CommonTasks(states.Patrol);
    }

    public void ChaseButton()
    {
        CommonTasks(states.Chase);
    }

    public void AttackButton()
    {
        CommonTasks(states.Attack);
    }
        
//-----------  ------------------// 

    
    public void CommonTasks(states currentState) //want to pass this function to our UI 
    {
        State.End(); //ends all previous tasks
        ChangeState(currentState);
    }

    private void ChangeState(states newState)
    {
        switch(newState)
        {
            case states.Idle:
                SetState(new IdleState(this));
                break;
            case states.Patrol:
                SetState(new PatrolState(this));
                break;
            case states.Chase:
                SetState(new ChaseState(this));
                break;
            case states.Attack:
                SetState(new AttackState(this));
                break;
        }
        State.DoAction();
    }
    
    //public because used in interface script
    public void OnHitTrigger(GameObject objWeHit)
    {
        hitTrigger = true;
        triggerWeHit = objWeHit;
        State.DoAction();
    }

}
