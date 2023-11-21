using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public LayerMask playerlayer;
    public GameObject player;
    public float vision = 20;
    NavMeshAgent agent;
    public Animator animator;
    public RuntimeAnimatorController animatorDeath;
    private bool isDead;
    private bool isAttacking;
    public float damage = 20;
    public float attackDelay = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        tag = "Enemy";
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }
    public void takeDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            animator.runtimeAnimatorController = animatorDeath;
            Invoke("destroyGO", 5);
            isDead = true;
            tag = "Untagged";
        }
    }
    private void ChasePlayer()
    {
        if (Physics.CheckSphere(transform.position, vision, playerlayer) && isDead == false && isAttacking == false)
        {
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
            animator.Play("Move");
        }
        else
        {
            agent.enabled = false;
            if(isAttacking == false)
            animator.Play("None");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = true;
            StartCoroutine(AttackPlayer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }

    IEnumerator AttackPlayer()
    {

        while (isAttacking)
        {
            // Наносим урон игроку
            player.GetComponent<PlayerHealth>().takeDamage(damage);

            // Проигрываем анимацию атаки
            animator.Play("Attack");

            // Ждем завершения анимации и задержки перед следующей атакой
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + attackDelay);
        }
    }
    public void destroyGO()
    {
        Destroy(gameObject);
    }
}
