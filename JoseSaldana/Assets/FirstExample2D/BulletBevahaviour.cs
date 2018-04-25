﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBevahaviour : MonoBehaviour {
    public float speed = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            Destroy(other.gameObject);
        }
    }
}