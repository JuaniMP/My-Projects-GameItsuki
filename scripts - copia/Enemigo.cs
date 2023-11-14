using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform objetivo; // Transform del personaje
    public event EventHandler MuerteJugador;

    private Rigidbody2D rb;
    private int maximoVida = 100; // Assign a value to maximoVida

    // Start is called before the first frame update
    void Start()
    {
        vida = maximoVida;
        rb = GetComponent<Rigidbody2D>();
        objetivo = GameObject.FindGameObjectWithTag("Player").transform; // Buscar el GameObject con tag "Player"
    }

    private void FixedUpdate()
    {
        Mover();
    }

    public void TomarDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
    
    private void Mover()
    {
        // Calcular la dirección hacia el objetivo
        Vector2 direccion = new Vector2(objetivo.position.x - transform.position.x, objetivo.position.y - transform.position.y);
        direccion.Normalize();

        // Mover al enemigo hacia el objetivo
        rb.velocity = new Vector2(direccion.x * velocidadMovimiento, rb.velocity.y);

        // Voltear la imagen del enemigo según la dirección
        if (direccion.x > 0)
        {
            transform.localScale = new Vector3(-4, 4, 4); // Mantener la escala original
        }
        else if (direccion.x < 0)
        {
            transform.localScale = new Vector3(4, 4, 4); // Voltear la imagen horizontalmente
        }
    }
}
