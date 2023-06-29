using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public static float spdMultiplier = 0.02f;
    public static float delayMultiplier = 0.02f;
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
            Destroy(collision.gameObject);
            GameManager.delay -= delayMultiplier;
            GameManager.score++;
            GameManager.arrowSpeed += GameManager.arrowSpeed * spdMultiplier;
        }
    }
}
