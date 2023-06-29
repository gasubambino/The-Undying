using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{
    public GameObject gameSceneObject;
    public GameObject restartObject;

    public GameObject[] spawners;
    public Vector3[] angles;
    public GameObject arrowPrefab;

    public int misses = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateArrow());
    }

    // Update is called once per frame
    void Update()
    {
        print("delay"+GameManager.delay);
        print("initial delay" + GameManager.initialDelay);
        if (misses >2)
        {
            misses = 0;
            GameManager.score = 0;
            paddle.spdMultiplier = 0.007f;
            paddle.delayMultiplier = 0.007f;
            GameManager.arrowSpeed = GameManager.inicialArrowSpeed;
            gameSceneObject.gameObject.SetActive(false);
            restartObject.gameObject.SetActive(true);
            GameManager.gameStarted = false;
        }
        if (GameManager.score > 34)
        {
            paddle.spdMultiplier = 0.006f;
            paddle.delayMultiplier = 0.007f;
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
            misses++;
            Destroy(collision.gameObject);
        }
    }
}
