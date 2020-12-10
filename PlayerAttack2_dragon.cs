using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAttack2_dragon : MonoBehaviour
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

    //private string animName;
    public Text objective_text2 = null;
    public Text objective_text3 = null;
    public AudioClip victory;
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    AudioSource mainAudio;
    public GameObject maincamera;

    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();

    }
    void Awake()
    {
        //otherAnimator = otherObject.GetComponent<Animator>();
        enemyAudio = otherObject.GetComponent<AudioSource>();
        EnemiesDead = 0;
        playerAudio = GetComponent<AudioSource>();
        mainAudio = maincamera.GetComponent<AudioSource>();
    }



    void Update()
    {
        if (triggering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hits < 10)
                {
                    StartCoroutine(Example());

                }
                else
                {
                    StartCoroutine(Example());
                    otherObject.GetComponent<chase_dragon>();
                    otherObject.GetComponent<chase_dragon>().enabled = false;



                    if (hits == 10) {
                        EnemiesDead = EnemiesDead + 1;
                        objective_text2.text = "Congratulations! You won!";
                        objective_text3.text = "Level 3";
                        mainAudio.Stop();
                        playerAudio.clip = victory;
                        playerAudio.Play();
                    }
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
        if (hits < 10)
        {
            //otherAnimator.SetTrigger("take_damage");
            
            //enemyAudio.clip = enemyDamagedClip;
            enemyAudio.Play();
            hits = hits + 1;
        }
        else
        {
            //otherAnimator.SetTrigger("death");
            otherObject.GetComponent<Animation>().Play("fly");
            yield return new WaitForSeconds(1);
            otherObject.GetComponent<Animation>().Play("fly_breath");
            yield return new WaitForSeconds(3);
            otherObject.GetComponent<Animation>().Play("fallToGround");
            otherObject.GetComponent<Animation>().Play("die");
            // if (hits == 3) { EnemiesDead = EnemiesDead + 1; }
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MainMenu");

        }


    }
}