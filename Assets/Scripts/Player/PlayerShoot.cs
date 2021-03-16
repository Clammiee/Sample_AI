using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : PlayerInputs
{
    private ObjectPooler objectPooler;
    [SerializeField] private GameObject gunTip;
    [SerializeField] private float damagePerBullet;
    [SerializeField] private float bulletSpeed;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if(ShootInput() == true) Shoot(CreateAndInitializeBullet()); //REPLACE WITH SHOOTING ANIMATION TRIGGER
    }

    private bool ShootInput()
    {
        if(base.InputDetection(playerActions.Attack) > 0f && base.IsInputTriggered(playerActions.Attack)) return true;
        else return false;
    }

    private GameObject CreateAndInitializeBullet()
    {
        GameObject bullet = objectPooler.SpawnFromPool("Bullet", gunTip.transform.position);
        bullet.GetComponent<Bullet>().InitializeBullet(damagePerBullet);
        return bullet;
    }

    private void Shoot(GameObject bullet)
    {
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.transform.rotation = Quaternion.LookRotation(gunTip.transform.forward);
        rigidbody.AddForce(gunTip.transform.forward * bulletSpeed, ForceMode.Force);
    }
}
