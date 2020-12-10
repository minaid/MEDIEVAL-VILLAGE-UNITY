﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2_troll : MonoBehaviour
{

    private GameObject triggeringEnemy;
    public GameObject otherObject;
    Animator otherAnimator;
    private bool triggering;
    static Animator anim;
    static Animator other_anim;
    private int hits = 0;
    public Text objective_text2 = null;
    public Text objective_text3 = null;


    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();

    }
    void Awake()
    {
        otherAnimator = otherObject.GetComponent<Animator>();
    }



    void Update()
    {
        if (triggering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hits < 5)
                {
                    StartCoroutine(Example());

                }
                else
                {
                    StartCoroutine(Example());
                    otherObject.GetComponent<chase_troll>();
                    otherObject.GetComponent<chase_troll>().enabled = false;

                    if (hits == 5)
                    {
                        objective_text2.text = "Objective: Exit the tavern cellar.";
                        objective_text3.text = "Level 2";
                    }
                    // objective_text2.text = "Objective: Exit the tavern cellar.";


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
        if (hits < 5)
        {
            otherAnimator.SetTrigger("take_damage");
            hits = hits + 1;
        }
        else
        {
            otherAnimator.SetTrigger("death");
        }


    }
}
