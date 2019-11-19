using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
            BooLikeEnemy enemySri = GameObject.Find("Zombie1").GetComponent<BooLikeEnemy>();
            enemySri.anim.Play("Z_FallingBack 0");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
