using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleRotation : MonoBehaviour
{
    public float[] pitches;
    public AudioSource audio;

    Quaternion rotation;
    float z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Quaternion.Euler(0,0,z);
        transform.rotation = rotation;

        int randomValue = Random.Range(0, 4);
        audio.pitch = pitches[randomValue];

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            z = 0;
            print(randomValue);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            z = 180;
            audio.Play();
            print(randomValue);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            z = 270;
            audio.Play();
            print(randomValue);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            z = 90;
            audio.Play();
            print(randomValue);
        }
    }
}
