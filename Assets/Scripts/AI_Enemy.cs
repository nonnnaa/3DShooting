using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform playerTranform;
    public Animator animator;
    float distance;
    public float AttackDistance;
    public float attackCooldown;

    void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        distance = (playerTranform.position - transform.position).magnitude;
        
    }

    void Update()
    {
        Vector3 directionToPlayer = playerTranform.position - transform.position;
        transform.LookAt(playerTranform);

        agent.destination = playerTranform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
        checkAttack();
    }
    void checkAttack()
    {
        distance = Vector3.Distance(transform.position, playerTranform.position);
        //Debug.Log(distance);
        if (distance < AttackDistance)
        {
            animator.SetBool("E_Attack", true);
            agent.updateRotation = false;
        }
        else
        {
            animator.SetBool("E_Attack", false);
            agent.updateRotation = true;

        }
        Invoke("ResetAttack", attackCooldown);
    }
    void ResetAttack(){}
}
