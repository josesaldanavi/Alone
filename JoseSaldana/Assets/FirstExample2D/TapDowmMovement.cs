﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDowmMovement : MonoBehaviour {
    public float speed = 1;
    public float angularVelocity = 1;

    public GameObject bullet;

    public List<Color> colors = new List<Color>();
    int colorIndex = 0;

    public SpriteRenderer spriteRenderer;
    public Transform sightDirection;
    class Axis
    {
        public string name;
        public KeyCode negative;
        public KeyCode positive;

        public Axis(string _name, KeyCode _negative, KeyCode _positive)
        {
            name = _name;
            negative = _negative;
            positive = _positive;
        }
    }

    List<Axis> axisList = new List<Axis>();

    // Use this for initialization
    void Start()
    {
        spriteRenderer.color = colors[colorIndex];
        axisList.Add(new Axis("Horizontal", KeyCode.A, KeyCode.D));
        axisList.Add(new Axis("Vertical", KeyCode.S, KeyCode.W));
        axisList.Add(new Axis("Arrow_H", KeyCode.LeftArrow, KeyCode.RightArrow));
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * GetAxis("Horizontal") * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
        //sightDirection.Rotate(Vector3.back * GetAxis("Arrow_H") * angularVelocity * Time.deltaTime);

        Vector3 mouseworldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseworldPos.z = transform.position.z;
        Debug.DrawLine(transform.position,mouseworldPos,Color.red);
        sightDirection.up =(mouseworldPos - transform.position).normalized;

        float scrollweetValue = Input.GetAxis("Mouse ScrollWheel");

        if (scrollweetValue !=0)
        {
            MoveColor(scrollweetValue);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        SpriteRenderer tempRenderer = Instantiate(bullet, sightDirection.Find("Cannon").position, sightDirection.rotation).GetComponent<SpriteRenderer>();
        tempRenderer.color = spriteRenderer.color;
        Destroy(tempRenderer.gameObject, 2);
    }

    void MoveColor(float moveValue)
    {
        moveValue *= 10;
        for(int i=0; i< Mathf.Abs(moveValue); i++)
        {
            colorIndex += 1 * (int)Mathf.Sign(moveValue);
            if(colorIndex >= colors.Count)
            {
                colorIndex = 0;
            }else if (colorIndex < 0)
            {
                colorIndex = colors.Count - 1;
            }
        }
        spriteRenderer.color = colors[colorIndex];
    }

    int GetAxis(string axisName)
    {
        Axis axis = axisList.Find(target => target.name == axisName);
        int axisValue = 0;
        if (Input.GetKey(axis.negative))
        {
            axisValue += -1;
        }
        if (Input.GetKey(axis.positive))
        {
            axisValue += 1;
        }
        return axisValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            Debug.Log("Block collision!");
        }
    }
}