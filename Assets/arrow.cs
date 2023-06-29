using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float angle = rb.rotation * Mathf.Deg2Rad; // Converte o ângulo de graus para radianos

        Vector2 direction = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
        direction.Normalize();
        rb.velocity = direction*GameManager.arrowSpeed;

    }
}
