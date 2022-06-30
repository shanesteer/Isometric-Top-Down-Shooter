using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed;
    public float damage;

    private GameObject Enemy;
    public GameObject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Code taken from lecture slides
        Destroy(this.gameObject, 5.0f);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy = other.gameObject;
            Enemy.GetComponent<EnemyController1>().enemyHealth -= damage;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }

    }
}
