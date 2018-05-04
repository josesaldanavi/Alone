using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCamMovement : MonoBehaviour {
    
    public Transform targetObject;
    TapDowmMovement targetScript;
    public Color targetColor;
    public float distance = 1;
    public float maxDistance = 1;

    public float speed = 0;
    float desAcel = 15;
    public Vector3 impulDirection;
	// Use this for initialization
	void Start () {
        targetScript = targetObject.GetComponent<TapDowmMovement>();
	}

	// Update is called once per frame
	void LateUpdate () {
        Vector3 targetCamPos = targetObject.position +( targetScript.sightDirection.up * distance);
        Vector3 currentCamPos = transform.position;
        targetCamPos.z = transform.position.z;
        float currentDistance = Vector3.Distance(currentCamPos, targetCamPos);
        transform.position = Vector3.MoveTowards(transform.position, targetCamPos, maxDistance*currentDistance * Time.deltaTime);

    }

    //dibuja una esfera 
    void OnDrawGizmos()
    {
        Gizmos.color =targetColor;
        Vector3 targetViewPos = (targetScript != null)?targetObject.position + (Vector3.up * distance):Vector3.zero;
        Gizmos.DrawWireSphere(targetViewPos,0.5f);
        Gizmos.color = Color.red;
        Vector3 currentViewPost=new Vector3(transform.position.x, transform.position.y, 0);
        Gizmos.DrawWireSphere(currentViewPost, 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(currentViewPost, targetViewPos);
        
    }
}
