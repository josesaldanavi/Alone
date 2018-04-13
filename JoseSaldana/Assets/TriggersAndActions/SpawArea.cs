using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawArea : MonoBehaviour {

    public GameObject enemy;
    public bool spawPossible = true;
    public float timer = 0;
	void OnTriggerStay (Collider other) {
        if (other.CompareTag("Player"))
        {
            spawPossible = false;
        }
	}

    void Update()
    {
        if (spawPossible)
        {
            timer += Time.deltaTime;
        }
    }
}
