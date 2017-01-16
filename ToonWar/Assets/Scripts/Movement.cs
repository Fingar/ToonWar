using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = 2f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v3x = CameraController.instance.transform.right * Input.GetAxis("Horizontal");
        Vector3 v3y = CameraController.instance.transform.forward * Input.GetAxis("Vertical");

        transform.Translate((v3x + v3y).normalized * Speed * Time.deltaTime);
	}

}
