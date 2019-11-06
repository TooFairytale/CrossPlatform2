using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool keyPickedUp;
    public bool Shoot1H;
    public bool Shoot2H;
    public bool Spell;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Shoot1Hand();
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            Shoot2Hand();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            SpellCast();
        }
        
    }
    IEnumerator wait(string name, bool value)
    {
        yield return new WaitForSeconds(2.0f);
        anim.SetBool(name, value);
    }
    void Shoot1Hand()
    {
        anim.SetBool("Shoot1H", true);
        //StartCoroutine(wait("Shoot1H", false));
    }
    
    void Shoot2Hand()
    {   
        anim.SetBool("Shoot2H", true);
        //StartCoroutine(wait("Shoot2H", false));
    }
    void SpellCast()
    {
        anim.SetBool("Spell", true);
        //StartCoroutine(wait("Spell", false));
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="key")
        {
            try
            {
            Destroy(collision.gameObject);
            keyPickedUp = true;
                throw new NullReferenceException("reference is not valid");
            }
            catch(NullReferenceException ex)
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
            if(keyPickedUp == true)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void StopShoot1Hand()
    {
        anim.SetBool("Shoot1H", false);
    }
    public void StopShoot2Hand()
    {
        anim.SetBool("Shoot2H", false);
    }
    public void StopSpellCast()
    {
        anim.SetBool("Spell", false);
    }
}
