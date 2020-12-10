using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {
	
	public Transform player;
	 Animator anim;


    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    PlayerHealth playerHealth;                  // Reference to the player's health.
                                                // EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    GameObject player1;                          // Reference to the player GameObject.
    
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    public int Enemyhealth=0;

    void Awake()
    {
        // Setting up the references.
        player1 = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        Enemyhealth = 1;
    }

    void Start () {
		anim = GetComponent<Animator>();

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

    void Update () {
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);

        timer += Time.deltaTime;

        if ((Vector3.Distance(player.position, this.transform.position) < 10) &&angle<30)
		{
			direction.y= 0;
			
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
			Quaternion.LookRotation(direction) , 0.1f);
			
			anim.SetBool("isIdle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.05f);
				anim.SetBool("isWalking",true);
				anim.SetBool("isAttacking",false);
			}
			else{
                
                    anim.SetBool("isAttacking",true);
				anim.SetBool("isWalking",false);
                if (timer >= timeBetweenAttacks && playerInRange)//&& enemyHealth.currentHealth > 0)
                {
                Attack();
                }
                if (playerHealth.currentHealth <= 0)
                {
                    // ... tell the animator the player is dead.
                    anim.SetTrigger("PlayerDead");
                }
            }
		}
		else
		{
			anim.SetBool("isIdle",true);
			anim.SetBool("isAttacking",false);
			anim.SetBool("isWalking",false);
		}}


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
