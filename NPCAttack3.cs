using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCAttack3 : MonoBehaviour
{

    private GameObject triggeringEnemy;
    public GameObject otherObject;
    Animator otherAnimator;
    private bool triggering;
    static Animator anim;
    static Animator other_anim;
    private int hits = 0;
    AudioSource enemyAudio;
    public float timeBetweenAttacks = 1f;     // The time in seconds between each attack.
    float timer;                                // Timer for counting up to the next attack.
    NavMeshAgent agent;
    //public Text objective_text2 = null;
    public Text objective_text2 = null;
    public Text objective_text3 = null;

    public AudioClip victory;
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    AudioSource mainAudio;
    public GameObject maincamera;
    int now = 0;

    void Start()
    {
       // anim = gameObject.GetComponent<Animator>();

    }
    void Awake()
    {
        //otherAnimator = otherObject.GetComponent<Animator>();
        enemyAudio = otherObject.GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        mainAudio = maincamera.GetComponent<AudioSource>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (hits >= 15)
        {
            if (hits == 15 && now == 0)
            {
                now = 1;
                otherObject.GetComponent<chase_dragon>().enabled = false;
                objective_text2.text = "Congratulations! You won!";
                objective_text3.text = "Level 3";
                mainAudio.Stop();
                playerAudio.clip = victory;
                playerAudio.Play();
                //otherAnimator.SetTrigger("death");
                StartCoroutine(Example());
            }
            


            
        }

       else if (triggering)
        {
            GetComponent<follow>().enabled = false;
            transform.LookAt(otherObject.transform);
            transform.position = Vector3.MoveTowards(transform.position, otherObject.transform.position, 0.1f);
            //agent = GetComponent<NavMeshAgent>();
            //agent.destination = goal.position;
            // if (transform.position != goal.position && !isWalking && !finished)
            //{
            // FollowSpeed = 5f;

            // animator.SetFloat("speedPercent", FollowSpeed, 0.1f, Time.deltaTime);

            //if (Input.GetMouseButtonDown(0))
            // {


            if (hits < 15)
            {
                if (timer >= timeBetweenAttacks)
                {
                    GetComponent<Animation>().Play("Attack");
                    //anim.SetTrigger("Active");
                    StartCoroutine(Example());
                }

            }
            else
            {
                StartCoroutine(Example());
                otherObject.GetComponent<chase_dragon>();
                otherObject.GetComponent<chase_dragon>().enabled = false;
                if (hits == 15)
                {
                    objective_text2.text = "Congratulations! You won!";
                    objective_text3.text = "Level 3";
                    mainAudio.Stop();
                    playerAudio.clip = victory;
                    playerAudio.Play();
                }


            }
            // }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggering = true;
            triggeringEnemy = other.gameObject;
        }

        //if (hits >= 2)
        //{
            // StartCoroutine(Example());
            //  otherObject.GetComponent<chase>();

            //otherObject.GetComponent<chase_dragon>().enabled = false;
        //}
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggering = false;
            triggeringEnemy = null;

        }

        //if (hits >= 2)
        //{
            // StartCoroutine(Example());
            //  otherObject.GetComponent<chase>();

            //otherObject.GetComponent<chase_dragon>().enabled = false;
        //}

    }

    IEnumerator Example()
    {
        timer = 0f;
        yield return new WaitForSeconds(1);
        if (hits < 15)
        {
           // otherAnimator.SetTrigger("take_damage");
            //enemyAudio.clip = enemyDamagedClip;
            enemyAudio.Play();
            hits = hits + 1;
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            //otherAnimator.SetTrigger("death");

            otherObject.GetComponent<Animation>().Play("fly");
            yield return new WaitForSeconds(1);
            otherObject.GetComponent<Animation>().Play("fly_breath");
            yield return new WaitForSeconds(3);
            otherObject.GetComponent<Animation>().Play("fallToGround");
            otherObject.GetComponent<Animation>().Play("die");
            GetComponent<follow>().enabled = true;

            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MainMenu");

        }


    }
}

