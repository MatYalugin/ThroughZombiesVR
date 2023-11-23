using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().takeDamage(100);
        }
        if (other.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(100);
        }
    }
}
