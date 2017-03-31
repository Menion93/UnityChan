using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleBot : MonoBehaviour {

    public GameObject ammoPrefab;

    public float ammo;
    public float projectileForce;

    public Transform player;
    public float maxDistanceSight;

    public float cooldownBetweenShots = 1;

    bool playerSeen;
    float lastTimeFired;

    Transform m_transform;
    
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.time - lastTimeFired > cooldownBetweenShots && (playerSeen || CheckPlayerSeen()))
        {
            Shoot();
        }
	}

    bool CheckPlayerSeen()
    {
        RaycastHit hit = new RaycastHit();

        Physics.Raycast(
                         m_transform.position,
                         player.position - m_transform.position, 
                         out hit,
                         maxDistanceSight
                       );
        playerSeen = hit.collider != null && hit.collider.tag == "Player";

        if(playerSeen)
        {
            Debug.Log("I see you!");
        }

        return playerSeen;

    }

    void Shoot()
    {
        if (ammo < 1)
        {
            Debug.Log("Damn i'm out of ammo!");
            return;
        }

        ammo--;

        // Instantiate a projectile and fire it towards the player
        GameObject ammoInstance = Instantiate(ammoPrefab, m_transform.position, Quaternion.identity);
        Vector3 forceDirection = player.position - m_transform.position;
        ammoInstance.GetComponent<Rigidbody>().AddForce(forceDirection * projectileForce);

        lastTimeFired = Time.time;
    }
}
