using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetector : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.tag);

        // An object Collision has also features like
        // finding the contact points of the collision.
        if(coll.gameObject.tag == "EnemyAmmo")
        {
            Debug.Log("I've been hitted!");
        }
    }
}
