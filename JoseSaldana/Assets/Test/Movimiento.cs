using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {
    public float speed;

    public AudioClip backgroudSound;
    public AudioSource camSource;
	// Use this for initialization
	void Start () {
        camSource.PlayOneShot(backgroudSound);
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
            transform.Rotate(new Vector3(0, -35, 0) * Time.deltaTime);
        }
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(new Vector3 (0,35,0)*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * speed * Time.deltaTime);
		}
	}
}
