using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{

    private bool movingRight;
    private float speed = 2.5f;
    private float xBounds = 9f;
    private int moveCount = 0;
    private float xAttackPos = 0f;

    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        int i = Random.Range(0, 2);
        if(i == 0) {
            movingRight = false;
            transform.position = new Vector3(xBounds + 2f, transform.position.y, transform.position.z);
        }
        else {
            transform.position = new Vector3(-xBounds - 2f, transform.position.y, transform.position.z);
            movingRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(moveCount < 2) {
            if(movingRight) {
                if(transform.position.x < xBounds) {
                    transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
                }
                else {                    
                    movingRight = !movingRight;
                    moveCount++;
                }
            }
            else {
                if(transform.position.x > (-xBounds)) {
                    transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
                }
                else {
                    movingRight = !movingRight;
                    moveCount++;
                }
            }
        }        
        else {            
            if(xAttackPos == 0f) {
                GameObject player = GameObject.Find("Player");
                xAttackPos = player.transform.position.x;                
            }
            if(transform.position.x < xAttackPos) {
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y - (speed * Time.deltaTime), transform.position.z);
            }
            else if(transform.position.x > xAttackPos) {
                transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y - (speed * Time.deltaTime), transform.position.z);
            }
            else {
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
            }
        }

        if(transform.position.y < -6f) {
            Destroy(gameObject);
            controller.SetMisses();
        }

    }

}