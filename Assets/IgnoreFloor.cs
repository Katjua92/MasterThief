using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreFloor : MonoBehaviour {

    private Collider bodyCol;

    // Use this for initialization
    void Start() {
        bodyCol = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision collision)
    {
        Collider colidedWith = collision.gameObject.GetComponent<Collider>();
        if ((collision.gameObject.tag == "Floor" || collision.gameObject.tag == "ControllerCol") && colidedWith != null)
        {
            //Debug.Log("Head + floor collision ignored");
            Physics.IgnoreCollision(colidedWith, bodyCol);
        }
    }
}
