using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public int count;
    public bool shooting;
    
    public float bulletSpeed = 300f;
    float hitDistance = 0.0f;



    private Rigidbody playerRigidBody;

    //public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    GameObject player;


    private Transform bulletSpawned;

    public AudioSource shootSound;

    //public EnemyController enemyScript;
    Animator anim;



    Vector3 movement;
    Vector3 movementVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        //bullet = GameObject.FindGameObjectWithTag("Bullet");
        //enemyScript = GetComponent<EnemyController>();
        count = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerRigidBody.velocity = movementVelocity;
        
    }

    public void playerMovement()
    {

        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);

        //Didn't use Time.deltaTime because the player moved quite slowly and made the frames look choppy
        movementVelocity = movement * speed;

        /*anim.SetFloat("Speed", horizontalAxis * speed);
        anim.SetFloat("Speed", verticalAxis * speed);*/

        if (Input.GetKey("w"))
        {
            anim.SetFloat("Speed", 1);
        }

        if (Input.GetKey("s"))
        {
            anim.SetFloat("Speed", 1);
        }

        if (Input.GetKey("a"))
        {
            anim.SetFloat("Speed", 1);
        }

        if (Input.GetKey("d"))
        {
            anim.SetFloat("Speed", 1);
        }

        if (Input.GetKeyUp("w"))
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKeyUp("a"))
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKeyUp("s"))
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKeyUp("d"))
        {
            anim.SetFloat("Speed", 0);
        }

    }



    //Code for player looking in direction oof mouse taken and modified from
    //https://www.youtube.com/watch?v=E56-ekpz0rM
    public void playerLooking()
    {
        Plane floor = new Plane(Vector3.up, transform.position);
        //Created a ray that helps monitor the position of the mouse
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (floor.Raycast(mouseRay, out hitDistance))
        {
            Vector3 rayTargetPoint = mouseRay.GetPoint(hitDistance);
            Quaternion rayTargetRotation = Quaternion.LookRotation(rayTargetPoint - transform.position);
            //making sure that rotation does not occur at the x and z axis
            rayTargetRotation.x = 0;
            rayTargetRotation.z = 0;
            //setting the rotation speed
            transform.rotation = Quaternion.Slerp(transform.rotation, rayTargetRotation, rotationSpeed * Time.deltaTime);
        }
    }


    public void playerShooting()
    {
        //Using instantiate to bring bullet into existance
        //bulletSpawnedis the new bullet that was instantiated
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        //Makes sure the bullet does not collide with player
        Physics.IgnoreCollision(bulletSpawned.GetComponent<Collider>(), GetComponent<Collider>(), true);
        //Makes the bullet travel in the forward direction
        bulletSpawned.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //Sets the new spawned bullets rotation in the direction the player is facing
        bulletSpawned.rotation = transform.rotation;

        shootSound.Play();

        anim.SetBool("IsShooting", true);

        shooting = true;

    }


    

    
}
