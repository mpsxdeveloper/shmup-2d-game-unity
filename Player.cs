using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    Vector2 input;
    private bool canMove = true;
    private bool canFire = true;
    private Rigidbody2D rb;
    private float hSpeed = 7f;
    private float vSpeed = 4f;
    private float yLowerBounds = 5.5f;
    private float yUpperBounds = 3f;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(canMove) {
            if(input.x > 0) {
                if(transform.position.x < 9f) {
                    rb.position = new Vector3(rb.position.x + (hSpeed * Time.deltaTime), rb.position.y, 0f);
                }                
            }
            if(input.x < 0) {
                if(transform.position.x > -9f) {
                    rb.position = new Vector3(rb.position.x - (hSpeed * Time.deltaTime), rb.position.y, 0f);
                }                
            }
            if(input.y > 0) {
                if(transform.position.y < yUpperBounds) {
                    rb.position = new Vector3(rb.position.x, rb.position.y + (vSpeed * Time.deltaTime) , 0f);
                }                
            }
            if(input.y < 0) {
                if(transform.position.y > -yLowerBounds) {
                    rb.position = new Vector3(rb.position.x, rb.position.y - (vSpeed * Time.deltaTime) , 0f);
                }                
            }            
        }

    }

    void OnMove(InputValue inputValue) {        
        input = inputValue.Get<Vector2>();        
    }

    void OnFire() {
        if(canFire) {
            canFire = false;
            Shoot();
        }        
    }

    private void Shoot() {
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Invoke("ResetFire", 0.2f);
    }

    private void ResetFire() {
        canFire = true;
    }

}