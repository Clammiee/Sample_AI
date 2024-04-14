using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAIStateChange : MonoBehaviour
{
    [SerializeField] private AISystem aISystem;
    private int unawareCount;
    private GameObject player;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        aISystem.ChangeState(AISystem.states.Vision);

        if(aISystem.exclamation.activeInHierarchy && aISystem.rb.constraints != RigidbodyConstraints.FreezeAll)
        {
            if (player != null && Vector3.Distance(this.gameObject.transform.position, player.transform.position) <= aISystem.attackRange)
            {
                aISystem.CommonTasks(AISystem.states.Attack);
            }
            else
            {
                aISystem.CommonTasks(AISystem.states.Chase);
            }
            unawareCount = 0;
        } 
        else if(aISystem.exclamation.activeInHierarchy == false && aISystem.rb.constraints != RigidbodyConstraints.FreezeAll)
        {
            if(unawareCount == 0)
            {
                aISystem.CommonTasks(AISystem.states.Patrol);
                unawareCount++;
            }
        }
        else
        {
            aISystem.CommonTasks(AISystem.states.Idle);
        }
    }
}
