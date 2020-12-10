using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guide : MonoBehaviour
{

    public Transform goal;
    Animator animator;
    bool isWalking = false;
    bool finished;
    NavMeshAgent agent;
    public float FollowSpeed;

    public GameObject NPC;
    public float TargetDistance;
    public float AllowedDistance = 1;
    public RaycastHit Shot;

    public int Objective_flag;
    public Transform goal2;
    public GameObject NPC2;
    int firsttime;

    private const float stopDistanceProportion = 1f;

    void Awake()
    {
        Objective_flag = 0;
        firsttime = 0;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        if (Objective_flag == 0)
        {
            agent.destination = goal.position;
            if (transform.position != goal.position && !isWalking && !finished)
            {
                FollowSpeed = 5f;
                //Debug.Log("1");
                // animator.SetBool("Flap1", true);
                // animator.SetBool("IsSoaring", true);

                animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
                isWalking = true;
            }
            if (transform.position.x == goal.position.x && transform.position.z == goal.position.z)
            {
                FollowSpeed = 0;
                isWalking = false;
                finished = true;
                animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
                // animator.SetBool("IdleWalk", false);
                // animator.SetBool("IdleStand", true);
                animator.enabled = false;
                GetComponent<NavMeshAgent>().isStopped = true;

            }

            transform.LookAt(NPC.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {

                TargetDistance = Shot.distance;
                if (TargetDistance <= AllowedDistance)
                {
                    FollowSpeed = 0;
                    //TheNPC.GetComponent<Animation>().Play("idle");
                    isWalking = false;
                    finished = true;
                    animator.SetFloat("speedPercent", FollowSpeed, 0, Time.deltaTime);
                    animator.enabled = false;
                    GetComponent<NavMeshAgent>().isStopped = true;
                }

            }
        }
        else if(Objective_flag==1)
        {
            if (firsttime == 0)
            {
                animator.enabled = true;
                GetComponent<NavMeshAgent>().isStopped = false;
                firsttime = 1;
            }

           // agent.destination = goal2.position;
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(goal2.transform.position.x, 0, goal2.transform.position.z)) > 1 && !isWalking)//(transform.position.x != goal2.position.x || transform.position.z != goal2.position.z)// && !isWalking && !finished)
            {
                FollowSpeed = 5f;
                //Debug.Log("1");
                // animator.SetBool("Flap1", true);
                // animator.SetBool("IsSoaring", true);
                agent.destination = goal2.position;
                animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
                isWalking = true;
                
            }
            else if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(goal2.transform.position.x, 0, goal2.transform.position.z)) < 1 && isWalking)//(transform.position.x == goal2.position.x && transform.position.z == goal2.position.z)
            {
                FollowSpeed = 0;
                isWalking = false;
                finished = true;
                animator.SetFloat("speedPercent", FollowSpeed, 0, Time.deltaTime);
                // animator.SetBool("IdleWalk", false);
                // animator.SetBool("IdleStand", true);
                transform.LookAt(NPC.transform);
                GetComponent<NavMeshAgent>().isStopped = true;
                animator.enabled = false;
                Objective_flag = 2;


            }

            /*
            if (Mathf.Abs(transform.position.x - goal2.transform.position.x)
                < 0.2f && Mathf.Abs(transform.position.z - goal2.transform.position.z) < 0.2f)
            {
                FollowSpeed = 0;
                isWalking = false;
                finished = true;
                animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
                // animator.SetBool("IdleWalk", false);
                // animator.SetBool("IdleStand", true);
                GetComponent<NavMeshAgent>().isStopped = true;
            }
               */



            /*  if (agent.remainingDistance <= agent.stoppingDistance * stopDistanceProportion)
              {

                  FollowSpeed = 0;
                  isWalking = false;
                  finished = true;
                  animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);
                  // animator.SetBool("IdleWalk", false);
                  // animator.SetBool("IdleStand", true);
                  GetComponent<NavMeshAgent>().isStopped = true;

              }*/


            /* transform.LookAt(NPC2.transform);
             if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
             {

                 TargetDistance = Shot.distance;
                 if (TargetDistance <= AllowedDistance)
                 {
                     FollowSpeed = 0;
                     //TheNPC.GetComponent<Animation>().Play("idle");
                     isWalking = false;
                     finished = true;
                     animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);

                     GetComponent<NavMeshAgent>().isStopped = true;
                 }

             }*/
        }
    }
}
