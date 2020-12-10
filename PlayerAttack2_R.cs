using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack2_R : MonoBehaviour
{

    private GameObject triggeringEnemy;
    public GameObject otherObject;
    Animator otherAnimator;
    private bool triggering;
    static Animator anim;
    static Animator other_anim;
    private int hits = 0;
    AudioSource enemyAudio;
    public int EnemiesDead;


    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();

    }
    void Awake()
    {
        otherAnimator = otherObject.GetComponent<Animator>();
        enemyAudio = otherObject.GetComponent<AudioSource>();
        EnemiesDead = 0;
    }



    void Update()
    {
        if (triggering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hits < 3)
                {
                    StartCoroutine(Example());

                }
                else
                {
                    StartCoroutine(Example());
                    otherObject.GetComponent<chase>();
                    otherObject.GetComponent<chase>().enabled = false;



                    if (hits == 3) { EnemiesDead = EnemiesDead + 1; }
                    // Destroy(otherObject);
                }
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggering = true;
            triggeringEnemy = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggering = false;
            triggeringEnemy = null;

        }

    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        if (hits < 3)
        {
            otherAnimator.SetTrigger("Hit");
            //enemyAudio.clip = enemyDamagedClip;
            enemyAudio.Play();
            hits = hits + 1;
        }
        else
        {
            otherAnimator.SetTrigger("Death");
            // if (hits == 3) { EnemiesDead = EnemiesDead + 1; }

        }


    }
}