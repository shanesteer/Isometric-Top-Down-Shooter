using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameController gameScript;

    public Text EnemiesLeftText;
    public Text winText;
    public Text gameOverText;
    public int count;

    public float bulletWaitTime;
    private float bulletCurrentTime;

    public int numOfEnemies = 2;
    public float playerHealth;

    public GameObject bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        GameController gameScript = GetComponent<GameController>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameScript.playerMovement();
        gameScript.playerLooking();
        setEnemyCount();

        if (Input.GetMouseButtonDown(0))
        {
            gameScript.playerShooting();

            /*if (bulletCurrentTime == 0)
            {
                
            }

            if(gameScript.shooting == true && bulletCurrentTime < bulletWaitTime)
            {
                bulletCurrentTime = 1 * Time.deltaTime;
            }    

            if(bulletCurrentTime >= bulletWaitTime)
            {
                bulletCurrentTime = 0;
            }*/
            
        }

        if(playerHealth <= 0)
        {
            Dead();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
        }

    }

    public void setEnemyCount()
    {
        EnemiesLeftText.text = "Enemies Left: " + count.ToString() + " / " + numOfEnemies;

        if (count >= numOfEnemies)
        {
            winText.text = "You Win!";
        }
    }

    public void Dead()
    {
        if (playerHealth <= 0)
        {
            
            gameOverText.text = "Game Over!";
            Destroy(this.gameObject);
            Destroy(bulletSpawner.gameObject);
        }

    }

}
