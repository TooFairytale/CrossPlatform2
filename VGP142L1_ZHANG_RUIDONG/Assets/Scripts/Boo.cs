using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class Boo : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public GameObject enemy;
    public Transform playerTransform;
    public bool isRunning;
    public Animator anim;
    public MeshRenderer rend;
    NavMeshAgent agent;
    public GameObject key;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rend = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        Vector3 dirFromAtoB = (enemy.transform.position - player.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, player.transform.forward);

        if (dotProd > 0.5)
        {
            // player is looking mostly towards enemy
            if (Vector3.Distance(playerTransform.position, transform.position) < 10)
            {

                rb.velocity = Vector3.zero;
                agent.velocity = Vector3.zero;
                transform.localScale = new Vector3(0, 0, 0);
                //rend.enabled = false;
                isRunning = false;
            }
        }
        else
        {
            if (Vector3.Distance(playerTransform.position, transform.position) < 10)
            {

                transform.LookAt(playerTransform);
                transform.localScale = new Vector3(1, 1, 1);
                isRunning = true;
                //rend.enabled = true;
                //transform.position += transform.forward * 3 * Time.deltaTime;
                agent.SetDestination(playerTransform.position);
                //Debug.Log("runrun");
            }
        }
        anim.SetBool("isRunning", isRunning);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            //Destroy(collision.gameObject);
            //SceneManager.LoadScene(0);
        }
    }
    public void EnemyDie()
    {
        Destroy(this.gameObject);
    }
    
}

