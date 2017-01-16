using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    [Range(0, 1070)]
    public float r = 0;

    public GameObject FireArm;

    private Vector3 target;

    private Vector3 throwTarget;

	// Use this for initialization
	void Start () {
        Aim();
    }
	
	// Update is called once per frame
	void Update () {
        Aim();     
    }

    void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 v3 = hit.point;
            v3.y = FireArm.transform.position.y;
            target = v3;
        }
        FireArm.transform.LookAt(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(FireArm.transform.position, target);
        Gizmos.DrawWireSphere(target, 0.25f);

    }
}
