using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlueArea : MonoBehaviour {

    public Light targetLight;
	// Use this for initialization
	void OnTriggerEnter (Collider other ) {
        if (other.CompareTag("Player"))
        {
            targetLight.enabled = true;
        }
	}
}
