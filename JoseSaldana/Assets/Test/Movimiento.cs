using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {
    public float speed;
    Rigidbody playerRB;
    Vector3 inicialPos;

    public AudioClip backgroudSound;
    public AudioSource camSource;
	// Use this for initialization
	void Start () {
        inicialPos = transform.position;
        playerRB = GetComponent<Rigidbody>();
        camSource.PlayOneShot(backgroudSound);
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.A)) {
            playerRB.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            //transform.Rotate(new Vector3(0, -35, 0) * Time.deltaTime);
            
        }
		if (Input.GetKey (KeyCode.D)) {
			playerRB.MovePosition(transform.position+(Vector3.right *speed* Time.deltaTime));
            //transform.Rotate(new Vector3(0, -35, 0) * Time.deltaTime);

        }
        if (Input.GetKey (KeyCode.W)) {
            playerRB.MovePosition(transform.position+ (Vector3.forward * speed * Time.deltaTime));
            //transform.Translate (Vector3.forward * speed * Time.deltaTime);
        }
		if (Input.GetKey (KeyCode.S)) {
            playerRB.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
            //transform.Translate (Vector3.back * speed * Time.deltaTime);
        }
        
	}
   public void ResetPosition()
    {
        transform.position = inicialPos;
    }
}
