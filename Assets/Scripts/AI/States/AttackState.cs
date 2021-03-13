using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        Shoot();
    }

    private void Shoot()
    {
        ObjectPooler.Instance.SpawnFromPool("Bullet", aI_System.gunTip.transform.position);
    }

    public override void End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
    }
}
