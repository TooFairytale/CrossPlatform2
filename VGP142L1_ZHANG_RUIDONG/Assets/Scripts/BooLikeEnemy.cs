using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BooLikeEnemy : MonoBehaviour
{
    Rigidbody rb;
    public GameObject ObjA;
    public GameObject ObjB;
    public Transform target;
    public bool isRunning;
    public Animator anim;
    public MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rend = GetComponent<MeshRenderer>();
        
    }

    void Update()
    {

        Vector3 dirFromAtoB = (ObjB.transform.position - ObjA.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, ObjA.transform.forward);

        if (dotProd > 0.5)
        {
            // ObjA is looking mostly towards ObjB
            if(Vector3.Distance(target.position,transform.position) < 10)
            {

            rb.velocity = Vector3.zero;
            transform.localScale = new Vector3(0, 0, 0);
            //rend.enabled = false;
            isRunning = false;
            }
        }
        else
        {
            if(Vector3.Distance(target.position, transform.position) < 10)
            {

            transform.LookAt(target);
            transform.localScale = new Vector3(1, 1, 1);
            isRunning = true;
            //rend.enabled = true;
            transform.position += transform.forward * 3 * Time.deltaTime;
            //Debug.Log("runrun");
            }
        }
        anim.SetBool("isRunning", isRunning);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
