using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float shootTimer;
    public GameObject EnemyBullet;
    public Transform ShootingPoint;
    public float BulletSpeed;
    public GameObject player;
    public GameObject enemy;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        BulletSpeed = 100f;
        shootTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            EnemyShooting();
        }
    }
    void EnemyShooting()
    {
        shootTimer -= Time.deltaTime;
        {
            if (shootTimer <= 0)
            {
                GameObject bullet = Instantiate(EnemyBullet, ShootingPoint.position, this.transform.rotation);
                Vector3 direction = player.transform.position - enemy.transform.position;
                direction.Normalize();
                bullet.GetComponent<Rigidbody>().AddForce(direction * BulletSpeed);
                shootTimer = 1f;
            }
        }
    }
    public void EnemyDie()
    {
        Destroy(this.gameObject);
    }
}
