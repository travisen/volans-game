﻿using UnityEngine;

public class bullet_script : MonoBehaviour {

    public GameObject explosion;

    private float speed = 30f;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collide_type type = collision.GetComponent<collide_type>();
        if (type.type != "shield")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
    

}
