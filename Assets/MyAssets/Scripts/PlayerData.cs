using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float playerHealth;
    public int enemiesKilled;

    public PlayerData(PlayerController1 playerController1)
    {
        playerHealth = playerController1.playerHealth;
        enemiesKilled = playerController1.count;
    }
}
