using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    public float lookRadius;
    public Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance<= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }

    //void FaceTarget()
    //{
    //    Vector3 direction = (target.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Debug.Log("Kaboom");
            BlackBoard.player.TakeHpFromPlayer(250);
        }
    }
}
