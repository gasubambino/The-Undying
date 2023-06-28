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
        float angulo = rb.rotation * Mathf.Deg2Rad; // Converte o ângulo de graus para radianos

        Vector2 direcao = new Vector2(Mathf.Sin(angulo), Mathf.Cos(angulo));

        rb.AddForce(direcao * 2);
    }
}
