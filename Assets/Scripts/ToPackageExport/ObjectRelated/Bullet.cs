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
        if(CheckIfInArray(other.gameObject.tag, damagableTags))
        {
            DamageGO(other.gameObject);
        }
        else if(CheckIfInArray(other.gameObject.tag, collidableTags))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void DamageGO(GameObject go)
    {
        IDamagable damagable = go.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.Damage(damagePerBullet);
            this.gameObject.SetActive(false);
        }
    }

    private bool CheckIfInArray(string tag, string[] tagsArray)
    { 
        foreach(string tagString in tagsArray)
        {
            if(string.Equals(tag, tagString)) return true;
        }
        return false;
    }
}
