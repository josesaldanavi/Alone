using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour {

    public float gravity;
    float verticalSpeed;
    public float horizontalSpeed = 1;
    public float jumpForce = 1;


    Vector3 rightMode{ get { return transform.position - new Vector3(-0.5f, 1, 0); }}
    Vector3 leftMode{ get { return transform.position - new Vector3(0.5f, 1, 0); }}
    bool isGrounded;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
                isGrounded = false;
            }
        }

        RaycastHit2D left = Physics2D.Raycast(leftMode,Vector3.down , 0.1f);
        RaycastHit2D right = Physics2D.Raycast(rightMode, Vector3.down, 0.1f);

        if(left || right){
            isGrounded = true;
            verticalSpeed = 0;
        }else {
            isGrounded = false;
        }
        transform.Translate(Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0);

    }

	private void OnDrawGizmos()
	{
        Gizmos.DrawSphere(leftMode, 0.2f);
        Gizmos.DrawSphere(rightMode, 0.2f);
	}

}
