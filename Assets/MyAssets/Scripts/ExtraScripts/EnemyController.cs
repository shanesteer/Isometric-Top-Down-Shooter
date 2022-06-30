using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyHealth;
    public int enemyCounter;
    public float bulletWaitTime;
    float bulletTimer;
    //private float bulletCurrentTime;
    private bool shooting;
    public float bulletSpeed = 500f;


    public GameObject bulletSpawner;
    public GameObject bullet;

    GameObject player;
    GameObject enemy;

    private Transform bulletSpawned;

    public NavMeshAgent enemyNavMeshAgent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        //bullet = GameObject.FindGameObjectWithTag("EnemyBullet");
        //bulletSpawner = GameObject.Find("Enemy Bullet Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        enemyNavMeshAgent.SetDestination(player.transform.position);

        this.transform.LookAt(player.transform);


        bulletTimer += Time.deltaTime;

        if(bulletTimer > bulletWaitTime)
        {
            enemyShooting();
        }


        if (enemyHealth <= 0)
        {
            Dead(); 
        }

        /*if (bulletCurrentTime == 0)
        {
            enemyShooting();
        }

        if (shooting && bulletCurrentTime < bulletWaitTime)
        {
            bulletCurrentTime = 1 * Time.deltaTime;
        }

        if (bulletCurrentTime >= bulletWaitTime)
        {
            bulletCurrentTime = 0;
        }*/

        
    }

    public void enemyShooting()
    {

        shooting = true;

        //Using instantiate to bring bullet into existance
        //bulletSpawnedis the new bullet that was instantiated
        bulletSpawned = Instantiate(bullet.transform, bulletSpawner.transform.position, Quaternion.identity);
        //Makes sure the bullet does not collide with player
        Physics.IgnoreCollision(bulletSpawned.GetComponent<Collider>(), enemy.GetComponent<Collider>(), true);
        //Makes the bullet travel in the forward direction
        bulletSpawned.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //Sets the new spawned bullets rotation in the direction the player is facing
        bulletSpawned.rotation = bulletSpawner.transform.rotation;

        bulletTimer = 0;
    }


    public void Dead()
    {
        
        player.GetComponent<PlayerController>().count += enemyCounter;
        Destroy(this.gameObject);
        Destroy(bulletSpawner.gameObject);
    }

}
