﻿using System.Collections;
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
    [SerializeField] private float stopAnimTimer = 0.3f;
    public GameObject exclamation;
    public float attackRange;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(Toolbox.Instance.GetLevelManager().CheckLevel() == "Level1") CommonTasks(states.Idle);
    }

    public void CommonTasks(states currentState) //want to pass this function to our UI 
    {
        if(State != null) State.End(); //ends all previous tasks
        if(this.enabled == true) ChangeState(currentState);
    }

    public void ChangeState(states newState)
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
                SetVision(new VisionState(this));
                break;
        }
       if(State != null) State.DoAction();
       if(StateVision != null) StateVision.DoAction();

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
