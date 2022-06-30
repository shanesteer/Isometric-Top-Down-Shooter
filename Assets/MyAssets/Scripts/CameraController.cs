using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    bool set = false;

    void Start()
    {
        //offset = transform.position;
        Invoke("SetPosition", 10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;

        if(set == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 15f, player.transform.position.z - 3f);
        }
    }

    public void SetPosition()
    {
        set = true;
    }
}
