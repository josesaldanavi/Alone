using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAreaScript : MonoBehaviour {
    public Light offLight;
	// Use this for initialization
	void OnTriggerExit (Collider other) {
        if (other.CompareTag("Player"))
        {
            offLight.enabled=false;
        }
		
	}
}
