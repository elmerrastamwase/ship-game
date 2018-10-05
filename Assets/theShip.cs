using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theShip : MonoBehaviour {

    //variabler
    float shipSpeed;
    public Color rightColor;
    public Color leftColor;
    public SpriteRenderer shipRender;
    public float timerTime;
    int shipRotation;
    float timerPrintCooldown;
    float positionX;
    float positionY;


    // Use this for initialization
    void Start () {
        //ship movement speed
        shipSpeed = Random.Range(5, 11);
        //ship rotation speed
        shipRotation = Random.Range(230, 261);
        //spawn location
        transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
    }
	
	// Update is called once per frame
	void Update () { 

        //seppet general   
        //ship speed
        transform.Translate(shipSpeed * Time.deltaTime, 0, 0);

        //höger/vänster kod
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -260 * Time.deltaTime);
            shipRender.color = rightColor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, (shipRotation - 10) * Time.deltaTime);
            shipRender.color = leftColor;
        }

        //kod för att sakta ner skeppet
        if (Input.GetKeyDown(KeyCode.S))
        {
            shipSpeed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            shipSpeed *= 2;
        }

        //timer kod
        timerPrintCooldown += 1 * Time.deltaTime;
        timerTime += 1 * Time.deltaTime;

        if (timerPrintCooldown >= 1)
        {
            print("timer: " + timerTime);
            timerPrintCooldown = 0;
        }

        //kod för random färg
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipRender.color = new Color(Random.Range(0f, 2f), Random.Range(0f, 2f), Random.Range(0f, 2f));
        }

        //screen wraparound
        if (transform.position.x <= -10.5)
        {
            transform.position = new Vector3(10.4f, transform.position.y);
        }
        if (transform.position.x >= 10.5)
        {
            transform.position = new Vector3(-10.4f, transform.position.y);
        }
        if (transform.position.y <= -5.5)
        {
            transform.position = new Vector3(transform.position.x, 5.4f);
        }
        if (transform.position.y >= 5.5)
        {
            transform.position = new Vector3(transform.position.x, -5.4f);
        }
    }
}
