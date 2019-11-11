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
    ThirdPersonCharacter TPScri;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        TPScri = GetComponent<ThirdPersonCharacter>();
        playerHP = 100;
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
            anim.Play("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            GoToGameOver();
        }

    }
    IEnumerator wait(string name, bool value)
    {
        yield return new WaitForSeconds(2.0f);
        anim.SetBool(name, value);
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
        if (playerHP <= 0)
        {
            SceneManager.LoadScene(2);
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
}
