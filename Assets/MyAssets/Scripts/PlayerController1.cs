using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public GameController gameScript;

    public Text EnemiesLeftText;
    public Text winText;
    public Text gameOverText;
    public Text healthText;
    public Text restartText;
    public Text finishGameText;
    public int count;

    public int numOfEnemies;
    public float playerHealth;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        GameController gameScript = GetComponent<GameController>();
        anim = GetComponent<Animator>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameScript.playerMovement();
        gameScript.playerLooking();
        setEnemyCount();
        displayHealth();




        if (Input.GetMouseButtonDown(0))
        {
            gameScript.playerShooting();

        }
        else
        {
            anim.SetBool("IsShooting", false);
        }

        if(playerHealth >= 100)
        {
            playerHealth = 100;
        }

        if (playerHealth <= 0)
        {
            Dead();


                if (Input.GetKeyDown("s"))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    
                }


            
        }

        if (Input.GetKeyDown("m"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);

        }
    }


    void OnTriggerEnter(Collider other)
    {
        //setting how much the players health increases when they interact with the health pickup
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            playerHealth += 25;
        }

        if (other.gameObject.tag == "ShootingPickUp")
        {
            other.gameObject.SetActive(false);
            gameScript.bulletSpeed = 1000f;
        }

    }

    public void setEnemyCount()
    {
        //getting the number of enemies left in the game
        EnemiesLeftText.text = "Enemies Killed: " + count.ToString() + " / " + numOfEnemies;

        if (count >= numOfEnemies)
        {
            winText.text = "You Win!";
            finishGameText.text = "Press 'M' to choose another level";
            Time.timeScale = 0;
        }
    }

    public void displayHealth()
    {
        healthText.text = "Health: " + playerHealth;
    }

    public void Dead()
    {
        if (playerHealth <= 0)
        {

            gameOverText.text = "Game Over!";
            restartText.text = "Press 'S' to restart";
            Time.timeScale = 0f;


        }

    }

    public void Save()
    {
        SaveSystem.Save(this);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.Load();

        playerHealth = data.playerHealth;
        count = data.enemiesKilled;
    }
}
