using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;
using Unity.VisualScripting;

public class Gem : MonoBehaviour
{
    public GameObject missParticle;

    public GameObject gameSceneObject;
    public GameObject restartObject;

    public GameObject[] spawners;
    public Vector3[] angles;
    public GameObject arrowPrefab;

    public int misses = 0;

    public float magn, rough, fadeIn, fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CreateArrow());
    }

    // Update is called once per frame
    void Update()
    {
        print("delay"+GameManager.delay);
        print("initial delay" + GameManager.initialDelay);
        if (misses >6)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("arrow");
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }

            misses = 0;
            GameManager.score = 0;
            paddle.spdMultiplier = 0.007f;
            paddle.delayMultiplier = 0.007f;
            GameManager.arrowSpeed = GameManager.inicialArrowSpeed;
            gameSceneObject.gameObject.SetActive(false);
            restartObject.gameObject.SetActive(true);
            GameManager.gameStarted = false;
        }
        if (GameManager.score > 60 && GameManager.score < 111)
        {
            paddle.spdMultiplier = 0.003f;
            paddle.delayMultiplier = 0.003f;
        }
        if (GameManager.score > 110 && GameManager.score < 231)
        {
            paddle.spdMultiplier = 0.001f;
            paddle.delayMultiplier = 0.001f;
        }
        if (GameManager.score > 230 && GameManager.score < 340)
        {
            paddle.spdMultiplier = 0.0006f;
            paddle.delayMultiplier = 0.0005f;
        }
        if (GameManager.score > 339 && GameManager.score < 500)
        {
            paddle.spdMultiplier = 0.0002f;
            paddle.delayMultiplier = 0.0002f;
        }
    }
    public IEnumerator CreateArrow()
    {
        yield return new WaitForSeconds(GameManager.delay);
        int spawner = Random.Range(0, 4);
        Quaternion angle;
        angle = Quaternion.Euler(angles[spawner]);
        Vector3 postition = spawners[spawner].transform.position;
        var arrow = Instantiate(arrowPrefab, postition, angle);

        StartCoroutine(CreateArrow());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("arrow"))
        {
            Instantiate(missParticle);
            CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
            misses++;
            Destroy(collision.gameObject);
        }
    }
}
