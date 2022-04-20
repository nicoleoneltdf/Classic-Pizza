using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizzamovement : MonoBehaviour
{
    float mitadDePantallaEnUnidadesDelMundo;
    Rigidbody2D rb;
    float dirX;
    public float speed = 20f;
    public event System.Action OnPlayerDeath;

    void Start()
    {
        float mitadAnchoDelJugador = transform.localScale.x / 2f;
        rb = GetComponent<Rigidbody2D>();
        mitadDePantallaEnUnidadesDelMundo = Camera.main.aspect * Camera.main.orthographicSize - mitadAnchoDelJugador;
    }

    
    void Update()
    {
        dirX = Input.acceleration.x * speed;

        if(transform.position.x < -mitadDePantallaEnUnidadesDelMundo) 
        {
            transform.position = new Vector2(-mitadDePantallaEnUnidadesDelMundo, transform.position.y);        
        }

        if (transform.position.x > mitadDePantallaEnUnidadesDelMundo)
        {
            transform.position = new Vector2(mitadDePantallaEnUnidadesDelMundo, transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Anana") 
        {
            if(OnPlayerDeath != null) 
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
