using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISystem : StateMachine, HitTrigger, IDead
{
    //public because we call these in other scripts (mainly specific state scripts)
    public enum states{Idle, Patrol, Chase, Attack, Vision};
    public GameObject waypointParent;
    [HideInInspector] public bool hitTrigger = false;
    [HideInInspector] public GameObject triggerWeHit;
    [HideInInspector] public int waypointChildIterator = 0;
    public NavMeshAgent agent;
    public float rotationSpeed = 5f;
    [HideInInspector] public GameObject player;
    public float visionRange;
    public float field_Of_View_Angle;
    [HideInInspector] public Vector3 forwardVector;
    [HideInInspector] public Vector3 upVector;
    [SerializeField] private float stopAnimTimer = 0.3f;
    public GameObject exclamation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetState(new IdleState(this));
        State.DoAction();
        forwardVector = Vector3.forward;
        upVector = Vector3.up;
    }

    public void CommonTasks(states currentState) //want to pass this function to our UI 
    {
        State.End(); //ends all previous tasks
        if(this.enabled == true) ChangeState(currentState);
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
            case states.Vision:
                SetState(new VisionState(this));
                break;
        }
        State.DoAction();

        StartCoroutine(StopAnim(stopAnimTimer));
    }

    private IEnumerator StopAnim(float time)
    {
        yield return new WaitForSeconds(time);
        State.StopAnimation();
    }

    public void OnHitTrigger(GameObject objWeHit)
    {
        hitTrigger = true;
        triggerWeHit = objWeHit;
        State.DoAction();
        StartCoroutine(StopAnim(stopAnimTimer));
    }

    public void Dead()
    {
        this.enabled = false;
    }

}
