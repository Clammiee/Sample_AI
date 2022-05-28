using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAIStateChange : MonoBehaviour
{
    [SerializeField] private AISystem aISystem;
    private int awareCount;
    private int unawareCount;
    private GameObject player;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        aISystem.ChangeState(AISystem.states.Vision);

        if(aISystem.exclamation.activeInHierarchy)
        {
            unawareCount = 0;
            if (player != null && Vector3.Distance(this.gameObject.transform.position, player.transform.position) <= aISystem.attackRange)
            {
                aISystem.CommonTasks(AISystem.states.Attack);
            }
            else //if (awareCount == 0)
            {
                aISystem.CommonTasks(AISystem.states.Chase);
                awareCount++;
            }
            //else aISystem.CommonTasks(AISystem.states.Attack);
        } 
        else if(aISystem.exclamation.activeInHierarchy == false)
        {
            awareCount = 0;
            if(unawareCount == 0)
            {
                aISystem.CommonTasks(AISystem.states.Patrol);
                unawareCount++;
            }
            
        }
    }
}
