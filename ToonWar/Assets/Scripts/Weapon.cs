using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject ProjectileObj;
    public Transform FireTip;

    public bool Repeater = true;

    public float FireRate = 3f;

    public float ProjectileDamage = 10f;
    public float ProjectileSpeed = 50f;

    private float fireRateTimer = 0;
    private int bullet = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Repeater)
        {
            if(fireRateTimer <= 0)
            {
                if (Input.GetButton("Fire1"))
                {
                    Fire();
                    fireRateTimer = 1 / FireRate;
                }
            }    
        }

        fireRateTimer -= Time.deltaTime;
	}

    void Fire()
    {
        bullet++;
        Debug.Log("FIRE bullet " + bullet);
        Projectile p = Instantiate(ProjectileObj, transform.position, transform.rotation).GetComponent<Projectile>();
        p.Damage = ProjectileDamage;
        p.Speed = ProjectileSpeed;
        AudioManager.instance.PlaySFX("wpn_assaultrifle_fire01");
    }
}
