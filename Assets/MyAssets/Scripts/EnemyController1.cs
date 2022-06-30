using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController1 : MonoBehaviour
{
    public float enemyHealth;
    public int enemyCounter;
    public float bulletWaitTime;
    float bulletTimer;
    private bool playerInRange;
    public float bulletSpeed = 500f;
    //public Transform[] wp;
    //private int points = 0;

    public GameObject bullet;

    public AudioSource shootSound;

    GameObject player;
    GameObject enemy;

    private Transform bulletSpawned;

    private NavMeshAgent enemyNavMeshAgent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();

        //enemyNavMeshAgent.autoBraking = false;

        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            enemyHealth = 100;
        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            enemyHealth = 200;
        }


        /*enemyNavMeshAgent.autoBraking = false;
        nextPatrolPoint();*/

        
    }

    // Update is called once per frame
    void Update()
    {
        //increases the bullet timer
        bulletTimer += Time.deltaTime;

        /*if (!enemyNavMeshAgent.pathPending && enemyNavMeshAgent.remainingDistance <= 0.5f)
        {

            nextPatrolPoint();
        }*/
            


        /*if (Vector3.Distance(player.transform.position, transform.position) <= 15)
        {
            playerInRange = true;
        }

        

        if (playerInRange)
        {
            //chasePlayer();

            //checks to see if the bullet timer is larger than or equal to the bullet 
            //waiting time before the enemy can fire again
            if (bulletTimer >= bulletWaitTime)
            {
                enemyShooting();
            }

            if(enemyNavMeshAgent.remainingDistance < 5f)
            {
                enemyNavMeshAgent.isStopped = true;
            }

            else
            {
                enemyNavMeshAgent.isStopped = false;
            }

        }*/


        


        if (enemyHealth <= 0)
        {
            Dead();
        }


    }

    public void enemyShooting()
    {
        if (bulletTimer >= bulletWaitTime)
        {
            //Using instantiate to bring bullet into existances
            //bulletSpawnedis the new bullet that was instantiates
            bulletSpawned = Instantiate(bullet.transform, transform.position, Quaternion.identity);
            //Makes sure the bullet does not collide with enemy
            Physics.IgnoreCollision(bulletSpawned.GetComponent<Collider>(), GetComponent<Collider>(), true);
            //Makes the bullet travel in the forward direction
            bulletSpawned.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            //Sets the new spawned bullets rotation in the direction the enemy is facing
            bulletSpawned.rotation = transform.rotation;

            shootSound.Play();

            bulletTimer = 0;
        }
    }

    /*public void chasePlayer()
    {
        //using nav mesh to move toward the players position
        enemyNavMeshAgent.SetDestination(player.transform.position);

        this.transform.LookAt(player.transform);
    }


    //enemy patrolling taken from lecture slides and unity documentation https://docs.unity3d.com/Manual/nav-AgentPatrol.html

    public void nextPatrolPoint()
    {

        if (wp.Length == 0)
            return;

        enemyNavMeshAgent.destination = wp[points].position;


        points = (points + 1) % wp.Length;
    }*/


    public void Dead()
    {

        player.GetComponent<PlayerController1>().count += enemyCounter;
        Destroy(this.gameObject);
    }
}
