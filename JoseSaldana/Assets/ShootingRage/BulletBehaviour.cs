using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    public float speed = 1;
    public float lifespan = 3;
	// Use this for initialization
	void Start () {
        Destroy(gameObject,lifespan);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward* speed * Time.deltaTime);
	}
}
