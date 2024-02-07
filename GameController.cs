using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private const int MAX_ENEMIES = 5;
    private List<GameObject> enemy01List = new List<GameObject>();
    private List<GameObject> enemy02List = new List<GameObject>();
    private List<GameObject> enemy03List = new List<GameObject>();
    private List<GameObject> enemy04List = new List<GameObject>();
    public GameObject enemy01Prefab, enemy02Prefab, enemy03Prefab, enemy04Prefab;
    public GameObject hitsText, missesText;
    private int hits = 0;
    private int misses = 0;
    public GameObject educationTxt, coursesTxt, experienceTxt, interestsTxt, gameoverTxt;
    private bool educationShown = false;
    private bool coursesShown = false;
    private bool experienceShown = false;
    private bool interestsShown = false;
    private bool gameoverShown = false;
    private string currentLevel = "level1";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeShip1());
    }

    IEnumerator MakeShip1() {
        
        WaitForSeconds wait = new WaitForSeconds(2f);
        if(enemy01List.Count < MAX_ENEMIES) {
            GameObject g = Instantiate(enemy01Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            enemy01List.Add(g);
            yield return wait;
            StartCoroutine(MakeShip1());
        }

    }

    IEnumerator MakeShip2() {

        WaitForSeconds wait = new WaitForSeconds(1f);
        if(enemy02List.Count < MAX_ENEMIES) {
            float yPos = enemy02List.Count;
            GameObject g = Instantiate(enemy02Prefab, new Vector3(transform.position.x, transform.position.y -yPos, transform.position.z), Quaternion.identity);
            enemy02List.Add(g);
            yield return wait;
            StartCoroutine(MakeShip2());
        }

    }

    IEnumerator MakeShip3() {
        
        WaitForSeconds wait = new WaitForSeconds(1f);
        if(enemy03List.Count < (MAX_ENEMIES - 1)) {
            float xPos = (enemy03List.Count + 1f) * 6f;
            GameObject g = Instantiate(enemy03Prefab, new Vector3(transform.position.x + xPos, -7f, transform.position.z), Quaternion.identity);
            enemy03List.Add(g);
            yield return wait;
            StartCoroutine(MakeShip3());
        }

    }

    IEnumerator MakeShip4() {
        
        WaitForSeconds wait = new WaitForSeconds(1f);
        if(enemy04List.Count < MAX_ENEMIES - 4) {
            float xPos = 0f;
            GameObject g = Instantiate(enemy04Prefab, new Vector3(xPos, 4f, transform.position.z), Quaternion.identity);
            enemy04List.Add(g);
            yield return wait;
            StartCoroutine(MakeShip4());
        }        

    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindGameObjectWithTag("Enemy01_Tag") == null && currentLevel == "level1") {
            if(!educationShown) {
                educationShown = true;
                educationTxt.SetActive(true);
            }
            if(GameObject.Find("Education") == null && currentLevel == "level1") {
                currentLevel = "level2";
                StartCoroutine(MakeShip2());
            }
        }
        if(GameObject.FindGameObjectWithTag("Enemy02_Tag") == null && currentLevel == "level2"){
            if(!coursesShown) {
                coursesShown = true;
                coursesTxt.SetActive(true);
            }
            if(GameObject.Find("Courses") == null && currentLevel == "level2") {
                currentLevel = "level3";
                StartCoroutine(MakeShip3());
            }
        }
        if(GameObject.FindGameObjectWithTag("Enemy03_Tag") == null && currentLevel == "level3") {
            if(!experienceShown) {
                experienceShown = true;
                experienceTxt.SetActive(true);
            }
            if(GameObject.Find("Experience") == null && currentLevel == "level3") {
                currentLevel = "level4";
                StartCoroutine(MakeShip4());
            }
        }
        if(GameObject.FindGameObjectWithTag("Enemy04_Tag") == null && currentLevel == "level4") {
            print("INTERESTS MUST BE SHOWN...");
            if(!interestsShown) {
                interestsShown = true;
                interestsTxt.SetActive(true);
            }
            if(GameObject.Find("Interests") == null && currentLevel == "level4") {
                currentLevel = "level5";
                if(!gameoverShown) {
                    gameoverShown = true;
                    gameoverTxt.SetActive(true);
                }
            }  
        }
        
    }

    public void SetHits() {
        hits++;
        hitsText.GetComponent<TextMeshProUGUI>().text = "HITS: " + hits.ToString();
    }

    public void SetMisses() {
        misses++;
        missesText.GetComponent<TextMeshProUGUI>().text = "MISSES: " + misses.ToString();
    }

    public void MenuGame() {
        SceneManager.LoadScene("MenuScene");
    }

}
