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
        //INSTANTIATE COMES FROM MONOBEHAVIOR
        //Instantiate(aI_System.bulletPrefab, aI_System.gunTip.transform.position, Quaternion.identity);
        //SO WE USE OBJECT POOLING IN THIS CASE
        Debug.Log("shooting");
    }

    public override void End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
    }
}
