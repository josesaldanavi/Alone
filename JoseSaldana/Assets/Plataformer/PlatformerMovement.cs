using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour {

    public float gravity;
    float verticalSpeed;
    public float horizontalSpeed = 1;
    public float jumpForce = 1;


    bool isGrounded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!isGrounded){
            verticalSpeed -= gravity * Time.deltaTime;
        }else {
            if(Input.GetKeyDown(KeyCode.Space)){
                verticalSpeed = jumpForce;
                //esto es por isGrounded es booleano
                isGrounded = false;
            }
        }
        transform.Translate(Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
        if(other.CompareTag("plataform")){
            isGrounded = true;
            verticalSpeed = 0;
            ContactFilter2D filter = new ContactFilter2D();
            filter.useTriggers=true;
            RaycastHit2D[] hits2D = null;
            float currentDistance = 0;
            Physics2D.Raycast(transform.position, Vector3.down, filter, hits2D);
            if(hits2D != null){
                currentDistance = hits2D[0].distance;
            }
        }
	}
}
