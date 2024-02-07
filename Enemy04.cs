using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy04 : MonoBehaviour
{

    private float speed = 0.7f;
    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
         controller = GameObject.Find("GameController").GetComponent<GameController>();
         transform.Rotate(0f, 180f, 0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y - (speed * 1.5f * Time.deltaTime), transform.position.z);
        if(transform.position.y < -8f) {
            Destroy(gameObject);
            controller.SetMisses();
        }

    }
    
}