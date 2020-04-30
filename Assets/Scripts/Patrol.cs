using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 1;
    bool returning;
    private NavMeshAgent agent;
    public bool forward;
    private bool left = false;
    private bool right = false;

    Transform needToWait;
    public float speed = 20f;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        needToWait = GetComponent<Transform>();
        agent.autoBraking = false;
        forward = true;
    }


    void GotoNextPoint()
    {

        if (points.Length == 0)
        {
            return;
        }

        //Debug.Log("Next Point: " + destPoint);
        agent.destination = points[destPoint].position;
        if (forward)
            destPoint++;
        else
            destPoint--;
    }
    // Update is called once per frame
    void Update()
    {

        if (agent.enabled)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (destPoint == points.Length - 1)
                    forward = false;
                else
                {
                    if (destPoint == 0)
                        forward = true;
                }
                GotoNextPoint();
            }
        }
        if (left)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 120, 0), Time.deltaTime * 0.6f);
            //transform.Rotate(0, Time.deltaTime * speed, 0);
            
        }
        if(right)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 220, 0), Time.deltaTime * 0.6f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "WaitHere")
        {
            //print("Wait");
            //transform.Rotate(0, -160, 0);
            //forward = true;
            StartCoroutine(waitForFew());
           
        }
    }

    IEnumerator waitForFew()
    {
        agent.isStopped = true;
        //agent.enabled = false;
        
        if(!forward)
        {
            left = true;
            yield return new WaitForSeconds(5);
            left = false;
            right = true;
            yield return new WaitForSeconds(5);
            right = false;
        }
        else if(forward)
        {
            right = true;
            yield return new WaitForSeconds(5);
            right = false;
            left = true;
            yield return new WaitForSeconds(5);
            left = false;
        }
        //agent.enabled = true;
        agent.isStopped = false;
    }

}
