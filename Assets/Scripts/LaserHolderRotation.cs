using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHolderRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 euler = transform.eulerAngles;
        
        euler.x = Random.Range(0f, 45f);
        euler.y = Random.Range(90f, 110f);
        
        transform.eulerAngles = euler;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
