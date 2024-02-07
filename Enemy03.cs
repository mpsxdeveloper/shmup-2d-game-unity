using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : MonoBehaviour
{

    private float yBounds = 5f;
    private bool movingUp = true;
    private float speed = 1.5f;

    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();        
    }

    // Update is called once per frame
    void Update()
    {

        if(movingUp) {
            if(transform.position.y < yBounds) {
                transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            }
            else {
                 movingUp = false;
                 transform.Rotate(180f, 0f, 0f, Space.Self);
            }
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y - (speed * 1.5f * Time.deltaTime), transform.position.z);
        }
        if(transform.position.y < -8f) {
            Destroy(gameObject);
            controller.SetMisses();
        }

    }

}