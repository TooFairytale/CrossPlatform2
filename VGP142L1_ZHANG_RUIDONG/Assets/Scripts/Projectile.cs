using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem particle;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            BooLikeEnemy enemySri = GameObject.Find("Zombie1").GetComponent<BooLikeEnemy>();
            enemySri.anim.Play("Z_FallingBack 0");
        }
        else if (collision.gameObject.tag == "ShootingEnemy")
        {
            Destroy(gameObject);
            EnemyShoot enemySri = GameObject.Find("ShootingEnemy").GetComponent<EnemyShoot>();
            enemySri.anim.Play("Z_FallingBack 0");
        }
        else
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
