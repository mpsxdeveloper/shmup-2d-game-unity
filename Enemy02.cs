using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{

    private float xBounds = 9f;
    private bool movingRight = true;
    private bool canMove = false;
    private float speed = 2.5f;
    private float xAttackPos = 0f;

    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        Invoke("SetCanMove", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) {
            if(transform.position.x < xBounds && movingRight) {
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
            }
            else {
                movingRight = false;
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
        }
        if(transform.position.y < -6f) {
            canMove = false;
            Destroy(gameObject);
            controller.SetMisses();
        }
    }

    private void SetCanMove() {
        canMove = true;
    }

}