using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBevahaviour : MonoBehaviour {
    public float speed = 1;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherRendere = other.GetComponent<SpriteRenderer>();
        if (otherRendere != null && other.CompareTag("Block"))
        {
            int targetAmmount = (otherRendere.color == spriteRenderer.color)? 5 : 2 ;
            other.GetComponent<BlockEnty>().DecreaseLife(targetAmmount);
            Destroy(gameObject);
            }
        }
}