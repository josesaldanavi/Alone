using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    public GameObject player;
    public Vector3 distanciaP;

	// Use this for initialization
	void Start () {
        distanciaP = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + distanciaP;
	}
}
