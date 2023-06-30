using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;
using Unity.VisualScripting;

public class Gem : MonoBehaviour
{
    public AudioSource damageSound;

    public Animator animator;

    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

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
        if (misses >4)
        {
            GameManager.gameEnded = true;
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
        if (GameManager.score > 500)
        {
            paddle.spdMultiplier = 0f;
            paddle.delayMultiplier = 0f;
        }
        if (misses>3)
        {
            animator.SetBool("is1hp", true);
        }
        else
        {
            animator.SetBool("is1hp", false);
        }
        switch (misses)
            {
            case 0:
                spriteRenderer.sprite = sprites[0];
                break;
            case 1:
                spriteRenderer.sprite = sprites[1];
                break;
            case 2:
                spriteRenderer.sprite = sprites[2];
                break;
            case 3:
                spriteRenderer.sprite = sprites[3];
                break;
            case 4:
                spriteRenderer.sprite = sprites[4];
                break;
            case 5:
                spriteRenderer.sprite = sprites[5];
                break;
            case 6:
                spriteRenderer.sprite = sprites[6];
                break;

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
            damageSound.Play();
            Instantiate(missParticle);
            CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
            misses++;
            Destroy(collision.gameObject);
        }
    }
}
