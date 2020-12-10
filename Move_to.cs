using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to : MonoBehaviour {

    public Transform goal;
     Animator animator;
    bool isWalking = false;
    bool finished;
    NavMeshAgent agent;
    public float FollowSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        agent.destination = goal.position;
        if (transform.position != goal.position && !isWalking && !finished)
        {
            FollowSpeed = 5f;
            //Debug.Log("1");
            // animator.SetBool("Flap1", true);
           // animator.SetBool("IsSoaring", true);
            
            //animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
            isWalking = true;
        }
        if (transform.position.x == goal.position.x && transform.position.z == goal.position.z)
        {
            FollowSpeed = 0;
            isWalking = false;
            finished = true;
            //animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
            // animator.SetBool("IdleWalk", false);
            // animator.SetBool("IdleStand", true);
            GetComponent<NavMeshAgent>().isStopped = true;

        }
    }
}
