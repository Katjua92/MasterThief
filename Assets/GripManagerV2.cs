using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GripManagerV2 : MonoBehaviour {

	public GameObject cameraRig;

	public Pull left;
	public Pull right;

    public bool canGrippsRight;
    public bool canGrippsLeft;

	// Use this for initialization
	void Start () {
        canGrippsRight  = false;
        canGrippsLeft = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () { 

	    canGrippsRight = right.canGrip;
        canGrippsLeft = left.canGrip;

        if (canGrippsRight || canGrippsLeft)
        {

            if (canGrippsLeft && SteamVR_Input.__actions_default_in_GrabDrag.GetState(SteamVR_Input_Sources.LeftHand))
            {
                
                Vector3 posIncr = left.prevPos - left.transform.localPosition;
                posIncr.y = 0;
                cameraRig.transform.position += posIncr;
            }

            if (canGrippsRight && SteamVR_Input.__actions_default_in_GrabDrag.GetState(SteamVR_Input_Sources.RightHand))
            {
                
                Vector3 posIncr = right.prevPos - right.transform.localPosition;
                posIncr.y = 0;
                cameraRig.transform.position += posIncr;
            }
        }
        //left.prevPos = left.transform.localPosition;
		//right.prevPos = right.transform.localPosition;
	}

}

