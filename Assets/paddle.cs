using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using EZCameraShake;

public class paddle : MonoBehaviour
{
    public AudioSource arrowDestroyedSound;

    public float magn, rough, fadeIn, fadeOut;

    public GameObject arrowDestroyParticle;

    public static float spdMultiplier = 0.007f;
    public static float delayMultiplier = 0.007f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("arrow"))
        {
            arrowDestroyedSound.Play();
            Instantiate(arrowDestroyParticle,collision.transform.position,Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
            Destroy(collision.gameObject);
            GameManager.delay -= delayMultiplier;
            GameManager.score++;
            GameManager.arrowSpeed += GameManager.arrowSpeed * spdMultiplier;
        }
    }
}
