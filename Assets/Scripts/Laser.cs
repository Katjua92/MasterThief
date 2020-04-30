using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour {

    private LineRenderer lr;
    public Transform line;
    public Text youGotHit;
    public AudioClip LoseSound;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        lr = GetComponent<LineRenderer>();
        youGotHit.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }

            if (hit.collider.tag == "mirror")
            {
                print("Spejl");
                Vector3 pos = Vector3.Reflect(hit.point - line.position, hit.normal);
                lr.SetPosition(1, pos);
            }

            if (hit.collider.tag == "BodyCol" || hit.collider.tag == "ControllerCol")
            {
                //print("weHitByLazooor");
                youGotHit.gameObject.SetActive(true);
                audio.PlayOneShot(LoseSound, 0.5f);
                StartCoroutine(removeTxt());
                StartCoroutine(YouLose());
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }

    IEnumerator removeTxt() {
        yield return new WaitForSeconds(10);
        youGotHit.gameObject.SetActive(false);
    }

    IEnumerator YouLose()
    {
        yield return new WaitForSeconds(6);
        Application.LoadLevel(Application.loadedLevel);
    }
}

