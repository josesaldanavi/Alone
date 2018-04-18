using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawArea : MonoBehaviour {

    public GameObject objectToSpawn;
    public Transform objectToFollow;
    public bool spawnPossible = true;

    public Transform LightBox;
    static public Light lighIndicator;

    float timer = 0;

    void start()
    {
        lighIndicator = LightBox.Find("Point Light").GetComponent<Light>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Follower"))
        {
            spawnPossible = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (CompareTag("Follower"))
        {
            spawnPossible = true;
        }
    }

    void Update()
    {
        if (spawnPossible)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
               GameObject spawmnedOject=Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                spawmnedOject.transform.Translate(Vector3.down);
                spawmnedOject.GetComponents<FollowScript>().target= objectToFollow;
                spawmnedOject.GetComponents<FollowScript>().speed = Random.Range(1f, 5.5f);
                timer = 0;
            }
        }
    }
}
