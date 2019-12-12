using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data class that will be saved. It needs the System.Serializable attribute to be used by the Binary Formatter
[System.Serializable]
public class PlayerData
{
    public float health;
    public int level;
    public int lives;
    public float HPbar;
    public float[] playerPosition;

    //Constructor to create the default player data class
    public PlayerData(Player player)
    {
        health = player.playerHP;
        HPbar = player.healthBar.fillAmount;
        lives = player.playerLives;
        Debug.Log("playerHP = " + health);
        //level = player.level;

        playerPosition = new float[3];

        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
    }
}
