using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofre : MonoBehaviour
{
    private void OnCollisionEnter2D (Collision2D other) { 
        if(other.collider.CompareTag("Player")){ 
            Debug.Log("jugador entro");
        }
    }

    private void OnCollisionExit2D (Collision2D other) { 
        if(other.collider.CompareTag("Player")){ 
            Debug.Log("jugador salio");
        }
    }


}
