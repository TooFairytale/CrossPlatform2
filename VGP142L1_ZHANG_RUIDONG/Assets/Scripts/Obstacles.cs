using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player P = other.GetComponent<Player>();
        if(P!= null)
        {
            if(gameObject.tag =="waterObstacle")
            {
                P.changeSpeedTo(0.5f);
                Debug.Log(P.playerHP);
                P.playerDie();
            }
            if (gameObject.tag == "lavaObstacle")
            {
                P.TakeDamage(50);
                Debug.Log(P.playerHP);
                P.playerDie();
            }
            if (gameObject.tag == "toxicObstacle")
            {
                P.changeSpeedTo(0.5f);
                P.TakeDamage(20);
                Debug.Log(P.playerHP);
                P.playerDie();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player P = other.GetComponent<Player>();
        if (P != null)
        {
            if (gameObject.tag == "waterObstacle")
            {
                P.changeSpeedTo(1f);
                Debug.Log(P.playerHP);
                P.playerDie();
            }
            if (gameObject.tag == "lavaObstacle")
            {
                Debug.Log(P.playerHP);
                P.playerDie();
            }
            if (gameObject.tag == "toxicObstacle")
            {
                P.changeSpeedTo(1f);
                Debug.Log(P.playerHP);
                P.playerDie();
            }

        }
    }
}
