using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdEyes : MonoBehaviour {
    private LineRenderer lr;
    public Transform eyesPos;
    public float range = 100f;
    public GameObject guard;
    public AudioClip LoseSound;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        lr = GetComponent<LineRenderer>();
       
    }
	
	// Update is called once per frame
	void Update () {
        eyesPos.rotation = guard.transform.rotation;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
        //    if (hit.collider)
        //    {
        //        lr.SetPosition(1, hit.point);
        //    }

        //    if (hit.collider.tag == "BodyCol" || hit.collider.tag == "ControllerCol")
        //    {
        //        print("He sees you!");

        //    }
        //}
        //else lr.SetPosition(1, transform.forward * 100);

        RaycastHit hit;

        if (Physics.Raycast(eyesPos.transform.position, eyesPos.transform.forward, out hit, range))
        {
           lr.SetPosition(1, new Vector3(0, 0, hit.distance));


            if (hit.collider.tag == "BodyCol" || hit.collider.tag == "ControllerCol")
            {
                audio.PlayOneShot(LoseSound, 0.5f);
                StartCoroutine(YouLose());
                

            }
        }

        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 500f));
        }
    }

    IEnumerator YouLose()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel);
    }

}
