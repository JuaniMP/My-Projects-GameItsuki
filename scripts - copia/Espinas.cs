using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
   [SerializeField] private float tiempoEntreDaño;
   private float tiempoSiguienteDaño;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
           tiempoSiguienteDaño = tiempoEntreDaño;
           DoDamage(other.gameObject);
       }
   }

   private void Update()
   {
       if (tiempoSiguienteDaño > 0)
       {
           tiempoSiguienteDaño -= Time.deltaTime;
       }
   }

   private void DoDamage(GameObject player)
   {
       CombateJugador combateJugador = player.GetComponent<CombateJugador>();
       if (combateJugador != null)
       {
           combateJugador.TomarDaño(10);
       }
   }
}
