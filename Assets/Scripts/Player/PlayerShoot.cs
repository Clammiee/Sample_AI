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
        if(ShootInput() == true) Shoot(); //REPLACE WITH SHOOTING ANIMATION TRIGGER
    }

    private bool ShootInput()
    {
        if(base.InputDetection(playerActions.Attack) > 0f && playerActions.Attack.triggered) return true;
        else return false;
    }

    private void Shoot()
    {
        GameObject bullet = objectPooler.SpawnFromPool("Bullet", gunTip.transform.position);
        bullet.GetComponent<Bullet>().InitializeBullet(damagePerBullet);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.transform.rotation = Quaternion.LookRotation(gunTip.transform.forward);
        rigidbody.AddForce(gunTip.transform.forward * bulletSpeed, ForceMode.Force);
    }
}
