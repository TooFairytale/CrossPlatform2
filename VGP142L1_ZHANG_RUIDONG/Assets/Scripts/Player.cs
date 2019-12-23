using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool keyPickedUp;
    public Animator anim;
    public float playerHP;
    public int playerLives;
    ThirdPersonCharacter TPScri;
    public Image healthBar;
    public ParticleSystem particle;
    float dieTimer;
    bool playerDead;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        TPScri = GetComponent<ThirdPersonCharacter>();
        playerHP = 100;
        dieTimer = 2;
        playerDead = false;
        playerLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.Play("Shooting1Hand");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            anim.Play("Shooting2Hands");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            anim.Play("Spell");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //anim.Play("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            GoToGameOver();
        }
        if(playerHP<=0)
        {
            playerDead = true;
        }
        if(playerDead)
        {
            dieTimer -= Time.deltaTime;
            if (dieTimer <= 0)
            {
                if (playerLives <= 0)
                {
                    GoToGameOver();
                    Debug.Log("change scene");
                }
                else
                {
                    load();
                }
            }
        }
        //Call the Save System's Save Player function when you press 1. Pass it the current Player script component.
        if (Input.GetKeyDown(KeyCode.F5))
        {
            save();
        }

        //Call the Save System's Load Player function
        if (Input.GetKeyDown(KeyCode.F6))
        {
            load();
        }
    }
    
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "key")
        {
            try
            {
                Destroy(collision.gameObject);
                keyPickedUp = true;
                throw new NullReferenceException("reference is not valid");
            }
            catch (NullReferenceException ex)
            {
                Debug.Log(ex.Message);
            }
        }
        if (collision.gameObject.tag == "item")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(60);
            playerDie();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "endCube")
        {
            if (keyPickedUp == true)
            {
                SceneManager.LoadScene(0);
            }
        }
        else if(other.gameObject.tag == "SpeedPower")
        {
            changeSpeedTo(1.5f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "HealthPowerUp")
        {
            TakeDamage(-20f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "JumpPowerUp")
        {
            changeJumpPowerTo(15);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "SlowPowerUp")
        {
            changeSpeedTo(3f);
            Destroy(other.gameObject);
        }
    }

    public void AnimationEnd()
    {
        anim.Play("Grounded");
    }
    public void GoToGameOver()
    {
        SceneManager.LoadScene(2);
    }
    public void playerDie()
    {
        if(playerDead)
        {
            dieParticleActive();
            playerLives -= 1;
            save();
            Debug.Log("playerLives = " + playerLives);
        }
    }
    public void TakeDamage(float amount)
    {
        playerHP -= amount;
        healthBar.fillAmount = playerHP/100f;
    }
    public void changeSpeedTo(float Speed)
    {
        TPScri.m_MoveSpeedMultiplier = Speed;
        TPScri.m_AnimSpeedMultiplier = Speed;
    }
    public void changeJumpPowerTo(float jump)
    {
        TPScri.m_JumpPower = jump;
    }
    public void dieParticleActive()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
    public void save()
    {
        SaveSystem.SavePlayer(this);
    }
    public void load()
    {
        //Load player returns type PlayerData
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            //grab the Health, Level and Position in our saved data and update our player
            playerHP = data.health;
            healthBar.fillAmount = data.HPbar;
            playerLives = data.lives;
            //level = data.level;

            transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        }
    }
}
