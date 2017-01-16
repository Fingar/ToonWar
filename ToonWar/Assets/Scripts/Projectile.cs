using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Damage {
        get { return damage; }
        set { damage = value; }
    }
    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public float Lifetime = 2f;

    private float damage;
    private float speed;

	// Use this for initialization
	void Awake () {
        Destroy(gameObject, Lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, 20))
        {

            Destroy(gameObject);
        }
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Gizmos.DrawRay(ray);
        if (Physics.Raycast(ray, out hit, 30))
        {
            Gizmos.DrawWireSphere(hit.point, 0.25f);
        }
    }
}
