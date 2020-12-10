using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour {

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedDistance = 1;
    public GameObject TheNPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    Animator animator;

    NavMeshAgent agent;
    public Transform goal;

    void Start()
    {
       // animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent = GetComponent<NavMeshAgent>();

        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
           
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance)
            {
                
                FollowSpeed = 0.08f;
                //TheNPC.GetComponent<Animation>().Play("running");
                //float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;

               // animator.SetFloat("speedPercent", 5f, 0.1f, Time.deltaTime);
                GetComponent<Animation>().Play("Run");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, FollowSpeed);
                //agent.destination= Vector3.MoveTowards(transform.position, ThePlayer.transform.position, FollowSpeed);
            }
            else
            {
                
                FollowSpeed = 0;
                //TheNPC.GetComponent<Animation>().Play("idle");

                GetComponent<Animation>().Play("idle");
                //animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);

                //GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
    }
}
