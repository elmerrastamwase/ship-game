using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theShip : MonoBehaviour {

    //variabler
    float shipSpeed;
    public Color rightColor;
    public Color leftColor;
    public SpriteRenderer shipRender;
    public SpriteRenderer shipRender2;
    public float timerTime;
    int shipRotation;
    float timerPrintCooldown;
    float positionX;
    float positionY;


    // Use this for initialization
    void Start () {
        //ship movement speed
        shipSpeed = Random.Range(8, 16);
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
            transform.Rotate(0, 0, (-shipRotation * Time.deltaTime));
            shipRender.color = rightColor;
            shipRender2.color = rightColor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, (shipRotation - 10) * Time.deltaTime);
            shipRender.color = leftColor;
            shipRender2.color = leftColor;
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
            Color c = new Color(Random.Range(0f, 2f), Random.Range(0f, 2f), Random.Range(0f, 2f));
            shipRender.color = c;
            shipRender2.color = c;
        }

        //screen wraparound
        if (transform.position.x <= -10.6)
        {
            transform.position = new Vector3(10.5f, transform.position.y);
        }
        if (transform.position.x >= 10.6)
        {
            transform.position = new Vector3(-10.5f, transform.position.y);
        }
        if (transform.position.y <= -6.7)
        {
            transform.position = new Vector3(transform.position.x, 6.6f);
        }
        if (transform.position.y >= 6.7)
        {
            transform.position = new Vector3(transform.position.x, -6.6f);
        }
    }
}
