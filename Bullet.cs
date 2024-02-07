using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explosionPrefab;
    private GameController controller;
    private float speed = 0.15f;
    private static int bossCount = 0;
    private bool bossHit = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        if(transform.position.y > 7f) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if((other.gameObject.tag == "Enemy01_Tag" || other.gameObject.tag == "Enemy02_Tag" || other.gameObject.tag == "Enemy03_Tag")
            && gameObject.GetComponent<SpriteRenderer>().isVisible) {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if(other.GetComponent<SpriteRenderer>().isVisible) {
                other.GetComponent<SpriteRenderer>().enabled = false;
                GameObject explosion = Instantiate(explosionPrefab, new Vector3(other.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(explosion, 0.7f);
                Destroy(other.gameObject, 1f);
                controller.SetHits();
            }
        }
        if(other.gameObject.tag == "Enemy04_Tag" && gameObject.GetComponent<SpriteRenderer>().isVisible) {            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;            
            if(!bossHit && bossCount < 10) {
                bossHit = true;
                bossCount++;
                GameObject explosion = Instantiate(explosionPrefab, new Vector3(other.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(explosion, 0.7f);
                Invoke("BossWasHit", 0.5f);
            }
            if(bossCount < 10) {                
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.15f, other.transform.position.z);
            }
            else {                
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                if(other.GetComponent<SpriteRenderer>().isVisible) {
                    other.GetComponent<SpriteRenderer>().enabled = false;
                    GameObject explosion = Instantiate(explosionPrefab, new Vector3(other.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Destroy(explosion, 0.7f);
                    Destroy(other.gameObject, 1f);
                    controller.SetHits();
                }
            }                  
            
        }
    }

    private void BossWasHit() {
        bossHit = false;
    }

}