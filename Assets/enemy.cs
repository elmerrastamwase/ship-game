using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public Transform playership;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (playership.position.x >= transform.position.x)
        {
            transform.Translate(5 * Time.deltaTime, 0, 0); 
        }
        if (playership.position.x <= transform.position.x)
        {
            transform.Translate(-5 * Time.deltaTime, 0, 0);
        }
        if (playership.position.y >= transform.position.y)
        {
            transform.Translate(0, 5 * Time.deltaTime, 0);
        }
        if (playership.position.y <= transform.position.y)
        {
            transform.Translate(0, -5 * Time.deltaTime, 0);
        }


        //screen wraparound
        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(10.1f, transform.position.y);
        }
        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(-10.1f, transform.position.y);
        }
        if (transform.position.y <= -6)
        {
            transform.position = new Vector3(transform.position.x, 6.1f);
        }
        if (transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, -6.1f);
        }
    }
}
