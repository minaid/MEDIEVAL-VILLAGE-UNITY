using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_dragon : MonoBehaviour
{

    public Transform player;
    Animator anim;


    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 20;               // The amount of health taken away per attack.
    PlayerHealth playerHealth;                  // Reference to the player's health.
                                                // EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    GameObject player1;                          // Reference to the player GameObject.

    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    public int Enemyhealth = 0;

    public GameObject here;
    public GameObject[] database;

    void Awake()
    {
        // Setting up the references.
        player1 = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();

        //anim = GetComponent<Animator>();
        Enemyhealth = 1;
    }

    void Start()
    {
        //anim = GetComponent<Animator>();

    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player1)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player1)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        timer += Time.deltaTime;

        if ((Vector3.Distance(player.position, this.transform.position) < 10) && angle < 30)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction), 0.1f);

            //anim.SetBool("idleb", false);
            

            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);

                //nothing?
                GetComponent<Animation>().Play("walk");
                //anim.SetBool("walkb", true);
                //anim.SetBool("attack1b", false);
                //anim.SetTrigger("walk");

            }
            else
            {
                //anim.SetTrigger("attack1");
                GetComponent<Animation>().Play("stand_breath");
                GameObject effect = Instantiate(database[0], here.transform.position, here.transform.rotation); //creating the effect
                effect.transform.parent = here.transform; // transforming to its target
                //anim.SetBool("attack1b", true);
               // anim.SetBool("walkb", false);

                if (timer >= timeBetweenAttacks && playerInRange)//&& enemyHealth.currentHealth > 0)
                {

                    Attack();
                }
                if (playerHealth.currentHealth <= 0)
                {
                    // ... tell the animator the player is dead.

                    // anim.SetTrigger("death");

                }
            }
        }
        else
        {
            GetComponent<Animation>().Play("idle");
            //GameObject effect = Instantiate(database[0], here.transform.position, here.transform.rotation); //creating the effect
            //effect.transform.parent = here.transform; // transforming to its target
            //anim.SetBool("idleb", true);
            //anim.SetBool("attack1b", false);
            //anim.SetBool("walkb", false);
            //anim.SetTrigger("idle");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }

}
