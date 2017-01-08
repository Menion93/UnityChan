using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    ATBController controller;

    void Awake()
    {
        controller = GetComponent<ATBController>();
    }

	void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == Tag.Projectile || coll.tag == Tag.HeavyProjectile)
        {
            Projectile projectile = coll.GetComponent<Projectile>();

            if(coll.tag == Tag.Projectile)
            {
                controller.Damage(projectile.damage);
            }
            else
            {
                controller.HeavyDamage(projectile.damage);
            }

            projectile.Explode();
        }
    }
}
