using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //public float speed;
    public float damage;

    private GameObject player;
    public GameObject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            damage = 10;
        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            damage = 25;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Code taken from lecture slides
        Destroy(this.gameObject, 8.0f);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            player.GetComponent<PlayerController1>().playerHealth -= damage;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
        }

    }
}
