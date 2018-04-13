using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAreaScript : MonoBehaviour {
    public Light targetLigh;
    public bool runUpdate;
    //float timer = 0;
	// Use this for initialization
	void OnTriggerStay (Collider other) {
        if(other.CompareTag("Player")&& !runUpdate)
        {
            targetLigh.enabled = !targetLigh.enabled;
        }
	}
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")&& !runUpdate)
        {
            runUpdate = false;
        }
    }
    void Update()
    {
        if (runUpdate)
        {
            if((int)Time.time %2 == 0)
            {
                targetLigh.enabled = !targetLigh.enabled;
            }
        }
    }
}
