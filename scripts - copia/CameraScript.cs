using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Nyo;
    public bool jugadorMuerto = false;

    void Update()
    {
        if (!jugadorMuerto && Nyo != null)
        {
            Vector3 position = transform.position;
            position.x = Nyo.transform.position.x;
            transform.position = position;
        }
    }

    public void OnJugadorMuerto()
    {
        jugadorMuerto = true;
    }
}

