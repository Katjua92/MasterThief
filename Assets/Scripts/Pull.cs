using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pull : MonoBehaviour {

    public SteamVR_TrackedObject controller;

    [HideInInspector]
    public Vector3 prevPos;

    [HideInInspector]
    public bool canGrip;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        prevPos = controller.transform.localPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grip"))
        {
            //Debug.Log(gameObject.name + " == GripTrue");
            canGrip = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grip"))
        {
            //Debug.Log(gameObject.name + " == GripFalse");
            canGrip = false;
        }
    }
}
