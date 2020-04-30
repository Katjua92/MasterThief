using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour {

    public GameObject delvFloor;
    public Collider delvDis;
    public AudioClip winSound;
    public AudioSource audio;



	// Use this for initialization
	void Start () {

        delvFloor.gameObject.SetActive(false);
       
     

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ControllerCol")
        {
            delvFloor.gameObject.SetActive(true);
        }
        //else {
        //    delvFloor.gameObject.SetActive(false);
        //}

        if (collision.gameObject.tag == "Destination")
        {
            audio.PlayOneShot(winSound, 0.5f);
            delvDis.enabled = !delvDis.enabled;
            StartCoroutine(YouWin());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ControllerCol")
        {
            delvFloor.gameObject.SetActive(false);
        }
    }

    IEnumerator YouWin()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel);
    }

}
