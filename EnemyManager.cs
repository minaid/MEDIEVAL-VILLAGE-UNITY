using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public PlayerAttack2 Enemy;       // Reference to the player's heatlh.  //Enemy Health perhaps?
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int checkprev;

    private void Awake()
    {
        checkprev = 0;
    }

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

       //InvokeRepeating("Spawn", spawnTime, spawnTime);  SPAWN
    }


    void Spawn()
    {
        // If the player has no health left...
        if (Enemy.EnemiesDead > checkprev)
        {

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            // ... exit the function.
            checkprev = Enemy.EnemiesDead;
        }

        return;
    }
}
