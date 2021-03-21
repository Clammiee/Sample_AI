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

    void FixedUpdate()
    {
        aISystem.ChangeState(AISystem.states.Vision);

        if(aISystem.exclamation.activeInHierarchy) //player got detected
        {
            unawareCount = 0;
            if(awareCount == 0)
            {
                aISystem.CommonTasks(AISystem.states.Chase);
                awareCount++;
            }
            
            //if within shooting distance than stop chasing and attack instead
            if(Vector3.Distance(this.gameObject.transform.position, player.transform.position) <= aISystem.attackRange)
            {
                aISystem.CommonTasks(AISystem.states.Attack);
            }
        } 
        else if(aISystem.exclamation.activeInHierarchy == false) //player not detected
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
