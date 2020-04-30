using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OpenMenu : MonoBehaviour {

    public Canvas menuCan;
	// Use this for initialization
	void Start () {
        menuCan.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (SteamVR_Input.__actions_default_in_Menu.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            menuCan.gameObject.SetActive(!menuCan.gameObject.activeSelf);

        }
	}
}
