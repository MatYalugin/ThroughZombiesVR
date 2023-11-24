using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public int damage;
    private bool hasDamaged;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !hasDamaged)
        {
            other.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
            hasDamaged = true;
        }
        if (other.tag.Equals("Enemy") && !hasDamaged)
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(damage);

        }
    }
}
