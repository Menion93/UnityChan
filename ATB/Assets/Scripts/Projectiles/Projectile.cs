using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;

    public GameObject explosionPrefab;

    Transform myTransform;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        myTransform.position += myTransform.forward * speed * Time.deltaTime;
    }

	public void Explode()
    {
        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
