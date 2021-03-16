using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSubscriber : MonoBehaviour
{
    private ObjectPooler objectPooler;
    [SerializeField] private GameObject tip;
    [SerializeField] private float damagePerBullet;
    [SerializeField] private float bulletSpeed;

    void Awake()
    {
        ActionEvents.OnShootBullet += SetOnShootBullet;
    }

    private void OnDestroy() 
    {
        ActionEvents.OnShootBullet -= SetOnShootBullet;
    }

    void Start() 
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void SetOnShootBullet(GameObject obj)
    {
        if(this.gameObject == obj)
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = objectPooler.SpawnFromPool("Bullet", tip.transform.position);
        bullet.GetComponent<Bullet>().InitializeBullet(damagePerBullet);

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.transform.rotation = Quaternion.LookRotation(tip.transform.forward);
        rigidbody.AddForce(tip.transform.forward * bulletSpeed, ForceMode.Force);
    }
}
