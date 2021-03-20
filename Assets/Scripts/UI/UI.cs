using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour

{   [SerializeField] private AISystem aISystem;

    public void IdleButton()
    {
        aISystem.CommonTasks(AISystem.states.Idle);
    }

    public void PatrolButton()
    {
        aISystem.CommonTasks(AISystem.states.Patrol);
    }

    public void ChaseButton()
    {
        aISystem.CommonTasks(AISystem.states.Chase);
    }

    public void AttackButton()
    {
        aISystem.CommonTasks(AISystem.states.Attack);
    }

    public void VisionButton()
    {
        aISystem.CommonTasks(AISystem.states.Vision);
    }

    public void GoToLevel2()
    {
        Toolbox.Instance.GetLevelManager().ChangeLevel(2);
    }
    
    public void GoToLevel1()
    {
        Toolbox.Instance.GetLevelManager().ChangeLevel(1);
    }

}
