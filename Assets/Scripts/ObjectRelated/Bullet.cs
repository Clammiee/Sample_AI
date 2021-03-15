using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damagePerBullet;
    [SerializeField] private string[] damagableTags;
    [SerializeField] private string[] collidableTags;

    public void InitializeBullet(float damage)
    {
        damagePerBullet = damage;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(CheckDamagableObjectTags(other.gameObject.tag))
        {
            DamageGO(other.gameObject);
        }
        else if(CheckCollidableObjectTags(other.gameObject.tag))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void DamageGO(GameObject go)
    {
        //IDamageable damageable = object.GetComponent<IDamageable>();
       // if (damageable != null)
       // {
           // damageable.Damage(damagePerBullet);
            //this.gameObject.SetActive(false);
       // }
    }

    private bool CheckDamagableObjectTags(string tag)
    {
        return true;
    }

    private bool CheckCollidableObjectTags(string tag)
    {
        return true;
    }
}
