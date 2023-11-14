using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CombateJugador : MonoBehaviour
{
   [SerializeField] private int vida;
   [SerializeField] private int maximoVida; // Se agregó el punto y coma que faltaba al final de la línea

   public Slider sliderVidas; // Se cambió SliderVidas por sliderVidas para seguir las convenciones de nomenclatura
   public event EventHandler MuerteJugador;

   private void OnCollisionEnter2D(Collision2D otro)
   {
      if (otro.gameObject.CompareTag("espinas"))
      {
         TomarDaño(5); // Se cambió vida-- por TomarDaño(1) para mantener el código más consistente
      }
      else if (otro.gameObject.CompareTag("Enemigo"))
      {
         TomarDaño(15); // Se cambió vida-- por TomarDaño(1) para mantener el código más consistente
      }
   }

   private void Start()
   {
      vida = maximoVida;
      ActualizarSliderVida(); // Se llama a la función para actualizar el valor del Slider al iniciar
   }

   public void TomarDaño(int daño)
   {
      vida -= daño;
      if (vida <= 0)
      {
         MuerteJugador?.Invoke(this, EventArgs.Empty);
         Destroy(gameObject);
      }
      else
      {
         ActualizarSliderVida(); // Se llama a la función para actualizar el valor del Slider después de recibir daño
      }
   }

   public void Curar(int curacion)
   {
      if ((vida + curacion) > maximoVida)
      {
         vida = maximoVida;
      }
      else
      {
         vida += curacion;
      }

      ActualizarSliderVida(); // Se llama a la función para actualizar el valor del Slider después de curar
   }

   private void ActualizarSliderVida()
   {
      if (sliderVidas != null) // Se agrega una verificación para evitar errores si el Slider no está asignado
      {
         sliderVidas.value = vida;
      }
   }
}
