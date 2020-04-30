using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class grabDrag : MonoBehaviour {
    public SteamVR_Action_Boolean ifHeldTure;
    public Rigidbody Body;

    public Pull left;
    public Pull right;

    public float velocityMultiplier = 1.5f;
    public bool isGripped;
    public bool startedClimbing;
    public bool canGripNotification;

    //Transform CamTransform;
    //public Transform Player;
    //float followspeed;
    //protected Transform playArea;
    //protected Vector3 startControllerScaledLocalPosition;
    //protected Vector3 startGrabPointLocalPosition;
    //protected Vector3 startPlayAreaWorldOffset;
    //protected GameObject grabbingController;
    //protected GameObject climbingObject;
    //protected Quaternion climbingObjectLastRotation;
    //protected bool isClimbing;
    //protected bool useGrabbedObjectRotation;
    //public bool usePlayerScale = true;
    //https://github.com/thestonefox/VRTK/blob/master/Assets/VRTK/Source/Scripts/Locomotion/VRTK_PlayerClimb.cs
    // Use this for initialization
    void Start () {
        //CamTransform = Camera.main.transform;
        isGripped = false;
    }
	
	// Update is called once per frame
	void Update () {


        //check for actions
        //when climb action performed which is bind to the trigger you call grab
        // then trigger released you call ungrab
        canGripNotification = right.canGrip;

        if (isGripped)
        {
            startedClimbing = true;
        }

        if (SteamVR_Input.__actions_default_in_GrabDrag.GetStateDown(SteamVR_Input_Sources.Any) )
        {
            print("Oki you can drag now");

        

                Body.useGravity = true;
                Body.isKinematic = false;
                Body.transform.position += (left.prevPos - left.transform.localPosition);
                Body.transform.position += (right.prevPos - right.transform.localPosition);
            



                //Vector3 controllerLocalOffset = GetScaledLocalPosition(grabbingController.transform) - startControllerScaledLocalPosition;
                //Vector3 grabPointWorldPosition = climbingObject.transform.TransformPoint(startGrabPointLocalPosition);
                //playArea.position = grabPointWorldPosition + startPlayAreaWorldOffset - controllerLocalOffset;

                //if (useGrabbedObjectRotation)
                //{
                //    Vector3 lastRotationVec = climbingObjectLastRotation * Vector3.forward;
                //    Vector3 currentObectRotationVec = climbingObject.transform.rotation * Vector3.forward;
                //    Vector3 axis = Vector3.Cross(lastRotationVec, currentObectRotationVec);
                //    float angle = Vector3.Angle(lastRotationVec, currentObectRotationVec);

                //    playArea.RotateAround(grabPointWorldPosition, axis, angle);
                //    climbingObjectLastRotation = climbingObject.transform.rotation;
                //}

                //if (positionRewind != null && !IsHeadsetColliding())
                //{
                //    positionRewind.SetLastGoodPosition();
                //}
            
            //Vector3 targetPosition = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);

            //CamTransform.position = Vector3.Lerp(CamTransform.position, targetPosition, Time.deltaTime * followspeed);
        }
        if (SteamVR_Input.__actions_default_in_GrabDrag.GetStateUp(SteamVR_Input_Sources.Any))
        {
            print("Now you let go");
            Body.useGravity = false;
            Body.isKinematic = true;
            Body.velocity = ((left.prevPos - left.transform.localPosition) * velocityMultiplier) / Time.deltaTime;
            Body.velocity = ((right.prevPos - right.transform.localPosition) * velocityMultiplier) / Time.deltaTime;

        }

        left.prevPos = left.transform.localPosition;
        right.prevPos = right.transform.localPosition;
    }

    //protected virtual Vector3 GetScaledLocalPosition(Transform objTransform)
    //{
    //    if (usePlayerScale)
    //    {
    //        return (playArea.localRotation * Vector3.Scale(objTransform.localPosition, playArea.localScale));
    //    }

    //    return (playArea.localRotation * objTransform.localPosition);
    //}

}
//protected virtual void Grab(GameObject currentGrabbingController, GameObject target)
//{
//    //if (bodyPhysics == null)
//    //{
//    //    return;
//    //}

//    //bodyPhysics.ResetFalling();
//    //bodyPhysics.TogglePreventSnapToFloor(true);
//    //bodyPhysics.enableBodyCollisions = false;
//    //bodyPhysics.ToggleOnGround(false);

    
//    climbingObject = target;
//    grabbingController = currentGrabbingController;
//    startControllerScaledLocalPosition = GetScaledLocalPosition(grabbingController.transform);
//    startGrabPointLocalPosition = climbingObject.transform.InverseTransformPoint(grabbingController.transform.position);
//    startPlayAreaWorldOffset = playArea.transform.position - grabbingController.transform.position;
//    climbingObjectLastRotation = climbingObject.transform.rotation;
//    //useGrabbedObjectRotation = climbingObject.GetComponent<VRTK_ClimbableGrabAttach>().useObjectRotation;

//    OnPlayerClimbStarted(SetPlayerClimbEvent(controllerReference, climbingObject));
//}


  

