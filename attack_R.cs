using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_R : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            GetComponent<Animation>().Play("Attack1");
            //anim.SetTrigger("Active");
        }
    }
}
