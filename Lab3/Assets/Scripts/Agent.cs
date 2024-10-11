using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public GameObject Target;
    NavMeshAgent agent;
    bool IsWalking;
    Animator animator;

    void Start()
    {
        IsWalking = true;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWalking)
        {
            agent.destination = Target.transform.position;
        }else
        {
            agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Target")
        {
            IsWalking = false;
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsWalking = true;
        animator.SetTrigger("Walk");
    }
}
