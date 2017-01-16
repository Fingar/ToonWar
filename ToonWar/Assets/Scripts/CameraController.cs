using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static CameraController instance;

	// Use this for initialization
	void Awake () {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
