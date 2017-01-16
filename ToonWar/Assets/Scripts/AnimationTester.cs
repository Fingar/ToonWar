using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTester : MonoBehaviour {

    private Animator _Animator;

	// Use this for initialization
	void Start () {
        _Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        _Animator.SetFloat("X", Input.GetAxis("Horizontal"));
        _Animator.SetFloat("Y", Input.GetAxis("Vertical"));
        _Animator.SetBool("Firing", Input.GetButton("Fire1"));
    }
}
