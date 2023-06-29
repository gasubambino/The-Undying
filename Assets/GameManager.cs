using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject highscoreObj;
    public GameObject scoreObj;
    public GameObject arrowPrefab;

    public GameObject gameSceneObject;
    public GameObject restartObject;
    public GameObject startObject;
    public GameObject startObject2;


    [SerializeField]public Gem gem;

    public static int score = 0;
    public static int highscore;
    public GameObject[] spawners;
    public Vector3[] angles;
    public static float initialDelay = 1;
    [SerializeField]public static float delay;
    public static float inicialArrowSpeed=2;
    public static float arrowSpeed;
    public static bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        delay = initialDelay;
        arrowSpeed = inicialArrowSpeed;


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = initialDelay;
                gameSceneObject.gameObject.SetActive(true);
                restartObject.gameObject.SetActive(false);
                startObject.gameObject.SetActive(false);
                startObject2.gameObject.SetActive(false);

                gameStarted = true;
                gem.StartCoroutine(gem.CreateArrow());
            }
        }
        highscoreObj.GetComponent<TextMeshProUGUI>().text = highscore.ToString();
        scoreObj.GetComponent<TextMeshProUGUI>().text = score.ToString();
        if (score >= highscore)
        {
            highscore = score;
        }
    }

    
}
