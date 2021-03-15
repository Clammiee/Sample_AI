using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private ObjectPooler objectPooler;

    public AttackState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public override void DoAction()
    {   
        //animation inputs goes here
        //Animate(this.gameObject, "Condition", true);

        Shoot(CreateAndInitializeBullet());
    }

    private GameObject CreateAndInitializeBullet()
    {
        GameObject bullet = objectPooler.SpawnFromPool("Bullet", aI_System.gunTip.transform.position);
        bullet.GetComponent<Bullet>().InitializeBullet(aI_System.damagePerBullet);
        return bullet;
    }

    private void Shoot(GameObject bullet)
    {
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.transform.rotation = Quaternion.LookRotation(aI_System.gunTip.transform.forward);
        rigidbody.AddForce(aI_System.gunTip.transform.forward * aI_System.bulletSpeed, ForceMode.Force);
    }

    public override void End()
    {    
        //animation 
        //Animate(this.gameObject, "Condition", false);
    }
}
